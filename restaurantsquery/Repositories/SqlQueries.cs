using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantsquery.Repositories
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

        internal const string GetOrders = @"select 
                                            o.Id, os.Status, o.OrderAmount as Amount, o.TransactionId,
                                            o.RestaurantId, r.Name as Restaurant,
                                            o.UserId, u.Name as [User],
                                            o.CreatedDate, o.ModifiedDate
                                            from [Order] o
                                            inner join Restaurants r on r.Id = o.RestaurantId
                                            inner join OrderStatus os on os.Id = o.Status
                                            inner join [User] u on u.Id = o.UserId
                                            where o.UserId = @userId

                                            select op.OrderId, op.ProductId, op.Quantity, op.Price 
                                            from OrderProducts op inner join [Order] o on o.Id = op.OrderId
                                            where o.UserId = @userId";
    }
}
