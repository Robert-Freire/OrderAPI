using OrderAPI.Model;
using Xunit.Sdk;

namespace TestOrderAPI
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void WhenOrderHasNoLines_ThenRequiredMinWidthIsNull()
        {
            Order order = new Order();

            Assert.IsNull(order.RequiredMinWidth);
        }

        [TestMethod]
        public void WhenOrderHasMultipleLines_ThenRequiredMinWidthCorrectlyCalculated ()
        {
            var productType1 = new ProductType 
            { 
                Id= 1,
                Name = "Product type 1",
                Width = 3.9m
            };

            var productType2 = new ProductType
            {
                Id = 1,
                Name = "Product type 1",
                Width = 5.2m
            };
            var quantity1 = 2;
            var quantity2 = 5;

            var order = new Order()
            {
                OrderLines = new OrderLine[]
                {   
                     new OrderLine( productType1, quantity1),
                     new OrderLine( productType2, quantity2),

                }
            };

            Assert.AreEqual(productType1.Width * quantity1 + productType2.Width * quantity2, order.RequiredMinWidth);
        }
    }
}