using CommonModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels
{
    public class Order
    {
        public Order()
        {
            Status = (int)OrderStatus.Ordered;
            TransactionId = Guid.NewGuid();
        }

        public int? Id { get; set; }
        public int? Status { get; set; }
        public Guid? TransactionId { get; set; }
        public int RestaurantId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public List<OrderProductsList> OrderProducts { get; set; } 
    }

    public class OrderProductsList
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
