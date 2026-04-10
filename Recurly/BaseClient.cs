using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Recurly.Tests")]

namespace Recurly
{
    public class BaseClient
    {
        private string ApiKey { get; }
        private string[] BinaryTypes = { "application/pdf" };
        private List<IEventHandler> EventHandlers = new List<IEventHandler>();
        public virtual string ApiVersion { get; protected set; }

        private Uri _baseUrl;
        internal HttpClient HttpClient { get; set; }

        private int _timeoutMs;

        public BaseClient(string apiKey) : this(apiKey, new ClientOptions()) { }

        public BaseClient(string apiKey, ClientOptions options)
        {
            if (String.IsNullOrEmpty(apiKey))
                throw new ArgumentException($"apiKey is required. You passed in {apiKey}");

            ApiKey = apiKey;
            _baseUrl = new Uri(options.BaseUrl);

            HttpClient = new HttpClient();
            _timeoutMs = (int)HttpClient.Timeout.TotalMilliseconds;

            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ApiKey}:"));
            HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", credentials);

            var libVersion = typeof(Recurly.Client).Assembly.GetName().Version;
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", $"Recurly/{libVersion}; {RuntimeInformation.FrameworkDescription}");

            HttpClient.DefaultRequestHeaders.Accept.ParseAdd($"application/vnd.recurly.{ApiVersion}");
        }

        /// <value>Timeout in milliseconds to be used for the request</value>
        public int Timeout
        {
            get { return _timeoutMs; }
            set
            {
                _timeoutMs = value;
                HttpClient.Timeout = TimeSpan.FromMilliseconds(value);
            }
        }

        public async Task<T> MakeRequestAsync<T>(HttpMethod method, string url, Request body = null, Dictionary<string, object> queryParams = null, RequestOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) where T : Resource
        {
            Debug.WriteLine($"Calling {url}");
            var httpRequest = new Http.Request()
            {
                Method = method,
                Url = url,
                Body = body
            };
            var requestMessage = BuildRequest(method, url, body, queryParams, options);

            foreach (var handler in this.EventHandlers)
            {
                handler.OnRequest(httpRequest);
            }

            HttpResponseMessage responseMessage;
            try
            {
                responseMessage = await HttpClient.SendAsync(requestMessage, cancellationToken);
            }
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                throw new Errors.NetworkError("Request timed out: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new Errors.NetworkError(ex.Message);
            }

            var rawBytes = await responseMessage.Content.ReadAsByteArrayAsync();
            var contentType = responseMessage.Content.Headers.ContentType?.MediaType ?? "";
            var rawContent = BinaryTypes.Contains(contentType) ? string.Empty : Encoding.UTF8.GetString(rawBytes);

            var httpResponse = Http.Response.Build(responseMessage, rawContent, httpRequest);

            foreach (var handler in this.EventHandlers)
            {
                handler.OnResponse(httpResponse);
            }

            HandleResponse(responseMessage, rawContent);

            T data;
            if (BinaryTypes.Contains(contentType))
            {
                data = (T)(object)new FileSerializer().Deserialize(rawBytes);
            }
            else if (typeof(T) == typeof(EmptyResource))
            {
                data = (T)(object)new EmptyResource();
            }
            else
            {
                data = Recurly.JsonSerializer.Default.Deserialize<T>(rawContent);
            }

            if (data is Resource resource)
                resource.SetResponse(httpResponse);

            return data;
        }

        public T MakeRequest<T>(HttpMethod method, string url, Request body = null, Dictionary<string, object> queryParams = null, RequestOptions options = null) where T : Resource, new()
        {
            return MakeRequestAsync<T>(method, url, body, queryParams, options)
                .GetAwaiter().GetResult();
        }

        public void AddEventHandler(IEventHandler handler)
        {
            this.EventHandlers.Add(handler);
        }

        [ExcludeFromCodeCoverage]
        public void _SetApiUrl(string uri)
        {
            Console.WriteLine("[SECURITY WARNING] _SetApiUrl is for testing only and not supported in production.");
            if (System.Environment.GetEnvironmentVariable("RECURLY_INSECURE") == "true")
            {
                _baseUrl = new Uri(uri);
            }
            else
            {
                Console.WriteLine("ApiUrl not changed. To change, set the environment variable RECURLY_INSECURE to true");
            }
        }

        // Internal for testability
        internal Uri BaseUrl => _baseUrl;

        private HttpRequestMessage BuildRequest(HttpMethod method, string url, Request body = null, Dictionary<string, object> queryParams = null, RequestOptions options = null)
        {
            if (options == null)
            {
                options = new RequestOptions();
            }
            // If we have any query params, add them to the request
            if (queryParams != null)
            {
                url += Utils.QueryString(queryParams);
            }

            // Build the full URL as a string to preserve %2F encoding in path segments
            var uriString = _baseUrl.ToString().TrimEnd('/') + "/" + url.TrimStart('/');
            var request = new HttpRequestMessage(method, uriString);

            foreach (var header in options.Headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            // If we have a body, serialize it and add it to the request
            var json = "";
            if (body != null)
            {
                json = Recurly.JsonSerializer.Default.Serialize(body);
            }
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return request;
        }

        private void HandleResponse(HttpResponseMessage resp, string rawContent)
        {
            if (resp.Headers.Contains("Recurly-Deprecated"))
            {
                var deprecated = resp.Headers.GetValues("Recurly-Deprecated").FirstOrDefault() ?? "";
                if (deprecated.ToUpper() == "TRUE")
                {
                    var sunset = resp.Headers.Contains("Recurly-Sunset-Date")
                        ? resp.Headers.GetValues("Recurly-Sunset-Date").FirstOrDefault()
                        : "unknown";
                    Debug.WriteLine($"[recurly-client-net] WARNING: Your current API version \"${ApiVersion}\" is deprecated and will be sunset on ${sunset}");
                }
            }

            var status = (int)resp.StatusCode;
            Debug.WriteLine($"Status: {status}");
            Debug.WriteLine($"Content: {rawContent}");

            if (status < 200 || status >= 300)
            {
                // Try to parse a structured API error from the JSON body
                Errors.ApiErrorWrapper wrapper = null;
                try
                {
                    wrapper = Recurly.JsonSerializer.Default.Deserialize<Errors.ApiErrorWrapper>(rawContent);
                }
                catch
                {
                    // JSON parsing failed — will fall back to status-code-based error below
                }

                if (wrapper?.Error != null)
                {
                    // Let Factory.Create throw directly (e.g. ArgumentException in strict mode)
                    throw Errors.Factory.Create(wrapper.Error);
                }
                else
                {
                    var message = $"Unexpected error (HTTP {status})";
                    var error = new Recurly.Resources.ErrorMayHaveTransaction() { Message = message };
                    throw Errors.Factory.Create(resp.StatusCode, message, error);
                }
            }
        }

        private void ValidatePathParameters(Dictionary<string, object> urlParams)
        {
            var invalidParams = urlParams.Where(kvp => string.IsNullOrWhiteSpace(kvp.Value.ToString()));
            if (invalidParams.Any())
            {
                var invalidKeys = string.Join(", ", invalidParams.Select(x => x.Key).ToArray());
                throw new RecurlyError($"{invalidKeys} cannot be an empty value");
            }

        }

        protected string InterpolatePath(string path, Dictionary<string, object> urlParams)
        {
            ValidatePathParameters(urlParams);
            var regex = new Regex("{([A-Za-z|_]*)}");
            // TODO ToString() here might not appropriately format all data types
            // such as datetimes
            // Encode forward slashes in the url components to preserve them through
            // URI construction in BuildRequest.
            return regex.Replace(path, m => urlParams[m.Groups[1].Value].ToString().Replace("/", "%2F"));
        }
    }
}
