using CommonModels;
using restaurantsquery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantsQuery.Tests
{
    static class MockDataStore
    {
        public static List<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurantList = new List<Restaurant>();

            restaurantList.Add(
                new Restaurant
                {
                    Id = 1000,
                    CityId = 1,
                    Name = "Test Restaurant",
                    Rating = null,
                    Owner = "Test Owner",
                    Cuisine = "Test Cuisine",
                    OpeningHour = null,
                    ClosingHour = null,
                    ContactNumber = "9999999999"
                }
            );

            return restaurantList;
        }

        public static List<City> GetCities()
        {
            List<City> citiesList = new List<City>();

            citiesList.Add(
                new City
                {
                    Id = 1,
                    Name = "Mumbai",
                    State = "Maharashtra",
                    Country = "India"
                }
            );

            return citiesList;
        }


        public static Tuple<IEnumerable<RestaurantDetails>, IEnumerable<CategorySubcategory>> GetAllRestaurantDetails()
        {
            var restaurant = GetRestaurants().FirstOrDefault();

            List<RestaurantDetails> restaurantDetailsList = new List<RestaurantDetails>();
            List<CategorySubcategory> catSubcatList = new List<CategorySubcategory>();

            restaurantDetailsList.Add(
                new RestaurantDetails
                {
                    Id = restaurant.Id,
                    CityId = restaurant.CityId,
                    Name = restaurant.Name,
                    Address = restaurant.Address,
                    Rating = restaurant.Rating,
                    Owner = restaurant.Owner,
                    Cuisine = restaurant.Cuisine,
                    OpeningHour = restaurant.OpeningHour,
                    ClosingHour = restaurant.ClosingHour,
                    ContactNumber = restaurant.ContactNumber
                }
             );

            CategorySubcategory catSubcat = GetCategorySubcategoryDetails().FirstOrDefault();

            catSubcatList.Add(
                new CategorySubcategory
                {
                    CategoryId = catSubcat.CategoryId,
                    CategoryName = catSubcat.CategoryName,
                    SubcategoryId = catSubcat.SubcategoryId,
                    SubcategoryName = catSubcat.SubcategoryName
                }
            );

            return Tuple.Create(restaurantDetailsList.AsEnumerable<RestaurantDetails>(), catSubcatList.AsEnumerable<CategorySubcategory>());

        }

        public static List<AllOrderDetails> GetAllOrders()
        {
            List<AllOrderDetails> allOrderDetailsList = new List<AllOrderDetails>();
            List<OrderProductsList> orderProducts = new List<OrderProductsList>();
            orderProducts.Add(
                new OrderProductsList
                {
                    ProductId = 1000,
                    ProductName = "Waffles",
                    Quantity = 0,
                    Price = 0,
                    OrderId = 10000
                }
            );

            allOrderDetailsList.Add(
                new AllOrderDetails
                {
                    Id = 1,
                    Status = "FoodIsBeingPrepared",
                    Amount = 0,
                    TransactionId = Guid.NewGuid(),
                    PaymentStatus = "Failed",
                    PaymentMode = "Wallet",
                    RestaurantId = 1000,
                    Restaurant = "Huesca Club",
                    UserId = 1,
                    User = "Myzomato Admin",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    OrderProducts = orderProducts
                }
            );

            return allOrderDetailsList;
        }

        public static List<CategorySubcategory> GetCategorySubcategoryDetails()
        {
            List<CategorySubcategory> catSubcat = new List<CategorySubcategory>();
            catSubcat.Add(
                new CategorySubcategory
                {
                    CategoryId = 1000,
                    CategoryName = "Breakfast",
                    SubcategoryId = 1001,
                    SubcategoryName = "North Indian"
                }
            );

            return catSubcat;
        }
    }
}
