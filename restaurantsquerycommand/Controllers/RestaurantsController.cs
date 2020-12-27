using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using restaurantsquerycommand.Services.Abstractions;

namespace restaurantsquerycommand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        [Route("restaurants")]
        public async Task<IActionResult> GetAllRestaurantsForCityAsync(int cityId)
        {
            if (cityId < 0)
                return BadRequest("Invalid City Id");
            else
            {
                return Ok(await _restaurantService.GetRestaurantsForCity(cityId));
            }
        }
    }
}