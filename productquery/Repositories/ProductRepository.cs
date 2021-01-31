using CommonModels;
using CommonUtilities.Abstractions;
using productquery.Repositories.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productquery.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISqlRepository _sqlRepository;

        public ProductRepository(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var productList = await _sqlRepository.QueryAsync<Product>(SqlQueries.GetAllProducts);
            return productList.ToList();
        }
    }
}
