using System;
using CiberNiteco.Entities.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace CiberNiteco.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}