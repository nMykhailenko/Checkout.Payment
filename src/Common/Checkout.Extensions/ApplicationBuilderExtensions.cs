using Checkout.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Checkout.Extensions
{
    /// <summary>
    /// Application builder extensions.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Use swagger.
        /// </summary>
        /// <param name="applicationBuilder">Current application builder.</param>
        /// <returns>Updated application builder.</returns>
        public static IApplicationBuilder UseSwaggerModule(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment Gateway");
            });

            return applicationBuilder;
        }

        /// <summary>
        /// Use exception handler middleware.
        /// </summary>
        /// <param name="applicationBuilder">Current application builder.</param>
        /// <returns>Update application builder.</returns>
        public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
