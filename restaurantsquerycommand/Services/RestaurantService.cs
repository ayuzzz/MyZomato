using CommonModels;
using restaurantsquerycommand.Repositories.Abstractions;
using restaurantsquerycommand.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquerycommand.Services
{
    public class RestaurantService:IRestaurantService
    {
        private IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<List<Restaurant>> GetRestaurantsForCity(int cityId)
        {
            List<Restaurant> restaurantsForCity = await _restaurantRepository.GetAllRestaurants(cityId);

            if (cityId == 0)
            {
                return restaurantsForCity;
            }
            else
            {
                return restaurantsForCity.Where(restaurant => restaurant.CityId == cityId).ToList();
            }
        }
    }
}
