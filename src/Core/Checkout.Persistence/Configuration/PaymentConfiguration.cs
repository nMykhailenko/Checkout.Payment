using Checkout.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Checkout.Persistence.Configuration
{
    /// <summary>
    /// Payment configuration
    /// </summary>
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.CardInformation);

            builder.HasOne(x => x.Transaction)
                .WithOne(x => x.Payment)
                .HasForeignKey<Transaction>(x => x.PaymentId);
        }
    }
}
