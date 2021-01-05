using CommonModels;
using CommonUtilities.Abstractions;
using restaurantsquerycommand.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquerycommand.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private ISqlRepository _sqlRepository;

        public LocationRepository(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public async Task<List<City>> GetCityDetailsAsync()
        {
            IEnumerable<City> cityList = await _sqlRepository.QueryAsync<City>(SqlQueries.GetCityDetails);

            return cityList.ToList();
        }
    }
}
