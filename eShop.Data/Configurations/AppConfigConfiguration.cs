using Microsoft.EntityFrameworkCore;
using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Data.Configurations
{
    public class AppConfigConfiguration : IEntityTypeConfiguration<AppConfigConfiguration>
    {
        public object Key { get; private set; }
        public object Value { get; private set; }

        public void Configure(EntityTypeBuilder<AppConfigConfiguration> builder)
        {
            builder.ToTable("AppConfigs");
            builder.HasKey(x => x.Key);
            //builder.HasKey(x => x.Value).IsRequired(true);
        }
    }
}
