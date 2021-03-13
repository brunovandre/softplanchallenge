using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SoftPlanChallenge.CalculateInterest.Tests.IntegrationTests.Customs
{
    public class CustomHttpClientFactory : IHttpClientFactory
    {
        public CustomHttpClientFactory(
            IReadOnlyDictionary<string, HttpClient> httpClients)
        {
            HttpClients = httpClients;
        }

        private IReadOnlyDictionary<string, HttpClient> HttpClients { get; }

        public HttpClient CreateClient(string name) =>
            HttpClients.GetValueOrDefault(name);
    }
}
