using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels
{
    public class FullOrderDetails
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public int OrderAmount { get; set; }
        public Guid TransactionId { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMode { get; set; }
        public int RestaurantId { get; set; }
        public string Restaurant { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<OrderProductsList> OrderProducts { get; set; }
    }
}
