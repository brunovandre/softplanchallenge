using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using SoftPlanChallenge.CalculateInterest.Domain;
using SoftPlanChallenge.CalculateInterest.Domain.ServiceClients;
using SoftPlanChallenge.Core;
using SoftPlanChallenge.Core.Extensions;
using System;
using System.Net.Http;

namespace SoftPlanChallenge.CalculateInterest.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDomainServiceDependency();
            services.AddCoreServiceDependency();

            var retryPolicy = Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .RetryAsync(3);

            services
               .AddHttpClient("InterestTaxApi", c => c.BaseAddress = new Uri(Configuration["ServicesConfiguration:InterestTaxApi:BaseUri"]))
               .AddTypedClient<IInterestTaxClient, InterestTaxClient>()
               .AddPolicyHandler(retryPolicy);

            services.AddSwagger("Calculate Interest API", "v1");

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculate Interest API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
