using System.Threading.Tasks;
using CiberNiteco.Api.Systems.Users;
using CiberNiteco.Entities.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CiberNiteco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = await _userService.Authenticate(request);
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Tên đăng nhập hoặc mật khẩu không đúng");
            }

            return Ok(token);
        }
    }
}