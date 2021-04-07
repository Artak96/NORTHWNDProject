using NorthWndCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndDAL.Configuration
{
    class CustomerAndSuppliersByCityConfiguration : IEntityTypeConfiguration<CustomerAndSuppliersByCity>
    {
        public void Configure(EntityTypeBuilder<CustomerAndSuppliersByCity> builder)
        {
            builder.HasNoKey();

            builder.ToView("Customer and Suppliers by City");

            builder.Property(e => e.City).HasMaxLength(15);

            builder.Property(e => e.CompanyName).IsRequired().HasMaxLength(40);

            builder.Property(e => e.ContactName).HasMaxLength(30);

            builder.Property(e => e.Relationship).IsRequired().HasMaxLength(9).IsUnicode(false);
        }
    }
}
