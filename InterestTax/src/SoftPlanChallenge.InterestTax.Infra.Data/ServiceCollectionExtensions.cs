using Microsoft.Extensions.DependencyInjection;
using SoftPlanChallenge.InterestTax.Infra.Data.Interfaces;
using SoftPlanChallenge.InterestTax.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlanChallenge.InterestTax.Infra.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraDataServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IInterestTaxRepository, InterestTaxRepository>();

            return services;
        }
    }
}
