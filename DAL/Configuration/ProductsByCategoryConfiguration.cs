using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configuration
{
    class ProductsByCategoryConfiguration : IEntityTypeConfiguration<ProductsByCategory>
    {
        public void Configure(EntityTypeBuilder<ProductsByCategory> builder)
        {
            builder.HasNoKey();

            builder.ToView("Products by Category");

            builder.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.QuantityPerUnit).HasMaxLength(20);
        }
    }
}
