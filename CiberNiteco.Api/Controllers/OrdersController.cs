using System;
using System.IO;
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
        public async Task<IActionResult> Create([FromForm]OrderCreateRequest request)
        {
            var orderId = await _orderRepository.Create(request);
            if (orderId == 0)
            {
                return BadRequest();
            }

            if (orderId == -1)
            {
                string currentDir = Environment.CurrentDirectory;
                string logFolderName = "logs/";
                if (!Directory.Exists(logFolderName))
                {
                    // Kiểm tra thư mục log có tồn tại không? Nếu chưa có thì tạo mới
                    Directory.CreateDirectory(logFolderName);
                }
                string logFileName = ""; 
                DateTime now = DateTime.Now;
                logFileName = String.Format("{0}_{1}_{2}_log.txt",
                    now.Year, now.Month, now.Day);

                //string fullFileLog = logFolderName + "/" + logFileName;
                string fullFileLog = Path.Combine(logFolderName, logFileName);

                using (StreamWriter sw = new StreamWriter(fullFileLog))
                {
                    sw.WriteLine($"Loi xay ra vao luc: {now}");
                    sw.WriteLine("Loi cu the: Không đủ số lượng kho cho đơn hàng");
                }
                return Content("Không đủ số lượng kho của sản phẩm");
                
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