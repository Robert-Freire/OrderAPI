using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderAPI.Controllers;
using OrderAPI.Data;
using OrderAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOrderAPI
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private readonly OrderRepository OrderRepositoryUT;
        private readonly Mock<IProductDb> ProductDbMock;

        public OrderRepositoryTest()
        {
            ProductDbMock = new Mock<IProductDb>();
            OrderRepositoryUT = new OrderRepository(ProductDbMock.Object);
        }
        [TestMethod]
        public async Task AddOrder_WhenOrderHasRightProductTypes_ThenOrderAdded()
        {
            var productType = new ProductType()
            {
                Id = 1,
                Name = "Test",
                Width = 100
            };
            var order = new Order()
            {
                OrderLines = new OrderLine[] 
                {
                    new OrderLine(productType, 1)
                }
            };
            var dictProductTypes = new Dictionary<int, ProductType>() { { productType.Id, productType } };
            ProductDbMock.SetupGet(p => p.ProductTypes).Returns(dictProductTypes);
            var listOrders = new List<Order>();
            ProductDbMock.SetupGet(p => p.Orders).Returns(listOrders);

            var orderResult = await OrderRepositoryUT.Add(order);

            Assert.IsNotNull(orderResult);
            Assert.AreEqual(order.OrderLines.Count(), orderResult?.OrderLines?.Count());
            Assert.AreEqual(1, listOrders.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task AddOrder_WhenOrderHasWrongProductTypes_ThenTrowsException()
        {
            var productType = new ProductType()
            {
                Id = 1,
                Name = "Wrong Product Type",
                Width = 100
            };
            var order = new Order()
            {
                OrderLines = new OrderLine[]
                {
                    new OrderLine(productType, 1)
                }
            };
            var dictProductTypes = new Dictionary<int, ProductType>() ;
            ProductDbMock.SetupGet(p => p.ProductTypes).Returns(dictProductTypes);
            var listOrders = new List<Order>();
            ProductDbMock.SetupGet(p => p.Orders).Returns(listOrders);

            var orderResult = await OrderRepositoryUT.Add(order);
        }
    }
}
