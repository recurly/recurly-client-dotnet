using System;
using System.Net;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading;

[assembly: InternalsVisibleTo("Recurly.Tests")]

namespace Recurly
{
    public class BaseClient
    {
        public string SiteId { get; }
        private string ApiKey { get; }
        private const string ApiUrl = "https://partner-api.recurly.com/";
        public virtual string ApiVersion { get; protected set; }

        public IRecurlyLogger Logger { private get; set; }

        internal IRestClient RestClient { get; set; }

        public BaseClient(string siteId, string apiKey)
        {
            if (String.IsNullOrEmpty(siteId))
                throw new ArgumentException($"siteId is required. You passed in {siteId}");
            if (String.IsNullOrEmpty(apiKey))
                throw new ArgumentException($"apiKey is required. You passed in {apiKey}");

            SiteId = siteId;
            ApiKey = apiKey;
            Logger = new NullLogger();
            RestClient = new RestClient();
            RestClient.BaseUrl = new Uri(ApiUrl);
            RestClient.Authenticator = new HttpBasicAuthenticator(ApiKey, "");

            // AddDefaultHeader does not work for user-agent
            var libVersion = typeof(Recurly.Client).Assembly.GetName().Version;
            RestClient.UserAgent = $"Recurly/{libVersion}; .NET";

            // These are the default headers to send on every request
            RestClient.AddDefaultHeader("Accept", $"application/vnd.recurly.{ApiVersion}");
            RestClient.AddDefaultHeader("Content-Type", "application/json");
            LogInfo($"Created new Recurly client with user agent {RestClient.UserAgent}");
        }

        public async Task<T> MakeRequestAsync<T>(Method method, string url, Request body = null, Dictionary<string, object> queryParams = null, CancellationToken cancellationToken = default(CancellationToken)) where T : new()
        {
            LogInfo($"[HTTP] Calling {method} on {url}");
            var request = BuildRequest(method, url, body, queryParams);
            var stopWatch = Stopwatch.StartNew();
            var task = RestClient.ExecuteTaskAsync<T>(request, cancellationToken);
            return await task.ContinueWith(t =>
            {
                stopWatch.Stop();
                LogInfo($"[HTTP] Got response from {method} on {url}", stopWatch.ElapsedMilliseconds);
                var resp = t.Result;
                this.HandleResponse(resp);
                return resp.Data;
            });
        }

        public T MakeRequest<T>(Method method, string url, Request body = null, Dictionary<string, object> queryParams = null) where T : new()
        {
            LogInfo($"[HTTP] Calling {method} on {url}");
            var request = BuildRequest(method, url, body, queryParams);
            var stopWatch = Stopwatch.StartNew();
            var resp = RestClient.Execute<T>(request);
            stopWatch.Stop();
            LogInfo($"[HTTP] Got response from {method} on {url}", stopWatch.ElapsedMilliseconds);
            this.HandleResponse(resp);
            return resp.Data;
        }

        public void _SetApiUrl(string uri)
        {
            LogInfo("[SECURITY-WARNING] _SetApiUrl is for testing only and not supported in production.");
            if (System.Environment.GetEnvironmentVariable("RECURLY_INSECURE") == "true")
            {
                this.RestClient.BaseUrl = new Uri(uri);
            }
            else
            {
                LogInfo($"[SECURITY-WARNING] ApiUrl not changed. To change, set the environment variable RECURLY_INSECURE to true");
            }
        }

        private RestRequest BuildRequest(Method method, string url, Request body = null, Dictionary<string, object> queryParams = null)
        {
            var request = new RestRequest(url, method);
            request.JsonSerializer = Recurly.JsonSerializer.Default;

            // If we have any query params, add them to the request
            if (queryParams != null)
            {
                url += Utils.QueryString(queryParams);
            }

            // If we have a body, serialize it and add it to the request
            if (body != null)
            {
                request.AddJsonBody(body);
            }

            return request;
        }

        private void HandleResponse(IRestResponse resp)
        {
            if (resp.Headers.Any(t => t.Name == "Recurly-Deprecated"))
            {
                var headers = resp.Headers.ToList();
                var deprecated = headers
                    .Find(x => x.Name == "Recurly-Deprecated")
                    .Value.ToString();
                var sunset = headers
                    .Find(x => x.Name == "Recurly-Sunset-Date")
                    .Value.ToString();

                if (deprecated.ToUpper() == "TRUE")
                {
                    LogInfo($"[WARNING] Your current API version \"${ApiVersion}\" is deprecated and will be sunset on ${sunset}");
                }
            }

            var status = (int)resp.StatusCode;

            // If the response has an ErrorException,
            // an error casting the json to a Resource
            // has likely occurred
            if (resp.ErrorException != null)
            {
                throw new RecurlyError(resp.ErrorMessage);
            }
            else if (status < 200 || status >= 300)
            {
                // Turn web exceptions into Recurly.NetworkErrors
                if (resp.ErrorException is WebException)
                {
                    var netError = new Errors.NetworkError(resp.ErrorMessage);
                    netError.ExceptionStatus = ((WebException)resp.ErrorException).Status;
                    throw netError;
                }
                // everything else becomes a Recurly.ApiError
                else
                {
                    var serializer = Recurly.JsonSerializer.Default;
                    var err = serializer.Deserialize<Errors.ApiErrorWrapper>(resp).Error;
                    var ex = Errors.Factory.Create(err);
                    throw ex;
                }
            }
        }

        protected string InterpolatePath(string path, Dictionary<string, object> urlParams)
        {
            urlParams.Add("site_id", SiteId);
            var regex = new Regex("{([A-Za-z|_]*)}");
            // TODO ToString() here might not appropriately format all data types
            // such as datetimes
            // TODO could get rid of string replaces with nicer regex matcher
            return regex.Replace(path, m => urlParams[m.Value.Replace("{", "").Replace("}", "")].ToString());
        }

        private void LogInfo(string message, float? duration = null)
        {
            Logger.Log(RecurlyLogLevel.Information, message, duration);
        }

        private void LogDebug(string message, float? duration = null)
        {
            Logger.Log(RecurlyLogLevel.Debug, message, duration);
        }
    }
}
