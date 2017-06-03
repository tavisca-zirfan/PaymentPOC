using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace PaymentService
{
    public class OrderService:IOrderService
    {
        public IPaymentHttpClient HttpClient { get; set; }
        public IJsonParser<Order> OrderJsonParser { get; set; }
        public string CustomerId { get; set; }
        public OrderService(string customerId)
        {
            this.CustomerId = customerId;
            HttpClient = new PaymentHttpClient();
            OrderJsonParser = new JsonOrderParser();
        }
        public async Task<Order> GetOrder(string orderId)
        {
            string url = ServiceLocator.GetServiceUrl(CustomerId);
            string response = await HttpClient.GetResponseAsync(url,orderId);
            var order = OrderJsonParser.FromJson(response);
            return order;
        }
    }
}
