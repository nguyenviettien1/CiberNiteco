using System.Collections.Generic;
using System.Net.Http;
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

        public OrderApiAdminWeb(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }
        public Task<int> Create(OrderCreateRequest request)
        {
            throw new System.NotImplementedException();
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