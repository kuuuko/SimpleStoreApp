namespace SimpleStoreApp.Migrations
{
    using SimpleStoreApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleStoreApp.Models.myDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SimpleStoreApp.Models.myDBContext context)
        {
            context.Categories.AddOrUpdate(
                c => c.CategoryName,
                new Category { CategoryId = 1, CategoryName = "Toys", CategoryValidFrom = DateTime.Parse("2000-2-2") },
                new Category { CategoryId = 2, CategoryName = "Tools", CategoryValidFrom = DateTime.Parse("2001-3-3")}
            );
            context.Products.AddOrUpdate(
                p => p.ProductName,
                new Product { ProductCategoryId = 1, ProductName="Ball", ProductPrice = 10.20M, ProductQuantity = 100 , ProductValidFrom = DateTime.Parse("2014-5-6")},
                new Product { ProductCategoryId = 1, ProductName="Bike", ProductPrice = 75.99M, ProductQuantity = 12 , ProductValidFrom = DateTime.Parse("2014-7-9")},
                new Product { ProductCategoryId = 2, ProductName="Hammer", ProductPrice = 15.00M, ProductQuantity = 45 , ProductValidFrom = DateTime.Parse("2014-1-19")},
                new Product { ProductCategoryId = 2, ProductName="Shovel", ProductPrice = 17.00M, ProductQuantity = 45 , ProductValidFrom = DateTime.Parse("2014-7-23")}
            );
        }
    }
}
