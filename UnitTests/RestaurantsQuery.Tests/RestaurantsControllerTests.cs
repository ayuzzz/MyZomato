using CommonModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using restaurantsquery.Controllers;
using restaurantsquery.Services.Abstractions;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantsQuery.Tests
{
    public class RestaurantsControllerTests
    {
        private Mock<IRestaurantService> _restaurantService;
        private RestaurantsController _controller;

        public RestaurantsControllerTests()
        {
            _restaurantService = new Mock<IRestaurantService>();
            _restaurantService.Setup(res => res.GetRestaurantsForCity(It.IsAny<int>())).ReturnsAsync(MockDataStore.GetRestaurants());

            _controller = new RestaurantsController(_restaurantService.Object);
        }

        [Fact]
        public async Task ToValidate_RestaurantDetails_InvalidCity()
        {
            int cityId = -1;
            var response = await _controller.GetAllRestaurantsForCityAsync(cityId);

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task ToValidate_RestaurantDetails_ValidCity(int cityId)
        {
            var response = await _controller.GetAllRestaurantsForCityAsync(cityId);

            Assert.IsNotType<BadRequestObjectResult>(response);
        }
    }
}
