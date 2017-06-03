
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PaymentService;

namespace PaymentServiceFixture
{
    [TestClass]
    public class OrderServiceTest
    {
        [TestMethod]
        public async Task ShouldReturnNullIfOrderDoesNotExist()
        {
            var orderService = new OrderService("abc");
            var httpClientMock = new Mock<IPaymentHttpClient>(MockBehavior.Strict);
            httpClientMock.Setup(hc => hc.GetResponseAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<string>());
            var parserMock = new Mock<IJsonParser<Order>>();
            parserMock.Setup(pm => pm.FromJson(It.IsAny<string>())).Returns(()=>{return null;});
            orderService.HttpClient = httpClientMock.Object;
            orderService.OrderJsonParser = parserMock.Object;
            var order =await orderService.GetOrder("wrongid");
            Assert.IsNull(order);
        }
        [TestMethod]
        public async Task ShouldReturnOrderIfOrderExist()
        {
            var orderService = new OrderService("abc");
            var httpClientMock = new Mock<IPaymentHttpClient>(MockBehavior.Strict);
            httpClientMock.Setup(hc => hc.GetResponseAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<string>());
            var parserMock = new Mock<IJsonParser<Order>>();
            parserMock.Setup(pm => pm.FromJson(It.IsAny<string>())).Returns(new Order());
            orderService.HttpClient = httpClientMock.Object;
            orderService.OrderJsonParser = parserMock.Object;
            var order = await orderService.GetOrder("abc");
            Assert.IsNotNull(order);
        }
    }
}
