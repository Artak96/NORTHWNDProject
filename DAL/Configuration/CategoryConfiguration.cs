using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configuration
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(e => e.CategoryName, "CategoryName");

            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

            builder.Property(e => e.CategoryName).IsRequired().HasMaxLength(15);

            builder.Property(e => e.Description).HasColumnType("ntext");

            builder.Property(e => e.Picture).HasColumnType("image");
        }
    }
}
