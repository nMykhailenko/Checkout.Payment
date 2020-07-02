using Checkout.Domain.Entitities;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Persistence
{
    public class CheckoutDbContext : DbContext
    {
        public CheckoutDbContext(DbContextOptions<CheckoutDbContext> options) : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CheckoutDbContext).Assembly);
        }
    }
}
