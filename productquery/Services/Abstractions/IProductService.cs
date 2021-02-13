﻿using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productquery.Services.Abstractions
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsForRestaurantyAsync(int restaurantId = 0);
    }
}