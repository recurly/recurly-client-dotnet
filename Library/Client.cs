using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Web;
using System.Collections.Specialized;

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
        /// Reads paged XML responses from the server
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <param name="records"></param>
        /// <param name="cursor"></param>
        public delegate void ReadXmlListDelegate(XmlTextReader xmlReader, int records, string cursor);

        /// <summary>
        /// Delegate to write the XML request to the server.
        /// </summary>
        /// <param name="xmlWriter"></param>
        public delegate void WriteXmlDelegate(XmlTextWriter xmlWriter);


        public static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath)
        {
            return PerformRequest(method, urlPath, null, null, null);
        }

        public static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath,
            ReadXmlDelegate readXmlDelegate)
        {
            return PerformRequest(method, urlPath, null, readXmlDelegate, null);
        }

       
        public static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath,
            WriteXmlDelegate writeXmlDelegate)
        {
            return PerformRequest(method, urlPath, writeXmlDelegate, null, null);
        }

        public static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath,
            WriteXmlDelegate writeXmlDelegate, ReadXmlDelegate readXmlDelegate)
        {
            return PerformRequest(method, urlPath, writeXmlDelegate, readXmlDelegate, null);
        }

        public static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath,
            ReadXmlListDelegate readXmlListDelegate)
        {
            return PerformRequest(method, urlPath, null, null, readXmlListDelegate);
        }



        public static HttpStatusCode PerformRequest(HttpRequestMethod method, string urlPath,
            WriteXmlDelegate writeXmlDelegate, ReadXmlDelegate readXmlDelegate, ReadXmlListDelegate readXmlListDelegate)
        {
            var url = urlPath.Contains("://") ? urlPath : (ProductionServerUrl + urlPath);
            #if (DEBUG)
            Console.WriteLine("Requesting " + method.ToString() + " " + url);
#endif
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
                {
                    WritePostParameters(requestStream, writeXmlDelegate);
                }
            }
            else
            {
                request.ContentLength = 0;
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {

                    ReadWebResponse(response, readXmlDelegate, readXmlListDelegate);
                    HttpStatusCode c = response.StatusCode;
                    response.Close();
                    return c;

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
                            ReadWebResponse(response, readXmlDelegate, readXmlListDelegate);

                            return HttpStatusCode.NoContent;

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

        /// <summary>
        /// Used for downloading PDFs
        /// </summary>
        /// <param name="urlPath"></param>
        /// <param name="acceptType"></param>
        /// <param name="acceptLanguage"></param>
        /// <returns></returns>
        public static byte[] PerformDownloadRequest(string urlPath, string acceptType, string acceptLanguage)
        {
            var url = urlPath.Contains("://") ? urlPath : (ProductionServerUrl + urlPath);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Accept = acceptType;
            request.ContentType = "application/xml; charset=utf-8"; // The request is an XML document
            request.SendChunked = false;             // Send it all as one request
            request.UserAgent = UserAgent;
            request.Headers.Add(HttpRequestHeader.Authorization, AuthorizationHeaderValue);
            request.Method = "GET";
            request.Headers.Add("Accept-Language", acceptLanguage);

            System.Diagnostics.Debug.WriteLine(String.Format("Recurly: Requesting {0} {1}",
                request.Method, request.RequestUri.ToString()));

            try
            {
                HttpWebResponse r = (HttpWebResponse)request.GetResponse();
                byte[] pdf = null;
                byte[] buffer = new byte[2048];
                int bytesRead = 0;
                if (request.HaveResponse)
                {
                    if (r.StatusCode == HttpStatusCode.OK)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (BinaryReader reader = new BinaryReader(r.GetResponseStream(), Encoding.Default))
                            {
                                while ((bytesRead = reader.Read(buffer, 0, 2048)) > 0)
                                {
                                    ms.Write(buffer, 0, bytesRead);
                                }
                            }
                            pdf = ms.ToArray();
                        }
                    }
                }
                return pdf;

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

                            return null;

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

        private static void ReadWebResponse(HttpWebResponse response, ReadXmlDelegate readXmlDelegate, ReadXmlListDelegate readXmlListDelegate)
        {
            if (readXmlDelegate != null || readXmlListDelegate != null)
            {
#if (DEBUG)
                MemoryStream responseStream = CopyAndClose(response.GetResponseStream());
                System.Diagnostics.Debug.WriteLine("Got Response:");

                StreamReader reader = new StreamReader(responseStream);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    System.Diagnostics.Debug.WriteLine(line);
                }

                responseStream.Position = 0;
                using (XmlTextReader xmlReader = new XmlTextReader(responseStream))
                {
                    // Check for pagination
                    int records = -1;
                    string cursor = string.Empty;

                    if (null != response.Headers["X-Records"])
                    {
                        Int32.TryParse(response.Headers["X-Records"], out records);
                    }

                    if (null != response.Headers["Link"])
                    {
                        var regex = new Regex("<([^>]+)>; rel=\"next\"");
                        var match = regex.Match(response.Headers["Link"]);

                        if (match.Success)
                        {
                            Uri u = new Uri(match.Groups[1].Value);
                            NameValueCollection queryString = HttpUtility.ParseQueryString(u.Query);
                            if (null != queryString["cursor"])
                                cursor = queryString["cursor"];
                        }

                    }

                    if (records >= 0)
                        readXmlListDelegate(xmlReader, records, cursor);
                    else
                        readXmlDelegate(xmlReader);
                }


#else

                using (Stream responseStream = response.GetResponseStream())
                {

                    using (XmlTextReader xmlReader = new XmlTextReader(responseStream))
                    {
                         // Check for pagination
                    int records = 0;
                    string cursor = string.Empty;

                    if (null != response.Headers["X-Records"])
                    {
                        Int32.TryParse(response.Headers["X-Records"], out records);
                    }

                    if (null != response.Headers["Link"])
                    {
                        var regex = new Regex("<([^>]+)>; rel=\"next\"");
                        var match = regex.Match(response.Headers["Link"]);

                        if (match.Success)
                        {
                           Uri u = new Uri(match.Groups[1].Value);
                            NameValueCollection queryString = HttpUtility.ParseQueryString(u.Query);
                            if (null != queryString["cursor"])
                                cursor = queryString["cursor"];
                        }

                    }

                    if (records > 0 )
                        readXmlListDelegate(xmlReader, records, cursor);
                    else
                        readXmlDelegate(xmlReader);
                    }
                }
#endif
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
#if (DEBUG)
            /// Also copy XML to debug output
            Console.WriteLine("Sending Data:");
            MemoryStream s = new MemoryStream();
            using (XmlTextWriter xmlWriter = new XmlTextWriter(s, Encoding.UTF8))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.Formatting = Formatting.Indented;

                writeXmlDelegate(xmlWriter);

                xmlWriter.WriteEndDocument();
            }
            Console.WriteLine(Encoding.UTF8.GetString(s.ToArray()));
#endif

        }


        private static MemoryStream CopyAndClose(Stream inputStream)
        {
            const int readSize = 256;
            byte[] buffer = new byte[readSize];
            MemoryStream ms = new MemoryStream();

            int count = inputStream.Read(buffer, 0, readSize);
            while (count > 0)
            {
                ms.Write(buffer, 0, count);
                count = inputStream.Read(buffer, 0, readSize);
            }
            ms.Position = 0;
            inputStream.Close();
            return ms;
        }

    }

}
