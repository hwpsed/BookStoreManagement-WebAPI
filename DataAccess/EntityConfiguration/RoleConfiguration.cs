using DataAccess.Database;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.EntityConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //primary key
            builder.ToTable("Roles").HasKey(r => r.Id);

            //config 
            builder.Property(p => p.Name).HasMaxLength(50).IsUnicode();
        }
    }
}
