﻿using eShop.Data.Enums;
using eShopSolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is home page eShop"},
                new AppConfig() { Key = "HomeKeyword", Value = "This is home keyword eShop" },
                new AppConfig() { Key = "HomeDesc", Value = "This is desc page eShop" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng việt", IsDefault = true},
                new Language() { Id = "en-US", Name = "English", IsDefault = false}
                );

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, IsShowOnHome = true, ParentId = null, SortOrder = 1, Status = Enums.Status.Active},
                new Category() { Id = 2, IsShowOnHome = true, ParentId = null, SortOrder = 2, Status = Enums.Status.Active}
                );


            modelBuilder.Entity<CategoryTranslation>().HasData(
                    new CategoryTranslation(){ Id=1, CategoryId=1, Name="Áo nữ", LanguageId="vi-VN",SeoAlias="ao-nu",SeoDescription="Sản phẩm thời trang nữ",SeoTitle=""},
                    new CategoryTranslation(){ Id = 2, CategoryId =1, Name="Woman shirt", LanguageId="en-US",SeoAlias="woman-shirt",SeoDescription="The shirt for woman",SeoTitle=""},
                    new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm thời trang nam", SeoTitle = "" },
                    new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Man shirt", LanguageId = "en-US", SeoAlias = "man-shirt", SeoDescription = "The shirt for man", SeoTitle = "" }
                );

           

            modelBuilder.Entity<Product>().HasData(
              new Product() { Id = 1, DateCreated= DateTime.Now, OriginalPrice = 100000, Price = 200000, Stock = 0, ViewCount = 0 } 
              );

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() {ProductId=1, CategoryId = 1 }
                );

            modelBuilder.Entity<ProductTranslation>().HasData(
                  new ProductTranslation() {Id= 1, ProductId = 1, Name = "Áo sơ mi nam", LanguageId = "vi-VN", SeoAlias = "ao-so-mi-nam", SeoDescription = "Áo sơ mi nam", SeoTitle = "Áo sơ mi nam", Description = "" },
                  new ProductTranslation() {Id= 2,  ProductId = 1, Name = "Men T-shirt", LanguageId = "en-US", SeoAlias = "men-t-shirt", SeoDescription = "The t-shirt for man", SeoTitle = "The t-shirt for man", Description = "" }
                );

            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator R  ole"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "tiendat@gmail.com",
                NormalizedEmail = "tiendat@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456"),
                SecurityStamp = string.Empty,
                FirstName = "Toan",
                LastName = "Bach",
                Dob = new DateTime(2021, 01, 28)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

        }
    }
}
