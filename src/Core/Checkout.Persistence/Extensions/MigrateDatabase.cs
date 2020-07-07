using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace Checkout.Persistence.Extensions
{
    /// <summary>
    /// Migration manager.
    /// </summary>
    public static class MigrationManager
    {
        /// <summary>
        /// Migrate database
        /// </summary>
        /// <param name="host">Current host.</param>
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<CheckoutDbContext>();
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return host;
        }
    }
}
