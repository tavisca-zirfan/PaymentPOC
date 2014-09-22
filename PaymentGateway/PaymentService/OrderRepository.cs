
using System.Threading.Tasks;

namespace PaymentService
{
    public class OrderRepository:IOrderRepository
    {
        public IOrderService OrderService { get; set; }

        public OrderRepository()
        {
            
        }
        public async Task<Order> GetOrder(string orderId)
        {
            var order = await OrderService.GetOrder(orderId);
            return order;
        }
    }
}
