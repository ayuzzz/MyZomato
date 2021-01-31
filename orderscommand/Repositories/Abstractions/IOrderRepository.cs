﻿using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        Task<bool> CreateNewOrderAsync(Order order);
    }
}
