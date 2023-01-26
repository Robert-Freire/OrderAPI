using Microsoft.AspNetCore.Mvc;
using OrderAPI.Data;
using OrderAPI.Model;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> OrderRepository;

        public OrderController(IRepository<Order> orderRepository)
        {
            OrderRepository = orderRepository;
        }

        [HttpGet(Name = "GetOrder")]
        public async Task<ActionResult<Order>> Get(int orderId)
        {
            var order = await OrderRepository.Get(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost(Name = "AddOrder")]
        public async Task<ActionResult<Order>> Add(Order order)
        {
            order = await OrderRepository.Add(order);
            if (order == null)
            {
                return NotFound();
            }
            return CreatedAtRoute("AddOrder", new { id = order.OrderId }, order);
        }
    }
}