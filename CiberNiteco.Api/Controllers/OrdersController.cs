using System.Threading.Tasks;
using CiberNiteco.Core.Dtos;
using CiberNiteco.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CiberNiteco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController: ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var orders = await _orderRepository.GetAllOrder();
            return Ok(orders);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetOrders(string filter, int page, int pageSize)
        {
            var orders = await _orderRepository.GetOrders(filter, page, pageSize);
            return Ok(orders);
        }
        
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            var order = await _orderRepository.GetOrder(orderId);
            if (order == null)
            {
                return BadRequest("Không tìm thấy đơn hàng");
            }
            return Ok(order);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]OrderCreateRequest request)
        {
            var orderId = await _orderRepository.Create(request);
            if (orderId == 0)
            {
                return BadRequest();
            }

            var order = await _orderRepository.GetOrder(orderId);

            return Created(nameof(GetOrder), order);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]OrderUpdateRequest request)
        {
            var orderId = await _orderRepository.Update(request);
            if (orderId == 0)
            {
                return BadRequest();
            }

            return Ok();
        }
        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Delete(int orderId)
        {
            var result = await _orderRepository.Delete(orderId);
            if (result == 0)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}