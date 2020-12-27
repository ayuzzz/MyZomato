using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productquerycommand.Services.Abstractions
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsForCategoryAsync(int categoryId);
    }
}
