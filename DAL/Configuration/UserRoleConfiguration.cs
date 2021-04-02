using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RoleName).HasColumnType("VARCHAR(100)");

            builder.HasOne(i => i.User)
                .WithMany(i => i.UserRoles)
                .HasForeignKey(i => i.UserId);

            builder.ToTable("UserRoles");
        }
    }
}
