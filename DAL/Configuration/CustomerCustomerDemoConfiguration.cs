using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configuration
{
    class CustomerCustomerDemoConfiguration : IEntityTypeConfiguration<CustomerCustomerDemo>
    {
        public void Configure(EntityTypeBuilder<CustomerCustomerDemo> builder)
        {
            builder.HasKey(e => new { e.CustomerId, e.CustomerTypeId }).IsClustered(false);

            builder.ToTable("CustomerCustomerDemo");

            builder.Property(e => e.CustomerId).HasMaxLength(5).HasColumnName("CustomerID").IsFixedLength(true);

            builder.Property(e => e.CustomerTypeId).HasMaxLength(10).HasColumnName("CustomerTypeID").IsFixedLength(true);

            builder.HasOne(d => d.Customer).WithMany(p => p.CustomerCustomerDemos).HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerCustomerDemo_Customers");

            builder.HasOne(d => d.CustomerType).WithMany(p => p.CustomerCustomerDemos).HasForeignKey(d => d.CustomerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerCustomerDemo");
        }
    }
}
