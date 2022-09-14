using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CiberNiteco.Core;
using CiberNiteco.Core.Dtos;
using CiberNiteco.Core.Repository;
using CiberNiteco.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CiberNiteco.AdminWeb.Services
{
    public class OrderApiAdminWeb : BaseApiAdminWeb, IOrderApiAdminWeb
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public OrderApiAdminWeb(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> Create(OrderCreateRequest request)
        {
            if (_httpContextAccessor
                    .HttpContext == null) return false;
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(request.CustomerId.ToString()), "customerId");
            requestContent.Add(new StringContent(request.ProductId.ToString()), "productId");
            requestContent.Add(new StringContent(request.OrderName), "orderName");
            requestContent.Add(new StringContent(request.OrderDate.Date.ToString(CultureInfo.InvariantCulture)), "orderDate");
            requestContent.Add(new StringContent(request.Amount.ToString(CultureInfo.InvariantCulture)), "description");

            var response = await client.PostAsync($"/api/Orders/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public Task<int> Update(OrderUpdateRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetOrder(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Order>> GetAllOrder()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ListResult<Order>> GetOrdersAsync(string filter, int page, int take)
        {
            ListResult<Order> data;
            if (string.IsNullOrEmpty(filter))
            {
                data = await GetAsync<ListResult<Order>>(
                    $"/api/Orders/paging?"+$"page={page}" +
                    $"&pageSize={take}");
            }
            else
            {
                data = await GetAsync<ListResult<Order>>(
                    $"/api/Orders/paging?"+$"filter={filter}"+$"&page={page}" +
                    $"&pageSize={take}");
            }
            return data;
        }
    }
}