using Microsoft.AspNetCore.Mvc;
using restaurantsquery.Services.Abstractions;
using System.Threading.Tasks;

namespace restaurantsquery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class LocationController:ControllerBase
    {
        private ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [Route("cities")]
        public async Task<IActionResult> GetCityDetails(int cityId = 0)
        {
            if(cityId < 0)
            {
                return BadRequest("Invalid City Id");
            }
            else
            {
                return Ok(await _locationService.GetCityDetailsAsync(cityId));
            }
        }
    }
}