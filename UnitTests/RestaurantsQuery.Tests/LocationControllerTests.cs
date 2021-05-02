using Microsoft.AspNetCore.Mvc;
using Moq;
using restaurantsquery.Controllers;
using restaurantsquery.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantsQuery.Tests
{
    public class LocationControllerTests
    {
        private Mock<ILocationService> _locationService;
        private LocationController _controller;

        public LocationControllerTests()
        {
            _locationService = new Mock<ILocationService>();
            _locationService.Setup(loc => loc.GetCityDetailsAsync(It.IsAny<int>())).ReturnsAsync(MockDataStore.GetCities());

            _controller = new LocationController(_locationService.Object);
        }

        [Fact]
        public async Task ToValidate_RestaurantDetails_InvalidCity()
        {
            int cityId = -1;
            var response = await _controller.GetCityDetails(cityId);

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task ToValidate_RestaurantDetails_ValidCity(int cityId)
        {
            var response = await _controller.GetCityDetails(cityId);

            Assert.IsNotType<BadRequestObjectResult>(response);
        }
    }
}
