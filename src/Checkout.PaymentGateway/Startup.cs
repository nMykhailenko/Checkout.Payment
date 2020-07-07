using Checkout.ApplicationConfiguration.Injection;
using Checkout.PaymentGateway.Configuration.Modules;
using Checkout.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Checkout.Filters;
using Checkout.Persistence.Modules.Sql;
using Checkout.Application.Common.Configuration;
using FluentValidation.AspNetCore;
using Newtonsoft.Json.Converters;
using Checkout.PaymentGateway.Workers;

namespace Checkout.PaymentGateway
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets or sets configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <inheritdoc/>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            services.AddMvc(options => { options.Filters.Add<ValidationFilter>(); })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ApplicationModule>());

            services.RegisterModule(new SwaggerModule())
                .RegisterModule(new SqlModule(Configuration))
                .RegisterModule(new ApplicationModule(Configuration));

            services.AddHostedService<GatewayWorker>();
        }

        /// <inheritdoc/>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerModule();
            app.UseExceptionHandlerMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
