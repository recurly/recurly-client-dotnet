using System;
using System.Collections;
using System.Linq;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            var request = new RestSharp.RestRequest(url, method);
            //request.RequestFormat = DataFormat.Json;
            //request.JsonSerializer = new NewtonsoftJsonSerializer();

            if (body != null) {
              DefaultContractResolver contractResolver = new DefaultContractResolver
              {
                NamingStrategy = new SnakeCaseNamingStrategy()
              };

              string json = JsonConvert.SerializeObject(body, new JsonSerializerSettings
                  {
                  ContractResolver = contractResolver,
                  Formatting = Formatting.Indented
                  });

                Console.WriteLine("body: ");
                Console.WriteLine(json);
                request.AddParameter("application/json", json , ParameterType.RequestBody);
            }

            var resp = RestClient.Execute<T>(request);
            var status = (int)resp.StatusCode;
            Console.WriteLine($"Status: {status}");
            Console.WriteLine($"Content: {resp.Content}");
            if (status < 200 || status >= 300) {
                throw new ApiError("Bad responses code");
            }
            return resp;
        }

        public IRestResponse MakeRequest(Method method, string url) {
            var request = new RestSharp.RestRequest(url, method);
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

        protected string InterpolatePath(string path, Dictionary<string, object> urlParams) {
          ver regex = new Regex("{(.*)}");
          return regex.Replace(path, m => urlParams.Get(m));
        }

        protected string ApiVersion() {
            return null;
        }
    }
}
