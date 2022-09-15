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
using CiberNiteco.Core.Dtos;
using CiberNiteco.Core.Repository;
using CiberNiteco.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace CiberNiteco.AdminWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IOrderApiAdminWeb _orderApiAdminWeb;
        private readonly ICustomerApiAdminWeb _customerApiAdminWeb;
        private readonly IProductApiAdminWeb _productApiAdminWeb;
        //private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IOrderApiAdminWeb orderApiAdminWeb, IConfiguration configuration, 
            ICustomerApiAdminWeb customerApiAdminWeb, IProductApiAdminWeb productApiAdminWeb)
        {
            //_logger = logger;
            _orderApiAdminWeb = orderApiAdminWeb;
            _customerApiAdminWeb = customerApiAdminWeb;
            _productApiAdminWeb = productApiAdminWeb;
            //_configuration = configuration;
        }
        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var productList = await _productApiAdminWeb.GetAllProduct();
            List<SelectListItem> products = new List<SelectListItem>();
            foreach( var c in productList )
            {
                products.Add(new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
            }
            ViewBag.ProductId = products;
            var customerList = await _customerApiAdminWeb.GetAllCustomer();
            List<SelectListItem> customers = new List<SelectListItem>();
            foreach( var c in customerList )
            {
                customers.Add(new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
            }
            ViewBag.CustomerId = customers;
            return View();
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]OrderCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _orderApiAdminWeb.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới đơn hàng thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm đơn hàng thất bại");
            return View();
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