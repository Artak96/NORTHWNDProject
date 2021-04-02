using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configuration
{
    class OrderDetailsExtendedConfiguration : IEntityTypeConfiguration<OrderDetailsExtended>
    {
        public void Configure(EntityTypeBuilder<OrderDetailsExtended> builder)
        {
            builder.HasNoKey();

            builder.ToView("Order Details Extended");

            builder.Property(e => e.ExtendedPrice).HasColumnType("money");

            builder.Property(e => e.OrderId).HasColumnName("OrderID");

            builder.Property(e => e.ProductId).HasColumnName("ProductID");

            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.UnitPrice).HasColumnType("money");
        }
    }
}
