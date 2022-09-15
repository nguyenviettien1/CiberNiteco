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
    public class ProductsController: ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productRepository.GetAllProduct();
            return Ok(products);
        }
    }
}