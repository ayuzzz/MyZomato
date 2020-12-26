using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquerycommand.Repositories.Abstractions
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetAllRestaurants(int cityId);
    }
}
