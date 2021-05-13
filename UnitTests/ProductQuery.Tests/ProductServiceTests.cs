using CommonModels;
using Moq;
using productquery.Repositories.Abstractions;
using productquery.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductQuery.Tests
{
    public class ProductServiceTests
    {
        private Mock<IProductRepository> _productRepo;
        private ProductService _productService;

        public ProductServiceTests()
        {
            _productRepo = new Mock<IProductRepository>();
            _productRepo.Setup(prepo => prepo.GetAllProductsAsync()).ReturnsAsync(MockDataStore.GetAllProductsForRestaurant());

            _productService = new ProductService(_productRepo.Object);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1000)]
        public async Task GetAllProductsForRestaurants_ValidRestaurant_ValidOutput(int restaurantId)
        {
            var response = await _productService.GetAllProductsForRestaurantsAsync(restaurantId);

            Assert.IsType<List<Product>>(response);
        }

        [Fact]
        public async Task GetAllProductsForRestaurants_InvalidRestaurant_InvalidOutput()
        {
            int restaurantId = -1000;

            if(restaurantId < 0)
            {
                _productRepo.Setup(prepo => prepo.GetAllProductsAsync())
                        .Throws(new NullReferenceException());
            }           

            var response = await _productService.GetAllProductsForRestaurantsAsync(restaurantId);

            Assert.Null(response);
        }
    }
}
