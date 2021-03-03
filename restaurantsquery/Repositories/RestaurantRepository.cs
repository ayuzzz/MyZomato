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

        public async Task<List<AllOrderDetails>> GetAllOrders(int userId)
        {
            var orderDetails = await _sqlRepository.QueryMultipleAsync<AllOrderDetails, OrderProductsList>(SqlQueries.GetOrders, new { userId = userId });

            var allOrders = orderDetails.Item1;
            var orderProducts = orderDetails.Item2;

            foreach(var order in allOrders)
            {
                order.OrderProducts = new List<OrderProductsList>();
                order.OrderProducts.AddRange(orderProducts.Where(o => o.OrderId == order.Id));
            }

            return allOrders.ToList();
        }
    }
}
