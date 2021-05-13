using CommonModels;
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
    public class LocationServiceTests
    {
        private Mock<ILocationRepository> _locationRepo;
        private LocationService _locationService;

        public LocationServiceTests()
        {
            _locationRepo = new Mock<ILocationRepository>();
            _locationRepo.Setup(l => l.GetCityDetailsAsync()).ReturnsAsync(MockDataStore.GetCities());

            _locationService = new LocationService(_locationRepo.Object);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public async Task ToValidate_CityDetails_ExceptionNotThrown(int cityId)
        {
            var response = await _locationService.GetCityDetailsAsync(cityId);

            Assert.NotNull(response);
        }
    }
}
