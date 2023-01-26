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
        public void WhenOrderHasMUltipleLines_ThenRequiredMinWidthCorrectlyCalculated ()
        {
            //Order order = new Order() 
            //{ 
            //    OrderLines = new OrderLine[]
            //    {
            //        new OrderLine{ ProductType }
            //    }
            //}

            //Assert.IsNull(order.RequiredMinWidth);
        }
    }
}