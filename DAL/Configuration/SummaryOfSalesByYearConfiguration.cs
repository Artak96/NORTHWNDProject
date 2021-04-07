using NorthWndCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndDAL.Configuration
{
    class SummaryOfSalesByYearConfiguration : IEntityTypeConfiguration<SummaryOfSalesByYear>
    {
        public void Configure(EntityTypeBuilder<SummaryOfSalesByYear> builder)
        {
            builder.HasNoKey();

            builder.ToView("Summary of Sales by Year");

            builder.Property(e => e.OrderId).HasColumnName("OrderID");

            builder.Property(e => e.ShippedDate).HasColumnType("datetime");

            builder.Property(e => e.Subtotal).HasColumnType("money");
        }
    }
}
