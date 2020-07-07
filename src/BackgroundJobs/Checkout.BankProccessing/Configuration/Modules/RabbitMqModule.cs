using Checkout.ApplicationConfiguration.Injection.Abstract;
using Checkout.Models.Options;
using Checkout.BankProccessing.Core.Workers;
using Checkout.BankProccessing.Core.Bank.Contract;
using Checkout.BankProccessing.Core.Bank;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Checkout.BankProccessing.Core.Consumers;

namespace Checkout.BankProccessing.Configuration.Modules
{
    /// <summary>
    /// RabbitMQ module.
    /// </summary>
    public class RabbitMqModule : IInjectModule
    {
        private readonly IConfiguration _configuration;
        public RabbitMqModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Load RabbitMQ module.
        /// </summary>
        /// <param name="services">Current service collection.</param>
        /// <returns>Updated service collection.</returns>
        public IServiceCollection Load(IServiceCollection services)
        {
            var rabbitMqOptions = _configuration.GetSection(nameof(RabbitMqOptions)).Get<RabbitMqOptions>();
            services.Configure<RabbitMqOptions>(x => _configuration.GetSection(nameof(RabbitMqOptions)).Bind(x));

            services.AddHostedService<PaymentWorker>();
            services.AddTransient<IBankService, BankService>();

            services.AddMassTransit(c =>
            {
                c.AddConsumer<PaymentCreatedConsumer>();
            });

            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(rabbitMqOptions.Hostname, rabbitMqOptions.VirtualHost, h =>
                {
                    h.Username(rabbitMqOptions.Username);
                    h.Password(rabbitMqOptions.Password);
                });

                cfg.ExchangeType = ExchangeType.Direct;
            }));


            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());

            return services;
        }
    }
}
