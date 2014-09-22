
using System.Threading.Tasks;

namespace PaymentService
{
    public interface IOrderService
    {
        Task<Order> GetOrder(string orderId);
    }
}
