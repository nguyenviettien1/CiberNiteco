using System.Collections.Generic;
using System.Threading.Tasks;
using CiberNiteco.Core.Dtos;
using CiberNiteco.Entities.Entities;

namespace CiberNiteco.Core.Repository
{
    public interface IOrderRepository
    {
        Task<int> Create(OrderCreateRequest request);
        Task<int> Update(OrderUpdateRequest request);
        Task<int> Delete(int orderId);
        Task<Order> GetOrder(int orderId);
        Task<List<Order>> GetAllOrder();
        Task<ListResult<Order>> GetOrders(string filter, int page, int take); 
    }
}