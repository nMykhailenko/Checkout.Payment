﻿using Checkout.Application.Common.Behaviours;
using Checkout.ApplicationConfiguration.Injection.Abstract;
using Checkout.Models.Options;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using MassTransit;
using RabbitMQ.Client;
using Checkout.Application.Payments.Commands.UpdatePayment;

namespace Checkout.Application.Common.Configuration
{
    /// <summary>
    /// Application module.
    /// </summary>
    public class ApplicationModule : IInjectModule
    {
        private readonly IConfiguration _configuration;
        public ApplicationModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Load application module dependecies.
        /// </summary>
        /// <param name="services">Current service collection.</param>
        /// <returns></returns>
        public IServiceCollection Load(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services = LoadRabbitMq(services);

            return services;
        }

        private IServiceCollection LoadRabbitMq(IServiceCollection services)
        {
            var rabbitMqOptions = _configuration.GetSection(nameof(RabbitMqOptions)).Get<RabbitMqOptions>();
            services.Configure<RabbitMqOptions>(x => _configuration.GetSection(nameof(RabbitMqOptions)).Bind(x));

            services.AddMassTransit(c =>
            {
                c.AddConsumer<UpdatePaymentEventConsumer>();
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
