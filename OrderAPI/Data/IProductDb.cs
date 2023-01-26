using OrderAPI.Model;

namespace OrderAPI.Data
{
    public interface IProductDb
    {
        IList<Order> Orders { get; set; }
        IDictionary<int, ProductType> ProductTypes { get; set; }
        int GenerateNewOrderId();
    }
}
