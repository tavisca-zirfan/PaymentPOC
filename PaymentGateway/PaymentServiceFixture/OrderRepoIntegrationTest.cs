using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentService;

namespace PaymentServiceFixture
{
    [TestClass]
    public class OrderRepoIntegrationTest
    {
        [TestMethod]
        public async Task ShouldReturnOrderIfOrderExist()
        {
            var repository = new OrderRepository();
            repository.OrderService = new OrderService("abc");
            var order = await repository.GetOrder("nbv123ak");
            Assert.AreEqual("nbv123ak", order.OrderId);
        }
    }
}
