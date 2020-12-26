using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquerycommand.Services.Abstractions
{
    public interface IRestaurantService
    {
        Task<List<Restaurant>> GetRestaurantsForCity(int cityId);
    }
}