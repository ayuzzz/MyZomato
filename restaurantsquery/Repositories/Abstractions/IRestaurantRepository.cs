using CommonModels;
using restaurantsquery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquery.Repositories.Abstractions
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetAllRestaurants(int cityId);
        Task<Tuple<IEnumerable<RestaurantDetails>, IEnumerable<CategorySubcategory>>> GetAllRestaurantDetailsAsync(int restaurantId);
        Task<List<AllOrderDetails>> GetAllOrders(int userId);
    }
}
