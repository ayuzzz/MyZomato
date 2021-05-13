using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagementQuery.Tests
{
    static class MockDataStore
    {
        public static List<UserDetails> GetUserDetails()
        {
            List<UserDetails> userList = new List<UserDetails>();

            userList.Add(
                new UserDetails
                {
                    UserId = 1,
                    Name = "Test User",
                    Email = "xyz@myzomato.com",
                    ContactNumber = "9999999999",
                    WalletBalance = 0
                }
            );

            return userList;
        }
    }
}
