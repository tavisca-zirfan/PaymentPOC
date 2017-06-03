﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService
{
    public interface IOrderRepository
    {
        Task<Order> GetOrder(string p);
    }
}
