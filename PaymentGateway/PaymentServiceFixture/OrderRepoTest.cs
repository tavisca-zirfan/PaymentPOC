using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PaymentService;

namespace PaymentServiceFixture
{
    [TestClass]
    public class OrderRepoTest
    {
        [TestMethod]
        public async Task ShouldReturnNullIfOrderDoesNotExist()
        {
            var repository = new OrderRepository();
            var orderMockService = new Mock<IOrderService>();
            orderMockService.Setup(os => os.GetOrder(It.IsAny<string>())).ReturnsAsync(null);
            repository.OrderService = orderMockService.Object;
            var order = await repository.GetOrder("abc");
            Assert.IsNull(order);
        }
        [TestMethod]
        public async Task ShouldReturnOrderIfOrderExist()
        {
            var repository = new OrderRepository();
            var orderMockService = new Mock<IOrderService>();
            orderMockService.Setup(os => os.GetOrder(It.IsAny<string>())).ReturnsAsync(new Order{OrderId = "abc"});
            repository.OrderService = orderMockService.Object;
            var order = await repository.GetOrder("abc");
            Assert.IsNotNull(order);
            Assert.AreEqual("abc",order.OrderId);
        }
    }
}
