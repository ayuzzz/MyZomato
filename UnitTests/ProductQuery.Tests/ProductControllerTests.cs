using Microsoft.AspNetCore.Mvc;
using Moq;
using productquery.Controllers;
using productquery.Services.Abstractions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProductQuery.Tests
{
    public class ProductControllerTests
    {
        private Mock<IProductService> _productService;
        private ProductController _controller;

        public ProductControllerTests()
        {
            _productService = new Mock<IProductService>();
            _productService.Setup(p => p.GetAllProductsForRestaurantsAsync(It.IsAny<int>())).ReturnsAsync(MockDataStore.GetAllProductsForRestaurant());

            _controller = new ProductController(_productService.Object);
        }

        [Fact]
        public async Task ToValidate_AllProductsForRestaurant_InvalidRestaurant()
        {
            int restaurantId = -1000;

            var response = await _controller.GetAllProductsForRestaurant(restaurantId);

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1000)]
        public async Task ToValidate_AllProductsForRestaurant_ValidRestaurant(int restaurantId)
        {
            var response = await _controller.GetAllProductsForRestaurant(restaurantId);

            Assert.NotNull(response);
        }
    }
}
