namespace OrderAPI.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public IEnumerable<OrderLine>? OrderLines { get; set; }
        public decimal? RequiredMinWidth
        {
            get
            {
                return OrderLines?.Sum(ol => ol.ProductType?.Width * ol.Quantity);
            }
        }
    }
}
