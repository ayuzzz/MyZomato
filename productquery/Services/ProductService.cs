using CommonModels;
using productquery.Repositories.Abstractions;
using productquery.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productquery.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProductsForRestaurantsAsync(int restaurantId = 0)
        {
            try
            {
                List<Product> allProducts = await _productRepository.GetAllProductsAsync();

                if (restaurantId == 0)
                {
                    return allProducts.ToList();
                }
                else
                {
                    return allProducts.Where(product => product.RestaurantId == restaurantId).ToList();
                }
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
