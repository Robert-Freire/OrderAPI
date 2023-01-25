using Microsoft.EntityFrameworkCore;
using OrderAPI.Model;
using System.Xml.Linq;

namespace OrderAPI.Data
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ProductDb ProductDb;

        public OrderRepository(ProductDb productDb)
        {
            if (productDb is null)
            {
                throw new ArgumentNullException(nameof(productDb));
            }
            ProductDb = productDb;
        }
        public Task<Order?> Get(int id)
        {
            return Task.FromResult(ProductDb.Orders.FirstOrDefault(o => o.OrderId == id));
        }

        public Task<Order> Add(Order order)
        {

            order.OrderLines?.ToList().ForEach(line =>
            {
                var found = ProductDb.ProductTypes.TryGetValue(line.ProductType.Id, out var productType);
                if (!found || productType == null)
                {
                    throw new ArgumentException($"ProductType {line.ProductType.Id}not found");
                }
                line.ProductType = productType;
            });
            order.OrderId = ProductDb.GenerateNewOrderId();
            ProductDb.Orders.Add(order);
            return Task.FromResult(order);
        }
    }
}
