using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Reflection;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Recurly {
    public class BaseClient {
        private const string API_URL = "https://partner-api.recurly.com/";
        public string SiteId { get; }
        private string ApiKey { get; }
        public IRestClient RestClient { get; set; }
        public virtual string ApiVersion { get; protected set; }

        public BaseClient(string siteId, string apiKey) {
            if (String.IsNullOrEmpty(siteId))
                throw new ArgumentException($"siteId is required. You passed in {siteId}");
            if (String.IsNullOrEmpty(apiKey))
                throw new ArgumentException($"apiKey is required. You passed in {apiKey}");

            SiteId = siteId;
            ApiKey = apiKey;
            RestClient = new RestClient();
            RestClient.BaseUrl = new Uri(API_URL);
            RestClient.Authenticator = new HttpBasicAuthenticator(ApiKey, "");
            
            // AddDefaultHeader does not work for user-agent
            var libVersion = typeof(Recurly.Client).Assembly.GetName().Version;
            RestClient.UserAgent = $"Recurly/{libVersion}; .NET";

            // We need to remove the default accepts as they are not overwritten by ours
            RestClient.RemoveDefaultParameter("Accept");

            // These are the default headers to send on every request
            RestClient.AddDefaultHeader("Accept", $"application/vnd.recurly.{ApiVersion}");
            RestClient.AddDefaultHeader("Content-Type", "application/json");
        }

        public IRestResponse<T> MakeRequest<T>(Method method, string url, Request body = null) where T: new() {
            Console.WriteLine($"Calling {url}");
            var request = new RestRequest(url, method);

            if (body != null) {
                string json = Json.Serialize(body); 
                Console.WriteLine("body: ");
                Console.WriteLine(json);
                request.AddParameter("application/json", json , ParameterType.RequestBody);
            }

            var resp = RestClient.Execute<T>(request);
            var status = (int)resp.StatusCode;
            Console.WriteLine($"Status: {status}");
            Console.WriteLine($"Content: {resp.Content}");
            if (status < 200 || status >= 300) {
                var err = Json.Deserialize<ApiErrorWrapper>(resp.Content).Error;
                var apiError = new ApiError(err.Message);
                apiError.Error = err;
                throw apiError;
            }

            return resp;
        }

        protected string InterpolatePath(string path, Dictionary<string, object> urlParams) {
          urlParams.Add("site_id", SiteId);
          var regex = new Regex("{([A-Za-z|_]*)}");
          // TODO ToString() here might not appropriately format all data types
          // such as datetimes
          // TODO could get rid of string replaces with nicer regex matcher
          return regex.Replace(path, m => urlParams[m.Value.Replace("{", "").Replace("}", "")].ToString());
        }
    }
}
