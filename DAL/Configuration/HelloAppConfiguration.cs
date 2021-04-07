using NorthWndCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndDAL.Configuration
{
    class HelloAppConfiguration : IEntityTypeConfiguration<HelloApp>
    {
        public void Configure(EntityTypeBuilder<HelloApp> builder)
        {
            builder.HasNoKey();

            builder.ToTable("HelloApp");

            builder.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsFixedLength(true);

            builder.Property(e => e.LastName)
                .HasMaxLength(20)
                .HasColumnName("LAstName")
                .IsFixedLength(true);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
