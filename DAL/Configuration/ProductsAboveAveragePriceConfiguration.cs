using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configuration
{
    class ProductsAboveAveragePriceConfiguration : IEntityTypeConfiguration<ProductsAboveAveragePrice>
    {
        public void Configure(EntityTypeBuilder<ProductsAboveAveragePrice> builder)
        {

            builder.HasNoKey();

            builder.ToView("Products Above Average Price");

            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.UnitPrice).HasColumnType("money");
        }
    }
}
