using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Base class for the Recurly client library.
    /// </summary>
    public class RecurlyClient
    {
        private const string ServerUrl = "https://app.recurly.com";

        /// <summary>
        /// Recurly API Username
        /// </summary>
        public static string ApiUsername { get; set; }
        /// <summary>
        /// Recurly API Password
        /// </summary>
        public static string ApiPassword { get; set; }
        /// <summary>
        /// Recurly Site Subdomain
        /// </summary>
        public static string ApiSubdomain { get; set; }

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
                    if (!String.IsNullOrEmpty(ApiUsername) && !String.IsNullOrEmpty(ApiPassword))
                        _authorizationHeaderValue = "Basic " +
                            Convert.ToBase64String(Encoding.UTF8.GetBytes(ApiUsername + ":" + ApiPassword));
                }

                return _authorizationHeaderValue;
            }
        }

        #endregion

        protected enum HttpRequestMethod
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
        protected delegate void ReadXmlDelegate(XmlTextReader xmlReader);

        /// <summary>
        /// Delegate to write the XML request to the server.
        /// </summary>
        /// <param name="xmlWriter"></param>
        protected delegate void WriteXmlDelegate(XmlTextWriter xmlWriter);


        protected static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath)
        {
            return PerformRequest(method, urlPath, null, null);
        }

        protected static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath,
            ReadXmlDelegate readXmlDelegate)
        {
            return PerformRequest(method, urlPath, null, readXmlDelegate);
        }

        protected static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath,
            WriteXmlDelegate writeXmlDelegate)
        {
            return PerformRequest(method, urlPath, writeXmlDelegate, null);
        }

        protected static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath,
            WriteXmlDelegate writeXmlDelegate, ReadXmlDelegate readXmlDelegate)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(ServerUrl + urlPath);
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
