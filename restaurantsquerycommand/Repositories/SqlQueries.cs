using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquerycommand.Repositories
{
    public class SqlQueries
    {
        internal const string GetAllRestaurants = @"with distinct_cuisines as
                                                    (
	                                                    select distinct pr.RestaurantId, sc.Name from ProductRestaurant pr
	                                                    inner join Product p on p.Id = pr.ProductId
	                                                    inner join CategorySubcategoryMapping csm on csm.Id = p.CuisineId
	                                                    inner join SubCategory sc on sc.Id = csm.SubcategoryId
                                                    )
                                                    , restaurantDetails as
                                                    (
	                                                    select Id ,CityId ,Name ,Address ,Rating ,Owner ,OpeningHour ,ClosingHour ,ContactNumber
	                                                    from Restaurants
                                                    )
                                                    select rd.Id, AVG(rd.CityId) as CItyId , rd.Name , rd.Address , AVG(rd.Rating) as Rating
                                                    , rd.Owner , AVG(rd.OpeningHour) as OpeningHour , AVG(rd.ClosingHour) as ClosingHour
                                                    , rd.ContactNumber, STRING_AGG(dc.Name, ', ') as Cuisine
                                                    from distinct_cuisines dc
                                                    inner join restaurantDetails rd on rd.Id = dc.RestaurantId
                                                    Group by rd.Id, rd.Name, rd.Address, rd.Owner, rd.ContactNumber";

        internal const string GetCityDetails = @"select Id, Name, State, Country from
                                                 City";

        internal const string GetRestaurantDetails = @"select r.Id, c.Id as CityId, r.Name, r.Address, r.Rating, r.Owner,
                                                        r.OpeningHour, r.ClosingHour, r.ContactNumber 
                                                        from Restaurants r inner join City c on c.Id = r.cityId
                                                        where r.Id = @restaurantId

                                                        select distinct c.Id as CategoryId, c.Name as CategoryName
                                                        , sc.Id as SubcategoryId, sc.Name as SubcategoryName
                                                        from Restaurants r inner join ProductRestaurant pr on pr.RestaurantId = r.Id
                                                        inner join Product p on p.Id = pr.ProductId
                                                        inner join CategorySubcategoryMapping csm on csm.Id = p.CuisineId
                                                        inner join Category c on c.Id = csm.CategoryId
                                                        inner join SubCategory sc on sc.Id = csm.SubcategoryId
                                                        where r.Id = @restaurantId";
        
    }
}
