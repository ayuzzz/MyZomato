using CommonModels;
using CommonUtilities.Abstractions;
using restaurantsquery.Models;
using restaurantsquery.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquery.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ISqlRepository _sqlRepository;

        public RestaurantRepository(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public async Task<List<Restaurant>> GetAllRestaurants(int cityId)
        {
            var restaurants = await _sqlRepository.QueryAsync<Restaurant>(SqlQueries.GetAllRestaurants);
            return restaurants.ToList();
        }

        public async Task<Tuple<IEnumerable<RestaurantDetails>, IEnumerable<CategorySubcategory>>> GetAllRestaurantDetailsAsync(int restaurantId)
        {
            var restaurantsDetails = await _sqlRepository.QueryMultipleAsync<RestaurantDetails, CategorySubcategory>(SqlQueries.GetRestaurantDetails, new { restaurantId });
            return restaurantsDetails;
        }
    }
}
