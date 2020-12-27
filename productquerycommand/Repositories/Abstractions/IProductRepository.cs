using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productquerycommand.Repositories.Abstractions
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
    }
}
