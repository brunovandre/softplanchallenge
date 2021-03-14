using Microsoft.AspNetCore.Mvc.Testing;
using SoftPlanChallenge.CalculateInterest.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SoftPlanChallenge.CalculateInterest.Tests.IntegrationTests
{
    public class ShowMeTheCodeIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ShowMeTheCodeIntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShowMeTheCode()
        {
            var client = _factory.CreateClient();

            var url = "/ShowMeTheCode";

            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            Assert.True(content.Equals("https://github.com/brunovandre/softplanchallenge"));
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
