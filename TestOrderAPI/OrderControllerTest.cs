using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderAPI.Controllers;
using OrderAPI.Data;
using OrderAPI.Model;

namespace TestOrderAPI
{
    [TestClass]
    public class OrderControllerTest
    {
        private readonly OrderController OrderControllerUT;
        private readonly Mock<IRepository<Order>> OrderRepositoryMock;
        public OrderControllerTest()
        {
            OrderRepositoryMock = new Mock<IRepository<Order>>();
            OrderControllerUT = new OrderController(OrderRepositoryMock.Object);
                
        }

        [TestMethod]
        public async Task GetOrder_WhenOrderHasData_ThenResponse200()
        {
            var orderId = 1;
            var orderExpected = new Order() { OrderId = orderId };
            OrderRepositoryMock.Setup(m => m.Get(It.IsAny<int>())).ReturnsAsync(orderExpected);

            var orderResult =  await OrderControllerUT.Get(orderId);

            var okResult = (OkObjectResult?)orderResult?.Result;

            Assert.IsNotNull(okResult);
            Assert.IsNotNull(okResult.Value);
            Assert.AreEqual(orderExpected, okResult.Value);

        }

        [TestMethod]
        public async Task GetOrder_WhenOrderHasNoData_ThenResponse404()
        {

            var orderResult = await OrderControllerUT.Get(1);

            Assert.IsNotNull(orderResult);
            Assert.AreEqual(typeof(NotFoundResult), orderResult?.Result?.GetType());
        }
    }
}
