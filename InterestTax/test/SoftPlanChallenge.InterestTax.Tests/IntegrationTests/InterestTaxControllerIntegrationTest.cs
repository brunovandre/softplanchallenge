using Microsoft.AspNetCore.Mvc.Testing;
using SoftPlanChallenge.InterestTax.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SoftPlanChallenge.InterestTax.Tests.IntegrationTests
{
    public class InterestTaxControllerIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public InterestTaxControllerIntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetInterestTax()
        {
            var client = _factory.CreateClient();

            var url = "/TaxaJuros";

            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            Assert.True(content.Equals("0.01"));
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
