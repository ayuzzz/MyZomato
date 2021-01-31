using CommonModels;
using Microsoft.AspNetCore.Mvc;
using orderscommand.Services.Abstractions;
using System.Threading.Tasks;

namespace orderscommand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if(order is null)
            {
                return BadRequest("Invalid order");
            }
            else
            {
                return Ok(await _orderService.CreateOrderAsync(order));
            }
        }
    }
}