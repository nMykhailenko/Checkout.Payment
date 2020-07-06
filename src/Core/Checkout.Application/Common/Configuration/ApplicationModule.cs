using Checkout.Application.Common.Behaviours;
using Checkout.ApplicationConfiguration.Injection.Abstract;
using AutoMapper;
using MediatR;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Checkout.Application.Common.Configuration
{
    /// <summary>
    /// Application module.
    /// </summary>
    public class ApplicationModule : IInjectModule
    {
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

            return services;
        }
    }
}
