using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int SubcategoryId { get; set; }
        public string Subcategory { get; set; }
        public int RestaurantId { get; set; }
    }
}
