using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquerycommand.Repositories.Abstractions
{
    public interface ILocationRepository
    {
        Task<List<City>> GetCityDetailsAsync();
    }
}
