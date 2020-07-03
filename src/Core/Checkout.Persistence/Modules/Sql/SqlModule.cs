using Checkout.ApplicationConfiguration.Injection.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.Persistence.Modules.Sql
{
    /// <summary>
    /// SQL module.
    /// </summary>
    public class SqlModule : IInjectModule
    {
        private readonly IConfiguration _configuration;

        public SqlModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Load SQL module.
        /// </summary>
        /// <param name="services">Current service collection.</param>
        /// <returns>Updated service collection.</returns>
        public IServiceCollection Load(IServiceCollection services)
        {
            var sqlSettings = _configuration.GetSection(nameof(SqlConnectionSettings)).Get<SqlConnectionSettings>();
            services.Configure<SqlConnectionSettings>(x => _configuration.GetSection(nameof(SqlConnectionSettings)).Bind(x));

            services.AddDbContext<CheckoutDbContext>(options =>
                options.UseSqlServer(sqlSettings.DefaultConnection, _ => _.EnableRetryOnFailure()));

            return services;
        }
    }
}
