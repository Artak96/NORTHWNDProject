using NorthWndCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndDAL.Configuration
{
    class CurrentProductListConfiguration : IEntityTypeConfiguration<CurrentProductList>
    {
        public void Configure(EntityTypeBuilder<CurrentProductList> builder)
        {
            builder.HasNoKey();

            builder.ToView("Current Product List");

            builder.Property(e => e.ProductId).ValueGeneratedOnAdd().HasColumnName("ProductID");

            builder.Property(e => e.ProductName).IsRequired().HasMaxLength(40);
        }
    }
}
