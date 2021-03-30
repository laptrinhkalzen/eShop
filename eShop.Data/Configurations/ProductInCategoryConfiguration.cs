using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        private object y;

        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(t => new { t.CategoryId, t.ProductId });
            builder.ToTable("ProductInCategories");
            builder.HasOne(t => t.Product).WithMany(y => y.ProductInCategories).HasForeignKey(y => y.ProductId);
            builder.HasOne(t => t.Category).WithMany(y => y.ProductInCategories).HasForeignKey(y => y.CategoryId);
        }

    }
}
