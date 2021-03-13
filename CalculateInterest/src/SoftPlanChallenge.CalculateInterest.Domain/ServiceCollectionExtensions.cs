using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SoftPlanChallenge.CalculateInterest.Domain.Commands;
using System.Reflection;

namespace SoftPlanChallenge.CalculateInterest.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServiceDependency(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CalculateInterestCommand).GetTypeInfo().Assembly);

            return services;
        }
    }
}
