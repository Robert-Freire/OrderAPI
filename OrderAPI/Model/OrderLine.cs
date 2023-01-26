namespace OrderAPI.Model
{
    public class OrderLine
    {
        public ProductType ProductType { get; set; }
        public int Quantity { get; set; }

        public OrderLine(ProductType productType, int quantity)
        {
            ProductType = productType;
            Quantity = quantity;
        }
    }
}
