using System;
using eShopSolution.Data.Entities;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eShop.Data.Enums;

namespace eShop.Data.Configurations
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
            throw new NotImplementedException();
        }
    }
}
