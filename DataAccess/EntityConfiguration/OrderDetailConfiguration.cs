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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails").HasKey(k => k.Id);

            builder.Property(p => p.Quantity);

            builder.HasOne(b => b.Book)
                .WithMany(r => r.OrderDetails)
                .HasForeignKey(b => b.BookId);


            builder.HasOne(o => o.Order)
                .WithMany(r => r.OrderDetails)
                .HasForeignKey(o => o.OrderId);
        }
    }
}
