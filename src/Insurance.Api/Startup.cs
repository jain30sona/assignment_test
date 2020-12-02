using System;
using Insurance.Core;
using Insurance.Core.Abstraction;
using Insurance.Core.Implementation;
using Insurance.Infrastructure;
using Insurance.Infrastructure.Abstraction;
using Insurance.Infrastructure.Factory;
using Insurance.Infrastructure.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Insurance.Service
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
            services.AddControllers();
            services.AddSingleton<IDataAccessService, DataAccessService>();
            services.AddSingleton<IInsuranceManager, InsuranceManager>();
            services.AddSingleton<IHttpClientFactory, HttpClientFactory>();
            services.AddSingleton<IHttpClientService, HttpClientService>();
            services.AddSingleton<IProductInsurance, ProductLessThan500>();
            services.AddSingleton<IProductInsurance, ProductBetween500To2000>();
            services.AddSingleton<IOrderRuleBuilder, OrderRuleBuilder>();

            var contact = new OpenApiContact()
            {
                Name = "FirstName LastName",
                Email = "user@example.com",
                Url = new Uri("http://www.example.com")
            };

            var license = new OpenApiLicense()
            {
                Name = "My License",
                Url = new Uri("http://www.example.com")
            };

            var info = new OpenApiInfo()
            {
                Version = "v1",
                Title = "Swagger Demo API",
                Description = "Swagger Demo API Description",
                TermsOfService = new Uri("http://www.example.com"),
                Contact = contact,
                License = license
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", info);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Swagger Demo API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
