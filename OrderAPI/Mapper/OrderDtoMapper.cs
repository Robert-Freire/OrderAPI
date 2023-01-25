//using OrderAPI.Dtos;
//using OrderAPI.Model;

//namespace OrderAPI.Mapper
//{
//    public static class OrderDtoMapper
//    {
//        public static OrderDto Map(this Order order)
//        {
//            return new OrderDto { OrderId = order.OrderId, OrderLines = order?.OrderLines?.Select(ol => ol.Map()) };
//        }

//        public static Order Map(this OrderDto orderDto)
//        {
//            return new Order { OrderId = orderDto.OrderId, OrderLines = orderDto?.OrderLines?.Select(ol => new OrderLine(new ProductType { Id = ol.ProductTypeId }, ol.Quantity)) };
//        }
//    }
//}
