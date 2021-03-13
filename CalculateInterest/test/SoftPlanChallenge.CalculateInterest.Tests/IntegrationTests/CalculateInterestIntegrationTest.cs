using Microsoft.AspNetCore.Mvc.Testing;
using SoftPlanChallenge.CalculateInterest.Tests.IntegrationTests.Customs;
using SoftPlanChallenge.InterestTax.API;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SoftPlanChallenge.CalculateInterest.Tests.IntegrationTests
{
    public class CalculateInterestIntegrationTest
    {
        [Fact]
        public async Task CalculateInterest()
        {
            var calculateInterestFactory = new CustomCalculateInterestFactory();
            var calculateInterestClient = calculateInterestFactory.CreateClient();

            var interestTaxFactory = new WebApplicationFactory<Startup>();
            var interestTaxClient = interestTaxFactory.CreateClient();
            calculateInterestFactory.AddHttpClient("InterestTaxApi", interestTaxClient);
            var url = "/CalculaJuros?valorinicial=100&meses=5";
            var expectedResult = "105.1";

            var response = await calculateInterestClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            Assert.True(content.Equals(expectedResult));
        }

        
    }
}
