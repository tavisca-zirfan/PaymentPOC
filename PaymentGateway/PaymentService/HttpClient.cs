using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace PaymentService
{
    public class PaymentHttpClient:IPaymentHttpClient
    {

        public async Task<string> GetResponseAsync(string url, string orderId)
        {
            string strResponse="";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("api/order/"+orderId);
                if (response.IsSuccessStatusCode)
                {
                    strResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return strResponse;
        }
    }
}
