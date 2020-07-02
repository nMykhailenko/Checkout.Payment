using Microsoft.Extensions.DependencyInjection;

namespace Checkout.ApplicationConfiguration.Injection.Abstract
{
    /// <summary>
    /// Inject module.
    /// </summary>
    public interface IInjectModule
    {
        /// <summary>
        /// Load dependecies.
        /// </summary>
        /// <param name="services">Current service collection.</param>
        /// <returns>Updated service collection.</returns>
        IServiceCollection Load(IServiceCollection services);
    }
}
