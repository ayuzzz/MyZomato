using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels.Enums
{
    public enum EmailType
    {
        OrderCreated = 1,
        OrderStatusChanged = 2,
        PaymentStatusChanged = 3,
        FoodIsBeingPrepared = 4,
        OutForDelivery = 5,
        Delivered = 6,
        OrderCancelled = 7
    }
}
