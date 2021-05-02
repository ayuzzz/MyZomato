using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductQuery.Tests
{
    static class MockDataStore
    {
        public static List<Product>  GetAllProductsForRestaurant()
        {
            List<Product> products = new List<Product>();

            products.Add(
                new Product
                {
                    Id = 1000,
                    ProductName = "Waffles",
                    Price = 0,
                    CategoryId = 0,
                    Category = "Bakery",
                    SubcategoryId = 0,
                    Subcategory = "Snacks",
                    RestaurantId = 1000
                }
            );

            return products;
        }
    }
}
