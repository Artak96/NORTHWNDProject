using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configuration
{
    class SalesTotalsByAmountConfiguration : IEntityTypeConfiguration<SalesTotalsByAmount>
    {
        public void Configure(EntityTypeBuilder<SalesTotalsByAmount> builder)
        {
            builder.HasNoKey();

            builder.ToView("Sales Totals by Amount");

            builder.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.OrderId).HasColumnName("OrderID");

            builder.Property(e => e.SaleAmount).HasColumnType("money");

            builder.Property(e => e.ShippedDate).HasColumnType("datetime");
        }
    }
}
