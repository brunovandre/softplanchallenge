using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using SoftPlanChallenge.CalculateInterest.API;
using System;
using System.Collections.Concurrent;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SoftPlanChallenge.CalculateInterest.Tests.IntegrationTests.Customs
{
    public class CustomCalculateInterestFactory : WebApplicationFactory<Startup>
    {
        private ConcurrentDictionary<string, HttpClient> HttpClients { get; } =
            new ConcurrentDictionary<string, HttpClient>();

        public void AddHttpClient(string clientName, HttpClient client)
            => HttpClients.TryAdd(clientName, client);

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IHttpClientFactory>(new CustomHttpClientFactory(HttpClients));
            });

        }
    }
}
