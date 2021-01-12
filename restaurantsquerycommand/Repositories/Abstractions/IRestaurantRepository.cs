using CommonModels;
using restaurantsquerycommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquerycommand.Repositories.Abstractions
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetAllRestaurants(int cityId);
        Task<Tuple<IEnumerable<RestaurantDetails>, IEnumerable<CategorySubcategory>>> GetAllRestaurantDetailsAsync(int restaurantId);
    }
}
