using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productquerycommand.Repositories
{
    public static class SqlQueries
    {
        internal const string GetAllProducts = @"select p.Id as ProductId, p.ProductName, p.Price,
                                                c.Id as CategoryId, c.Name as Category, sc.Id as SubcategoryId, sc.Name as Subcategory from Product p
                                                inner join CategorySubcategoryMapping csm on csm.Id = p.CuisineId
                                                inner join Category c on c.Id = csm.CategoryId
                                                inner join SubCategory sc on sc.Id = csm.SubcategoryId";
    }
}
