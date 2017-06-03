
using System.Threading.Tasks;

namespace PaymentService
{
    public interface IPaymentHttpClient
    {
        Task<string> GetResponseAsync(string url,string orderId);
    }
}
