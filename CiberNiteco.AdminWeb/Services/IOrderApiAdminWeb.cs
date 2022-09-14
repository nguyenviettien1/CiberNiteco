using System.Collections.Generic;
using System.Threading.Tasks;
using CiberNiteco.Core;
using CiberNiteco.Core.Dtos;
using CiberNiteco.Entities.Entities;

namespace CiberNiteco.AdminWeb.Services
{
    public interface IOrderApiAdminWeb
    {
        Task<bool> Create(OrderCreateRequest request);
        Task<int> Update(OrderUpdateRequest request);
        Task<int> Delete(int orderId);
        Task<Order> GetOrder(int orderId);
        Task<List<Order>> GetAllOrder();
        Task<ListResult<Order>> GetOrdersAsync(string filter, int page, int take); 
    }
}