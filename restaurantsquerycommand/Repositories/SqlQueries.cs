using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquerycommand.Repositories
{
    public class SqlQueries
    {
        internal const string GetAllRestaurants = @"select Id ,CityId ,Name ,Address ,Rating ,Owner ,OpeningHour ,ClosingHour ,ContactNumber
                                                    from Restaurants";
    }
}
