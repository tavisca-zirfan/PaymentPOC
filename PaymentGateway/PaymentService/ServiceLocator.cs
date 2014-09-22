using System;


namespace PaymentService
{
    public class ServiceLocator
    {
        public static string GetServiceUrl(string customerId)
        {
            return "http://localhost:43494";
        }
    }
}
