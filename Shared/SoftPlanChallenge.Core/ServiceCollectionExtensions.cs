using Microsoft.Extensions.DependencyInjection;
using SoftPlanChallenge.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlanChallenge.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler, NotificationHandler>();

            return services;
        }
    }
}
