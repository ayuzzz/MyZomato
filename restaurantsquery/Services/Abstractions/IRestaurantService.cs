using CommonModels;
using restaurantsquery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquery.Services.Abstractions
{
    public interface IRestaurantService
    {
        Task<List<Restaurant>> GetRestaurantsForCity(int cityId);
        Task<RestaurantDetails> GetRestaurantDetailsAsync(int restaurantId);
        Task<List<AllOrderDetails>> GetAllOrdersAsync(int userId);
    }
}