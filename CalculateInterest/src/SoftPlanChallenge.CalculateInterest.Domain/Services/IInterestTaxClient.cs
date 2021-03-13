using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlanChallenge.CalculateInterest.Domain.ServiceClients
{
    public interface IInterestTaxClient
    {
        Task<string> GetInterestTaxAsync();
    }
}
