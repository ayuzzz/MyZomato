using CommonModels;
using restaurantsquery.Repositories.Abstractions;
using restaurantsquery.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquery.Services
{
    public class LocationService : ILocationService
    {
        private ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<City>> GetCityDetailsAsync(int cityId)
        {
            if(cityId == 0)
            {
                return await _locationRepository.GetCityDetailsAsync();
            }
            else
            {
                List<City> cityList = await _locationRepository.GetCityDetailsAsync();
                return cityList.Where(city => city.Id == cityId).ToList();
            }
        }
    }
}
