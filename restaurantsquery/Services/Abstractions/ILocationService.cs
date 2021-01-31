using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquery.Services.Abstractions
{
    public interface ILocationService
    {
        Task<List<City>> GetCityDetailsAsync(int cityId);
    }
}
