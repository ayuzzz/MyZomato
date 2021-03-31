using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels
{
    public class Email
    {
        public Email()
        {
            Host = "smtp.gmail.com";
            Port = 587;
            Username = "joshiayush2426new@gmail.com";
            Password = "P@ssw0RD@123";
            FromAddress = "joshiayush2426new@gmail.com";
            DisplayName = "My Zomato";
        }

        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FromAddress { get; set; }
        public string DisplayName { get; set; }
        public string ToAddress { get; set; }
        public string MessageBody { get; set; }
        public string Subject { get; set; }

    }
}
