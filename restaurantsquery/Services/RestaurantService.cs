using CommonModels;
using restaurantsquery.Models;
using restaurantsquery.Repositories.Abstractions;
using restaurantsquery.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquery.Services
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
            try
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
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<RestaurantDetails> GetRestaurantDetailsAsync(int restaurantId)
        {
            try
            {
                RestaurantDetails details = new RestaurantDetails();

                var restaurantDetails = await _restaurantRepository.GetAllRestaurantDetailsAsync(restaurantId);

                details.Id = restaurantDetails.Item1.FirstOrDefault().Id;
                details.Address = restaurantDetails.Item1.FirstOrDefault().Address;
                details.Name = restaurantDetails.Item1.FirstOrDefault().Name;
                details.Rating = restaurantDetails.Item1.FirstOrDefault().Rating;
                details.Owner = restaurantDetails.Item1.FirstOrDefault().Owner;
                details.OpeningHour = restaurantDetails.Item1.FirstOrDefault().OpeningHour;
                details.ClosingHour = restaurantDetails.Item1.FirstOrDefault().ClosingHour;
                details.ContactNumber = restaurantDetails.Item1.FirstOrDefault().ContactNumber;

                restaurantDetails.Item2.GroupBy(detail => new { detail.CategoryId, detail.CategoryName }).Distinct().ToList()
                    .ForEach((category) =>
                    {
                        details.Categories.Add(category.Key.CategoryName);
                    });

                restaurantDetails.Item2.GroupBy(detail => new { detail.SubcategoryId, detail.SubcategoryName }).Distinct().ToList()
                    .ForEach((subcategory) =>
                    {
                        details.SubCategories.Add(subcategory.Key.SubcategoryName);
                    });

                return details;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<List<AllOrderDetails>> GetAllOrdersAsync(int userId)
        {
            try
            {
                List<AllOrderDetails> allOrders = await _restaurantRepository.GetAllOrders(userId);

                return allOrders;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
