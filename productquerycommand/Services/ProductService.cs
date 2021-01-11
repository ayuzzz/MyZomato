﻿using CommonModels;
using productquerycommand.Repositories.Abstractions;
using productquerycommand.Services.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productquerycommand.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProductsForRestaurantyAsync(int restaurantId = 0)
        {
            List<Product> allProducts = await _productRepository.GetAllProductsAsync();
            
            if(restaurantId == 0)
            {
                return allProducts.ToList();
            }
            else
            {
                return allProducts.Where(product => product.RestaurantId == restaurantId).ToList();
            }
        }
    }
}
