
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PaymentService;

namespace PaymentServiceFixture
{
    [TestClass]
    public class OrderParserTest
    {
        [TestMethod]
        public void ShouldReturnNullIfProvidedIncorrectString()
        {
            var parser = new JsonOrderParser();
            var order = parser.FromJson(GetIncorrectOrderJsonString());
            Assert.IsNull(order);
        }

        [TestMethod]
        public void ShouldReturnOrderIfProvidedCorrectString()
        {
            var parser = new JsonOrderParser();
            var order = parser.FromJson(GetCorrectOrderJsonString());
            Assert.IsNotNull(order);
        }

        private string GetCorrectOrderJsonString()
        {
            var order = new Order
            {
                OrderId = "wfg234kj",
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ProductId = "234",
                        Cost = new Price {Amount = 4530, Currency = "INR"},
                        Description = "Safari Tour"
                    }
                },
                TotalCost = new Price {Amount = 4580, Currency = "INR"}
            };
            return JsonConvert.SerializeObject(order);
        }

        private string GetIncorrectOrderJsonString()
        {
            var order = new Order
            {
                OrderId = "wfg234kj",
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ProductId = "234",
                        Cost = new Price {Amount = 4530, Currency = "INR"},
                        Description = "Safari Tour"
                    }
                },
                TotalCost = new Price { Amount = 4580, Currency = "INR" }
            };
            return JsonConvert.SerializeObject(order)+"ok done";
        }
    }
}
