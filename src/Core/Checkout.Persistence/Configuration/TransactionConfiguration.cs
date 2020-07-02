using Checkout.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Persistence.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(x => x.Payment)
                .WithOne(x => x.Transaction)
                .HasForeignKey<Payment>(x => x.TransactionId);
        }
    }
}
