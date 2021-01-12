using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquerycommand.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        
    }

    public class Subcategory
    {
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
    }

    public class CategorySubcategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
    }
}
