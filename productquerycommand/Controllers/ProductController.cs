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
        [Route("products")]
        public async Task<IActionResult> GetAllProductsForRestaurant(int categoryId)
        {
            if (categoryId < 0)
                return BadRequest("Invalid Category Id");
            else
            {
                return Ok(await _productService.GetAllProductsForCategoryAsync(categoryId));
            }
        }
    }
}
