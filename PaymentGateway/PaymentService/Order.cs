
using System.Collections.Generic;

namespace PaymentService
{
    public class Order
    {
        public string OrderId { get; set; }
        public List<OrderItem> Items { get; set; } 
        public Price TotalCost { get; set; }
    }
}
