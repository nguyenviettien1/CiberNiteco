using CiberNiteco.Entities.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace CiberNiteco.AdminWeb.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
    }
}