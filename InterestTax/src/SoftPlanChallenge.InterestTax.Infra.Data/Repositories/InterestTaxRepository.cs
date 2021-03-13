using SoftPlanChallenge.InterestTax.Infra.Data.Interfaces;

namespace SoftPlanChallenge.InterestTax.Infra.Data.Repositories
{
    public class InterestTaxRepository : IInterestTaxRepository
    {
        public double GetInterestTax()
            => 0.01;
    }
}
