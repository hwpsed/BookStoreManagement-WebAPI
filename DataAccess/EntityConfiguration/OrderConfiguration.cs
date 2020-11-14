using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public OrderConfiguration() 
        {
            

        }

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders").HasKey(k => k.Id);

            builder.HasOne(ac => ac.Account)
                .WithMany(r => r.Orders)
                .HasForeignKey(ac => ac.Username);

            builder.HasOne(p => p.Payment)
                .WithMany(a => a.Orders)
                .HasForeignKey(p => p.PaymentId);
        }
    }
}
