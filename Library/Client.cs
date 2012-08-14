using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Class for the Recurly client library.
    /// </summary>
    internal class Client
    {
        private const string ProductionServerUrl = "https://api.recurly.com/v2";
 
        /// <summary>
        /// Recurly API Key
        /// </summary>
        public static string ApiKey { get { return Configuration.Section.Current.ApiKey; } }
        /// <summary>
        /// Recurly Site Subdomain
        /// </summary>
        public static string ApiSubdomain { get { return Configuration.Section.Current.Subdomain; } }
        /// <summary>
        /// Recurly Private Key for Transparent Post API
        /// </summary>
        public static string PrivateKey { get { return Configuration.Section.Current.PrivateKey; } }

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
                    Configuration.Section apiSection = Configuration.Section.Current;

                    if (!String.IsNullOrEmpty(ApiKey))
                        _authorizationHeaderValue = "Basic " +
                            Convert.ToBase64String(Encoding.UTF8.GetBytes(ApiKey));
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


        public static HttpWebResponse PerformRequest(HttpRequestMethod method, string urlPath)
        {
            return PerformRequest(method, urlPath, null, null);
        }

        public static HttpWebResponse PerformRequest(HttpRequestMethod method, string urlPath,
            ReadXmlDelegate readXmlDelegate)
        {
            return PerformRequest(method, urlPath, null, readXmlDelegate);
        }

        public static HttpWebResponse PerformRequest(HttpRequestMethod method, string urlPath,
            WriteXmlDelegate writeXmlDelegate)
        {
            return PerformRequest(method, urlPath, writeXmlDelegate, null);
        }

        public static HttpWebResponse PerformRequest(HttpRequestMethod method, string urlPath,
            WriteXmlDelegate writeXmlDelegate, ReadXmlDelegate readXmlDelegate)
        {
            var url = urlPath.Contains("://") ? urlPath : (ProductionServerUrl + urlPath);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Accept = "application/xml";      // Tells the server to return XML instead of HTML
            request.ContentType = "application/xml; charset=utf-8"; // The request is an XML document
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
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    ReadWebResponse(response, readXmlDelegate);

                    return response;
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    HttpWebResponse response = (HttpWebResponse)ex.Response;
                    HttpStatusCode statusCode = response.StatusCode;
                    Error[] errors;

                    System.Diagnostics.Debug.WriteLine(String.Format("Recurly Library Received: {0} - {1}",
                        (int)statusCode, statusCode.ToString()));

                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                        case HttpStatusCode.Accepted:
                        case HttpStatusCode.Created:
                        case HttpStatusCode.NoContent:
                            ReadWebResponse(response, readXmlDelegate);

                            return response;

                        case HttpStatusCode.NotFound:
                            errors = Error.ReadResponseAndParseErrors(response);
                            if (errors.Length > 0)
                                throw new NotFoundException(errors[0].Message, errors);
                            else
                                throw new NotFoundException("The requested object was not found.", errors);

                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.Forbidden:
                            errors = Error.ReadResponseAndParseErrors(response);
                            throw new InvalidCredentialsException(errors);

                        case HttpStatusCode.PreconditionFailed:
                            errors = Error.ReadResponseAndParseErrors(response);
                            throw new ValidationException(errors);

                        case HttpStatusCode.ServiceUnavailable:
                            throw new TemporarilyUnavailableException();

                        case HttpStatusCode.InternalServerError:
                            errors = Error.ReadResponseAndParseErrors(response);
                            throw new ServerException(errors);
                    }

                    if ((int)statusCode == ValidationException.HttpStatusCode) // Unprocessable Entity
                    {
                        errors = Error.ReadResponseAndParseErrors(response);
                        throw new ValidationException(errors);
                    }
                }

                throw;
            }
        }

        public static void PerformPageRequests(string urlPath, ReadXmlDelegate readXmlDelegate)
        {
            var regex = new Regex("<([^>]+)>; rel=\"next\"");
            var url = urlPath + (urlPath.Contains("?") ? "&" : "?") + "per_page=200";

            while (url != null)
            {
                var response = PerformRequest(HttpRequestMethod.Get, url, readXmlDelegate);
                var link = response.Headers["Link"];

                url = null;

                if (link != null)
                {
                    var match = regex.Match(link);

                    if (match.Success)
                    {
                        url = match.Groups[1].Value;
                    }
                }
            }
        }

        private static void ReadWebResponse(HttpWebResponse response, ReadXmlDelegate readXmlDelegate)
        {
            if (readXmlDelegate != null)
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (XmlTextReader xmlReader = new XmlTextReader(responseStream))
                    {
                        readXmlDelegate(xmlReader);
                    }
                }
            }
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
