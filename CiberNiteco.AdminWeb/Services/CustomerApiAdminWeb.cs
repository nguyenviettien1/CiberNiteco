
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CiberNiteco.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CiberNiteco.AdminWeb.Services
{
    public class CustomerApiAdminWeb: BaseApiAdminWeb, ICustomerApiAdminWeb
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public CustomerApiAdminWeb(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, 
            IConfiguration configuration) 
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            return await GetAsync<List<Customer>>(
                $"/api/Customers/");
        }
    }
}