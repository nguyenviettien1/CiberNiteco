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
    public class CustomersController: ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customers = await _customerRepository.GetAllCustomer();
            return Ok(customers);
        }
    }
}