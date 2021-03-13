using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlanChallenge.CalculateInterest.Domain.ServiceClients
{
    public class InterestTaxClient : IInterestTaxClient
    {
        public InterestTaxClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        private HttpClient HttpClient { get; }

        public async Task<string> GetInterestTaxAsync()
        {
            var responseMessage = await HttpClient.GetAsync("TaxaJuros");
            return await responseMessage.Content.ReadAsStringAsync();
        }
        
    }
}
