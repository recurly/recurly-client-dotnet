using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Web;
using Recurly.Configuration;

[assembly: InternalsVisibleTo("Recurly.Test")]

namespace Recurly
{
    /// <summary>
    /// Class for the Recurly client library.
    /// </summary>
    internal class Client
    {
        // TODO update for multi-tenancy. Currently, is hardcoded to test server, ignores configuration. // done 1/17/14

        // refactored all these settings for increased testability

        public static Settings Settings { get; protected set; }

        static Client()
        {
            Settings = Settings.Instance;
        }

        private Client()
        {
        }

        internal static void ApplySettings(Settings newSettings)
        {
            Settings = newSettings;
        }

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
            var url = Settings.GetServerUri(urlPath);
#if (DEBUG)
            Console.WriteLine("Requesting " + method + " " + url);
#endif
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/xml";      // Tells the server to return XML instead of HTML
            request.ContentType = "application/xml; charset=utf-8"; // The request is an XML document
            request.SendChunked = false;             // Send it all as one request
            request.UserAgent = Settings.UserAgent;
            request.Headers.Add(HttpRequestHeader.Authorization, Settings.AuthorizationHeaderValue);
            request.Method = method.ToString().ToUpper();

            Debug.WriteLine(String.Format("Recurly: Requesting {0} {1}", request.Method, request.RequestUri));

            if ((method == HttpRequestMethod.Post || method == HttpRequestMethod.Put) && (writeXmlDelegate != null))
            {
                // 60 second timeout -- some payment gateways (e.g. PayPal) can take a while to respond
                request.Timeout = 60000;

                // Write POST/PUT body
                using (var requestStream = request.GetRequestStream())
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
                using (var response = (HttpWebResponse)request.GetResponse())
                {

                    ReadWebResponse(response, readXmlDelegate, readXmlListDelegate);
                    return response.StatusCode;

                }
            }
            catch (WebException ex)
            {
                if (ex.Response == null) throw;

                var response = (HttpWebResponse)ex.Response;
                var statusCode = response.StatusCode;
                Error[] errors;

                Debug.WriteLine(String.Format("Recurly Library Received: {0} - {1}", (int)statusCode, statusCode));

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
            var url = Settings.GetServerUri(urlPath);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = acceptType;
            request.ContentType = "application/xml; charset=utf-8"; // The request is an XML document
            request.SendChunked = false;             // Send it all as one request
            request.UserAgent = Settings.UserAgent;
            request.Headers.Add(HttpRequestHeader.Authorization, Settings.AuthorizationHeaderValue);
            request.Method = "GET";
            request.Headers.Add("Accept-Language", acceptLanguage);

            Debug.WriteLine(String.Format("Recurly: Requesting {0} {1}", request.Method, request.RequestUri));

            try
            {
                var r = (HttpWebResponse)request.GetResponse();
                byte[] pdf;
                var buffer = new byte[2048];
                if (!request.HaveResponse || r.StatusCode != HttpStatusCode.OK) return null;
                using (var ms = new MemoryStream())
                {
                    using (var reader = new BinaryReader(r.GetResponseStream(), Encoding.Default))
                    {
                        int bytesRead;
                        while ((bytesRead = reader.Read(buffer, 0, 2048)) > 0)
                        {
                            ms.Write(buffer, 0, bytesRead);
                        }
                    }
                    pdf = ms.ToArray();
                }
                return pdf;

            }
            catch (WebException ex)
            {
                if (ex.Response == null) throw;
                var response = (HttpWebResponse)ex.Response;
                var statusCode = response.StatusCode;
                Error[] errors;

                Debug.WriteLine(String.Format("Recurly Library Received: {0} - {1}", (int)statusCode, statusCode));

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

                throw;
            }
        }

        private static void ReadWebResponse(HttpWebResponse response, ReadXmlDelegate readXmlDelegate, ReadXmlListDelegate readXmlListDelegate)
        {
            if (readXmlDelegate == null && readXmlListDelegate == null) return;
#if (DEBUG)
            var responseStream = CopyAndClose(response.GetResponseStream());
            Debug.WriteLine("Got Response:");

            var reader = new StreamReader(responseStream);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Debug.WriteLine(line);
            }

            responseStream.Position = 0;
            using (var xmlReader = new XmlTextReader(responseStream))
            {
                // Check for pagination
                var records = -1;
                var cursor = string.Empty;

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
                        var u = new Uri(match.Groups[1].Value);
                        var queryString = HttpUtility.ParseQueryString(u.Query);
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

            using (var responseStream = response.GetResponseStream())
            {

                using (var xmlReader = new XmlTextReader(responseStream))
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
                            var u = new Uri(match.Groups[1].Value);
                            var queryString = HttpUtility.ParseQueryString(u.Query);
                            if (null != queryString["cursor"])
                                cursor = queryString["cursor"];
                        }

                    }

                    if (records > 0)
                        readXmlListDelegate(xmlReader, records, cursor);
                    else
                        readXmlDelegate(xmlReader);
                }
            }
#endif
        }

        private static void WritePostParameters(Stream outputStream, WriteXmlDelegate writeXmlDelegate)
        {
            using (var xmlWriter = new XmlTextWriter(outputStream, Encoding.UTF8))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.Formatting = Formatting.Indented;

                writeXmlDelegate(xmlWriter);

                xmlWriter.WriteEndDocument();
            }
#if (DEBUG)
            // Also copy XML to debug output
            Console.WriteLine("Sending Data:");
            var s = new MemoryStream();
            using (var xmlWriter = new XmlTextWriter(s, Encoding.UTF8))
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
            var buffer = new byte[readSize];
            var ms = new MemoryStream();

            var count = inputStream.Read(buffer, 0, readSize);
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
