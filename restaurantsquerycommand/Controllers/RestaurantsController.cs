using System.Threading.Tasks;
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

        [HttpGet]
        [Route("restaurant-details")]
        public async Task<IActionResult> GetRestaurantDetails(int restaurantId)
        {
            if (restaurantId < 0)
                return BadRequest("Invalid restaurant Id");
            else
            {
                return Ok(await _restaurantService.GetRestaurantDetailsAsync(restaurantId));
            }
        }
    }
}