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

        protected delegate void WriteXmlDelegate(XmlTextWriter xmlWriter);


        protected static string PerformRequest(HttpRequestMethod method, string urlPath)
        {
            HttpStatusCode statusCode;
            return PerformRequest(method, urlPath, null, out statusCode);
        }

        protected static string PerformRequest(HttpRequestMethod method, string urlPath, 
            out HttpStatusCode statusCode)
        {
            return PerformRequest(method, urlPath, out statusCode);
        }

        protected static string PerformRequest(HttpRequestMethod method, string urlPath,
            WriteXmlDelegate writeXmlDelegate)
        {
            HttpStatusCode statusCode;
            return PerformRequest(method, urlPath, writeXmlDelegate, out statusCode);
        }

        protected static string PerformRequest(HttpRequestMethod method, string urlPath,
            WriteXmlDelegate writeXmlDelegate, out HttpStatusCode statusCode)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(ServerUrl + urlPath);
            request.Accept = "application/xml"; // Tells the server to return XML instead of HTML
            request.ContentType = "application/xml"; // The request is an XML document
            request.SendChunked = false;
            request.UserAgent = UserAgent;
            request.Headers.Add(HttpRequestHeader.Authorization, AuthorizationHeaderValue);
            request.Method = method.ToString().ToUpper();

            if ((method == HttpRequestMethod.Post || method == HttpRequestMethod.Put) && (writeXmlDelegate != null))
            {
                // Set POST/PUT body
                using (Stream requestStream = request.GetRequestStream())
                {
                    WritePostParameters(requestStream, writeXmlDelegate);
                    request.ContentLength = requestStream.Position;
                }
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                statusCode = response.StatusCode;
                return ReadWebResponse(response);
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    HttpWebResponse response = (HttpWebResponse)ex.Response;
                    statusCode = response.StatusCode;

                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                        case HttpStatusCode.Accepted:
                        case HttpStatusCode.Created:
                        case HttpStatusCode.NoContent:
                            return ReadWebResponse(response);

                        case HttpStatusCode.NotFound:
                            throw new NotFoundException(ReadWebResponse(response), ex);

                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.Forbidden:
                            throw new InvalidCredentialsException();

                        case HttpStatusCode.PreconditionFailed:
                        case ValidationException.HttpStatusCode: // Unprocessable Entity
                            throw new ValidationException(ReadWebResponse(response), ex);

                        case HttpStatusCode.ServiceUnavailable:
                            throw new TemporarilyUnavailableException(ReadWebResponse(response), ex);

                        case HttpStatusCode.InternalServerError:
                            throw new RecurlyServerException(ReadWebResponse(response), ex);
                    }
                }

                throw;
            }
        }

        private static string ReadWebResponse(HttpWebResponse response)
        {
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
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
