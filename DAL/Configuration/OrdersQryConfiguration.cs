using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configuration
{
    class OrdersQryConfiguration : IEntityTypeConfiguration<OrdersQry>
    {
        public void Configure(EntityTypeBuilder<OrdersQry> builder)
        {
            builder.HasNoKey();

            builder.ToView("Orders Qry");

            builder.Property(e => e.Address).HasMaxLength(60);

            builder.Property(e => e.City).HasMaxLength(15);

            builder.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Country).HasMaxLength(15);

            builder.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .HasColumnName("CustomerID")
                .IsFixedLength(true);

            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            builder.Property(e => e.Freight).HasColumnType("money");

            builder.Property(e => e.OrderDate).HasColumnType("datetime");

            builder.Property(e => e.OrderId).HasColumnName("OrderID");

            builder.Property(e => e.PostalCode).HasMaxLength(10);

            builder.Property(e => e.Region).HasMaxLength(15);

            builder.Property(e => e.RequiredDate).HasColumnType("datetime");

            builder.Property(e => e.ShipAddress).HasMaxLength(60);

            builder.Property(e => e.ShipCity).HasMaxLength(15);

            builder.Property(e => e.ShipCountry).HasMaxLength(15);

            builder.Property(e => e.ShipName).HasMaxLength(40);

            builder.Property(e => e.ShipPostalCode).HasMaxLength(10);

            builder.Property(e => e.ShipRegion).HasMaxLength(15);

            builder.Property(e => e.ShippedDate).HasColumnType("datetime");
        }
    }
}
