using System.Threading.Tasks;
using CiberNiteco.AdminWeb.Services;
using CiberNiteco.Entities.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace CiberNiteco.AdminWeb.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IUserApiAdminWeb _userApiAdminWeb;

        public UserController(IUserApiAdminWeb userApiAdminWeb)
        {
            _userApiAdminWeb = userApiAdminWeb;
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var token = await _userApiAdminWeb.Authenticate(request);
            return View(token);
        }
    }
}