using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Class for the Recurly client library.
    /// </summary>
    internal class RecurlyClient
    {
        private const string ProductionServerUrl = "https://api-production.recurly.com";
        private const string SandboxServerUrl = "https://api-sandbox.recurly.com";
        private const string DevelopmentServerUrl = "http://app.recurly.local:3000";

        /// <summary>
        /// Recurly API Username
        /// </summary>
        public static string ApiUsername { get { return Configuration.RecurlySection.Current.Username; } }
        /// <summary>
        /// Recurly API Password
        /// </summary>
        public static string ApiPassword { get { return Configuration.RecurlySection.Current.Password; } }
        /// <summary>
        /// Recurly Site Subdomain
        /// </summary>
        public static string ApiSubdomain { get { return Configuration.RecurlySection.Current.Subdomain; } }
        /// <summary>
        /// Recurly Private Key for Transparent Post API
        /// </summary>
        public static string PrivateKey { get { return Configuration.RecurlySection.Current.PrivateKey; } }
        /// <summary>
        /// Recurly Environment: Production or Sandbox
        /// </summary>
        public static Configuration.RecurlySection.EnvironmentType Environment { get { return Configuration.RecurlySection.Current.Environment; } }

        #region Header Helper Methods

        private static string _userAgent;
        /// <summary>
        /// User Agent header for connecting to Recurly. If an error occurs, Recurly uses this information to find
        /// better diagnose the problem.
        /// </summary>
        private static string UserAgent
        {
            get
            {
                if (_userAgent == null)
                    _userAgent = String.Format("Recurly .NET Client v" +
                        System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());

                return _userAgent;
            }
        }

        private static string _authorizationHeaderValue;
        /// <summary>
        /// Create the web request header value for the API Authorization.
        /// </summary>
        private static string AuthorizationHeaderValue
        {
            get
            {
                if (_authorizationHeaderValue == null)
                {
                    Configuration.RecurlySection apiSection = Configuration.RecurlySection.Current;

                    if (!String.IsNullOrEmpty(ApiUsername) && !String.IsNullOrEmpty(ApiPassword))
                        _authorizationHeaderValue = "Basic " +
                            Convert.ToBase64String(Encoding.UTF8.GetBytes(ApiUsername + ":" + ApiPassword));
                }

                return _authorizationHeaderValue;
            }
        }

        #endregion

        public enum HttpRequestMethod
        {
            /// <summary>
            /// Lookup information about an object
            /// </summary>
            Get,
            /// <summary>
            /// Create a new object
            /// </summary>
            Post,
            /// <summary>
            /// Update an existing object
            /// </summary>
            Put,
            /// <summary>
            /// Delete an object
            /// </summary>
            Delete
        }

        /// <summary>
        /// Delegate to read the XML response from the server.
        /// </summary>
        /// <param name="xmlReader"></param>
        public delegate void ReadXmlDelegate(XmlTextReader xmlReader);

        /// <summary>
        /// Delegate to write the XML request to the server.
        /// </summary>
        /// <param name="xmlWriter"></param>
        public delegate void WriteXmlDelegate(XmlTextWriter xmlWriter);


        public static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath)
        {
            return PerformRequest(method, urlPath, null, null);
        }

        public static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath,
            ReadXmlDelegate readXmlDelegate)
        {
            return PerformRequest(method, urlPath, null, readXmlDelegate);
        }

        public static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath,
            WriteXmlDelegate writeXmlDelegate)
        {
            return PerformRequest(method, urlPath, writeXmlDelegate, null);
        }

        public static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath,
            WriteXmlDelegate writeXmlDelegate, ReadXmlDelegate readXmlDelegate)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(ServerUrl(Environment) + urlPath);
            request.Accept = "application/xml";      // Tells the server to return XML instead of HTML
            request.ContentType = "application/xml"; // The request is an XML document
            request.SendChunked = false;             // Send it all as one request
            request.UserAgent = UserAgent;
            request.Headers.Add(HttpRequestHeader.Authorization, AuthorizationHeaderValue);
            request.Method = method.ToString().ToUpper();

            System.Diagnostics.Debug.WriteLine(String.Format("Recurly: Requesting {0} {1}", 
                request.Method, request.RequestUri.ToString()));

            if ((method == HttpRequestMethod.Post || method == HttpRequestMethod.Put) && (writeXmlDelegate != null))
            {
                // 60 second timeout -- some payment gateways (e.g. PayPal) can take a while to respond
                request.Timeout = 60000;

                // Write POST/PUT body
                using (Stream requestStream = request.GetRequestStream())
                    WritePostParameters(requestStream, writeXmlDelegate);
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return ReadWebResponse(response, readXmlDelegate);
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    HttpWebResponse response = (HttpWebResponse)ex.Response;
                    HttpStatusCode statusCode = response.StatusCode;
                    RecurlyError[] errors;

                    System.Diagnostics.Debug.WriteLine(String.Format("Recurly Library Received: {0} - {1}", 
                        (int)statusCode, statusCode.ToString()));

                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                        case HttpStatusCode.Accepted:
                        case HttpStatusCode.Created:
                        case HttpStatusCode.NoContent:
                            return ReadWebResponse(response, readXmlDelegate);

                        case HttpStatusCode.NotFound:
                            errors = RecurlyError.ReadResponseAndParseErrors(response);
                            if (errors.Length >= 0)
                                throw new NotFoundException(errors[0].Message, errors);
                            else
                                throw new NotFoundException("The requested object was not found.", errors);

                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.Forbidden:
                            errors = RecurlyError.ReadResponseAndParseErrors(response);
                            throw new InvalidCredentialsException(errors);

                        case HttpStatusCode.PreconditionFailed:
                            errors = RecurlyError.ReadResponseAndParseErrors(response);
                            throw new ValidationException(errors);

                        case HttpStatusCode.ServiceUnavailable:
                            throw new TemporarilyUnavailableException();

                        case HttpStatusCode.InternalServerError:
                            errors = RecurlyError.ReadResponseAndParseErrors(response);
                            throw new RecurlyServerException(errors);
                    }

                    if ((int)statusCode == ValidationException.HttpStatusCode) // Unprocessable Entity
                    {
                        errors = RecurlyError.ReadResponseAndParseErrors(response);
                        throw new ValidationException(errors);
                    }
                }

                throw;
            }
        }

        internal static string ServerUrl(Configuration.RecurlySection.EnvironmentType environment)
        {
            switch (environment)
            {
                case Configuration.RecurlySection.EnvironmentType.Production:
                    return ProductionServerUrl;
                case Configuration.RecurlySection.EnvironmentType.Sandbox:
                    return SandboxServerUrl;
                case Configuration.RecurlySection.EnvironmentType.Development:
                    return DevelopmentServerUrl;
                default:
                    throw new ApplicationException("Unknown Recurly Environment.");
            }
        }

        private static HttpStatusCode ReadWebResponse(HttpWebResponse response, ReadXmlDelegate readXmlDelegate)
        {
            HttpStatusCode statusCode = response.StatusCode;

            if (readXmlDelegate != null)
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (XmlTextReader xmlReader = new XmlTextReader(responseStream))
                        readXmlDelegate(xmlReader);
                }
            }

            return statusCode;
        }

        private static void WritePostParameters(System.IO.Stream outputStream, WriteXmlDelegate writeXmlDelegate)
        {
            using (XmlTextWriter xmlWriter = new XmlTextWriter(outputStream, Encoding.UTF8))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.Formatting = Formatting.Indented;

                writeXmlDelegate(xmlWriter);

                xmlWriter.WriteEndDocument();
            }
        }
    }
}