using System;
using System.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace Recurly {
    public class BaseClient {
        private const string API_URL = "https://partner-api.recurly.com/";
        public string SiteId { get; }
        public string ApiKey { get; }
        private RestClient RestClient { get; }

        public BaseClient(string siteId, string apiKey) {
            SiteId = siteId;
            ApiKey = apiKey;
            RestClient = new RestClient(API_URL);
            RestClient.Authenticator = new HttpBasicAuthenticator(ApiKey, "");
            var apiVersion = ApiVersion();
            RestClient.AddDefaultHeader("Accept", $"application/vnd.recurly.{apiVersion}");
            RestClient.AddDefaultHeader("Content-Type", "application/json");
            RestClient.AddDefaultHeader("User-Agent", "Recurly/0.0.1; .NET");
        }

        public IRestResponse<T> MakeRequest<T>(Method method, string url, Request body = null) where T: new() {
            Console.WriteLine($"Calling {url}");
            var request = new RestRequest(url, method);
            if (body != null)
                request.AddObject(body);

            var resp = RestClient.Execute<T>(request);
            var status = (int)resp.StatusCode;
            if (status < 200 || status >= 300) {
                throw new ApiError("Bad responses code");
            }
            Console.WriteLine(resp.Content);
            return resp;
        }

        public IRestResponse MakeRequest(Method method, string url) {
            var request = new RestRequest(url, method);
            var resp = RestClient.Execute(request);
            var status = (int)resp.StatusCode;
            if (status < 200 || status >= 300) {
                throw new ApiError("Bad responses code");
            }
            return resp;
        }

        public Type GetErrorClass(string key) {
            return typeof(ApiError).Assembly.GetTypes()
            .Where(type => type.IsSubclassOf(typeof(ApiError)) && type.Name == key).First();
        }

        protected string ApiVersion() {
            return null;
        }
    }
}