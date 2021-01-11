using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using productquerycommand.Services.Abstractions;

namespace productquerycommand.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("products-for-restaurant")]
        public async Task<IActionResult> GetAllProductsForRestaurant(int restaurantId)
        {
            if (restaurantId < 0)
                return BadRequest("Invalid restaurant Id");
            else
            {
                return Ok(await _productService.GetAllProductsForRestaurantyAsync(restaurantId));
            }
        }
    }
}
