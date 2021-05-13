using Microsoft.AspNetCore.Mvc;
using Moq;
using restaurantsquery.Repositories.Abstractions;
using restaurantsquery.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantsQuery.Tests
{
    public class RestaurantServiceTests
    {
        private Mock<IRestaurantRepository> _restaurantRepo;
        private RestaurantService _restaurantService;

        public RestaurantServiceTests()
        {
            _restaurantRepo = new Mock<IRestaurantRepository>();
            _restaurantRepo.Setup(res => res.GetAllRestaurants(It.IsAny<int>())).ReturnsAsync(MockDataStore.GetRestaurants());
            _restaurantRepo.Setup(res => res.GetAllRestaurantDetailsAsync(It.IsAny<int>())).ReturnsAsync(MockDataStore.GetAllRestaurantDetails());
            _restaurantRepo.Setup(res => res.GetAllOrders(It.IsAny<int>())).ReturnsAsync(MockDataStore.GetAllOrders());

            _restaurantService = new RestaurantService(_restaurantRepo.Object);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task RestaurantsForCity_ValidCity_NoException(int cityId)
        {
            var response = await _restaurantService.GetRestaurantsForCity(cityId);

            Assert.NotNull(response);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1000)]
        public async Task RestaurantDetails_ValidRestaurant_NoException(int restaurantId)
        {
            var response = await _restaurantService.GetRestaurantDetailsAsync(restaurantId);

            Assert.NotNull(response);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task AllOrders_ValidCity_NoException(int userId)
        {
            var response = await _restaurantService.GetAllOrdersAsync(userId);

            Assert.NotNull(response);
        }
    }
}
