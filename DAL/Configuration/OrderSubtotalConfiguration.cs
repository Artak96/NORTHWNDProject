using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configuration
{
    class OrderSubtotalConfiguration : IEntityTypeConfiguration<OrderSubtotal>
    {
        public void Configure(EntityTypeBuilder<OrderSubtotal> builder)
        {
            builder.HasNoKey();

            builder.ToView("Order Subtotals");

            builder.Property(e => e.OrderId).HasColumnName("OrderID");

            builder.Property(e => e.Subtotal).HasColumnType("money");
        }
    }
}
