using NorthWndCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndDAL.Configuration
{
    class CustomerDemographicConfiguration : IEntityTypeConfiguration<CustomerDemographic>
    {
        public void Configure(EntityTypeBuilder<CustomerDemographic> builder)
        {
            builder.HasKey(e => e.CustomerTypeId).IsClustered(false);

            builder.Property(e => e.CustomerTypeId).HasMaxLength(10).HasColumnName("CustomerTypeID").IsFixedLength(true);

            builder.Property(e => e.CustomerDesc).HasColumnType("ntext");

        }
    }
}
