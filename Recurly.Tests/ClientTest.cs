using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Xunit;
using Recurly;
using Recurly.Resources;
using RestSharp;
using RestSharp.Authenticators;
using Moq;

namespace Recurly.UnitTests
{
    public class ClientTest
    {
        private readonly Recurly.Client _client;
        private string SiteId = "subdomain-mysubdomain";
        private string ApiKey = "myapikey";

        public ClientTest()
        {
            _client  = new Recurly.Client(SiteId, ApiKey);
        }

        [Fact]
        public void CantInitializeWithoutSiteIdAndApiKey()
        {
          Assert.Throws<ArgumentException>(() => new Recurly.Client(null, ApiKey));
          Assert.Throws<ArgumentException>(() => new Recurly.Client("", ApiKey));
          Assert.Throws<ArgumentException>(() => new Recurly.Client(SiteId, null));
          Assert.Throws<ArgumentException>(() => new Recurly.Client(SiteId, ""));
        }

        [Fact]
        public void SetsTheSiteId()
        {
          Assert.Equal("subdomain-mysubdomain", _client.SiteId);
        }

        [Fact]
        public void RespondsWithAValidApiVersion()
        {
          Assert.Matches(new Regex("v\\d{4}-\\d{2}-\\d{2}"), _client.ApiVersion);
        }

        [Fact]
        public void SetsUpRestClientWithAppropriateConfig()
        {
            var restClient = _client.RestClient;
            Assert.Equal(new Uri("https://partner-api.recurly.com"), restClient.BaseUrl);
            Assert.NotNull(restClient.Authenticator);
            var apiVersion = _client.ApiVersion;

            var acceptParam = restClient.DefaultParameters.First(p => p.Name == "Accept");
            Assert.Equal(ParameterType.HttpHeader, acceptParam.Type);
            Assert.Equal($"application/vnd.recurly.{apiVersion}", acceptParam.Value);

            var contentParam = restClient.DefaultParameters.First(p => p.Name == "Content-Type");
            Assert.Equal(ParameterType.HttpHeader, contentParam.Type);
            Assert.Equal("application/json", contentParam.Value);

            var libVersion = typeof(Recurly.Client).Assembly.GetName().Version;
            var agentParam = restClient.DefaultParameters.First(p => p.Name == "User-Agent");
            Assert.Equal(ParameterType.HttpHeader, agentParam.Type);
            Assert.Equal($"Recurly/{libVersion}; .NET", agentParam.Value);
        }

        [Fact]
        public void CanProperlyFetchAResource()
        {
            _client.RestClient = this.GetAccountSuccessClient();
            Account account = _client.GetAccount("code-benjamin");
            Assert.Equal("benjamin", account.Code);
        }

        [Fact]
        public void CanProperlyCreateAResource()
        {
            _client.RestClient = this.CreateAccountSuccessClient();
            var request = new AccountCreate() {
                Code = "benjamin"
            };
            Account account = _client.CreateAccount(request);
            Assert.Equal("benjamin", account.Code);
        }

        [Fact]
        public void WillThrowAnExceptionForNon200()
        {
            _client.RestClient = this.GetAccountFailureClient();
            Assert.Throws<Recurly.ApiError>(() =>  _client.GetAccount("code-benjamin"));
        }

        private IRestClient GetAccountSuccessClient() {
            var data = new Account() {
                Code = "benjamin"
            };
            var response =  new Mock<IRestResponse<Account>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
            response.Setup(_ => _.Content).Returns("{\"code\": \"benjamin\"}");
            response.Setup(_ => _.Data).Returns(data);

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .Setup(x => x.Execute<Account>(It.IsAny<IRestRequest>()))
                .Returns(response.Object);

            return mockIRestClient.Object;
        }
        private IRestClient CreateAccountSuccessClient() {
            var data = new Account() {
                Code = "benjamin"
            };
            var response =  new Mock<IRestResponse<Account>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.Created);
            response.Setup(_ => _.Content).Returns("{\"code\": \"benjamin\"}");
            response.Setup(_ => _.Data).Returns(data);

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .Setup(x => x.Execute<Account>(It.IsAny<IRestRequest>()))
                .Returns(response.Object);

            return mockIRestClient.Object;
        }

        private IRestClient GetAccountFailureClient() {
            var response =  new Mock<IRestResponse<Account>>();
            response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.NotFound);
            response.Setup(_ => _.Content).Returns("{\"error\":{ \"type\": \"not_found\", \"message\": \"Account not found\"}}");

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .Setup(x => x.Execute<Account>(It.IsAny<IRestRequest>()))
                .Returns(response.Object);

            return mockIRestClient.Object;
        }
    }
}
