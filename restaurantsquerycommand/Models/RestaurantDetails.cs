using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquerycommand.Models
{
    public class RestaurantDetails:Restaurant
    {
        public List<string> Categories { get; set; }
        public List<string> SubCategories { get; set; }

        public RestaurantDetails()
        {
            Categories = new List<string>();
            SubCategories = new List<string>();
        }
    }
}
