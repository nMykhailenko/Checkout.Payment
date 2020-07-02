using Checkout.ApplicationConfiguration.Injection.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Checkout.PaymentGateway.Configuration.Modules
{
    /// <summary>
    /// Swagger module.
    /// </summary>
    public class SwaggerModule : IInjectModule
    {
        /// <summary>
        /// Load swagger module.
        /// </summary>
        /// <param name="services">Current service collection.</param>
        /// <returns>Updated service collection.</returns>
        public IServiceCollection Load(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Payment Gateway", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
