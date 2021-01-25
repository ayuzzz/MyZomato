﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CommonModels.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using productquerycommand.Application.ServiceBus.Abstractions;
using productquerycommand.Services.Abstractions;

namespace productquerycommand.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private readonly IBusControl _bus;
        private readonly IOrderCreatedService _orderCreatedService;

        public ProductController(IProductService productService, IBusControl bus, IOrderCreatedService orderCreatedService)
        {
            _productService = productService;
            _bus = bus;
            _orderCreatedService = orderCreatedService;
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

        [HttpGet]
        [Route("sample")]
        public async Task<IActionResult> SampleApi()
        {
            try
            {
                //var endpoint = await _bus.GetSendEndpoint(new Uri("rabbitmq://localhost/order-created"));
                //await endpoint.Send<OrderCreatedEvent>(new 
                //{
                //    Id = Guid.NewGuid()
                //});
                await _orderCreatedService.PublishThroughEventBus(new OrderCreatedEvent { Id = Guid.NewGuid() });

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return Ok();
        }
    }
}
