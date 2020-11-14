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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts").HasKey(k => k.Username);

            builder.Property(p => p.Username).HasMaxLength(50);
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(50).HasMaxLength(50).IsUnicode();

            //Account n-1 Role
            builder.HasOne(ac => ac.Role)
                .WithMany(r => r.Accounts)
                .HasForeignKey(ac => ac.RoleId);
        }
    }
}
