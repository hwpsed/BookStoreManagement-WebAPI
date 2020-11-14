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
    public class BookConfiguration : IEntityTypeConfiguration<Book> 
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books").HasKey(k => k.Id);

            builder.Property(p => p.Title).HasMaxLength(100).IsUnicode();
            builder.Property(p => p.Image);
            builder.Property(p => p.Author).HasMaxLength(50).IsUnicode();
            builder.Property(p => p.Stock);
            builder.Property(p => p.Price);
            builder.Property(p => p.ImportDate);
            builder.Property(p => p.Status);

            builder.HasOne(c => c.Category)
                .WithMany(b => b.Books)
                .HasForeignKey(c => c.CategoryId);
        }
    }
}
