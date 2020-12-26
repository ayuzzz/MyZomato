using CommonModels;
using CommonUtilities.Abstractions;
using restaurantsquerycommand.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquerycommand.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private ISqlRepository _sqlRepository;

        public RestaurantRepository(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public async Task<List<Restaurant>> GetAllRestaurants(int cityId)
        {
            var restaurants = await _sqlRepository.QueryAsync<Restaurant>(SqlQueries.GetAllRestaurants);
            return restaurants.ToList();
        }
    }
}
