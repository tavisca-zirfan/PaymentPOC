
using System;
using Newtonsoft.Json;

namespace PaymentService
{
    public class JsonOrderParser:IJsonParser<Order>
    {
        public Order FromJson(string response)
        {
            try
            {
                var order = JsonConvert.DeserializeObject<Order>(response);
                return order;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string ToJson(Order source)
        {
            throw new System.NotImplementedException();
        }
    }
}
