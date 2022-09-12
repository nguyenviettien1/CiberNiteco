using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CiberNiteco.AdminWeb.Models;
using CiberNiteco.AdminWeb.Services;
using CiberNiteco.Core;
using CiberNiteco.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace CiberNiteco.AdminWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IOrderApiAdminWeb _orderApiAdminWeb;
        //private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IOrderApiAdminWeb orderApiAdminWeb, IConfiguration configuration)
        {
            //_logger = logger;
            _orderApiAdminWeb = orderApiAdminWeb;
            //_configuration = configuration;
        }

        public async Task<IActionResult> Index(string filter, int page = 1, int take = 10)
        {
            var data = new ListResult<Order>
            {
                Total = 0,
                Data = new List<Order>()
            };
            var x = await _orderApiAdminWeb.GetOrdersAsync(filter, page, take);
            ViewBag.Filter = filter;
            if (x?.Data != null)
            {
                data = x;
            }
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}