using System;
using System.Data;
using System.Diagnostics;
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

        public IRestResponse<T> MakeRequest<T>(Method method, string url, Request body = null, Dictionary<string, object> queryParams = null) where T: new() {
            Debug.WriteLine($"Calling {url}");
            var request = new RestRequest(url, method);

            // If we have any query params, add them to the request
            if (queryParams != null)
            {
              foreach(KeyValuePair<string, object> entry in queryParams)
              {
                  if (entry.Value != null)
                  {
                    var stringRepr = entry.Value.ToString();
                    if (entry.Value.GetType() == typeof(DateTime)) {
                        stringRepr = ((DateTime)entry.Value).ToString("o");
                    }
                    Debug.WriteLine($"Parameter: {entry.Key.ToString()} {stringRepr}");
                    request.AddQueryParameter(entry.Key.ToString(), stringRepr);
                  }
              }
            }

            // If we have a body, serialize it and add it to the request
            if (body != null) {
                string json = Json.Serialize(body); 
                Debug.WriteLine("body: ");
                Debug.WriteLine(json);
                request.AddParameter("application/json", json , ParameterType.RequestBody);
            }

            var resp = RestClient.Execute<T>(request);
            this.ProcessResponse(resp);
            var status = (int)resp.StatusCode;
            Debug.WriteLine($"Status: {status}");
            //Debug.WriteLine($"Content: {resp.Content}");
            if (status < 200 || status >= 300) {
                var err = Json.Deserialize<ApiErrorWrapper>(resp.Content).Error;
                var apiError = new ApiError(err.Message);
                apiError.Error = err;
                throw apiError;
            }

            return resp;
        }

        private void ProcessResponse(IRestResponse resp) {
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
                    Debug.WriteLine($"[recurly-client-net] WARNING: Your current API version \"${ApiVersion}\" is deprecated and will be sunset on ${sunset}");
                }
            }
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
