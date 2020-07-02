using Microsoft.EntityFrameworkCore;

namespace Checkout.Persistence
{
    public class CheckoutDbContextFactory : DesignTimeDbContextFactoryBase<CheckoutDbContext>
    {
        protected override CheckoutDbContext CreateNewInstance(DbContextOptions<CheckoutDbContext> options)
        {
            return new CheckoutDbContext(options);
        }
    }
}
