using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentService;

namespace PaymentServiceFixture
{
    [TestClass]
    public class PaymentHttpClientTest
    {
        [TestMethod]
        [ExpectedException(typeof(UriFormatException))]
        public async Task ShouldThrowExceptionIfServiceNotFound()
        {
            var client = new PaymentHttpClient();
            var response = await client.GetResponseAsync("some invalid url", "abc");
            Assert.AreNotEqual("",response);
        }

        [TestMethod]
        public async Task ShouldReturnJsonStringIfServiceIsWorking()
        {
            var client = new PaymentHttpClient();
            var response = await client.GetResponseAsync("http://localhost:43494", "abc");
            Assert.AreNotEqual("", response);
        }
    }
}
