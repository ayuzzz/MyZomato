using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquerycommand.Services.Abstractions
{
    public interface ILocationService
    {
        Task<List<City>> GetCityDetailsAsync(int cityId);
    }
}
