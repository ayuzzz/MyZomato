using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CommonModels.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using productquery.Application.ServiceBus.Abstractions;
using productquery.Services.Abstractions;

namespace productquery.Controllers
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

        //[HttpGet]
        //[Route("sample")]
        //public async Task<IActionResult> SampleApi()
        //{
        //    try
        //    {
        //        //var endpoint = await _bus.GetSendEndpoint(new Uri("rabbitmq://localhost/order-created"));
        //        //await endpoint.Send<OrderCreatedEvent>(new 
        //        //{
        //        //    Id = Guid.NewGuid()
        //        //});
        //        await _orderCreatedService.PublishThroughEventBus(new OrderCreatedEvent { Id = Guid.NewGuid() });

        //    }
        //    catch(Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }

        //    return Ok();
        //}
    }
}
