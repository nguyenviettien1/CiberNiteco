using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CiberNiteco.Core.Dtos;
using CiberNiteco.Entities.EF;
using CiberNiteco.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CiberNiteco.Core.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CiberNitecoDbContext _context;
        public OrderRepository(CiberNitecoDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> Create(OrderCreateRequest request)
        {
            var order = new Order
            {
                OrderName = request.OrderName,
                CustomerId = request.CustomerId,
                ProductId = request.ProductId,
                Amount = request.Amount,
                OrderDate = request.OrderDate
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<int> Update(OrderUpdateRequest request)
        {
            var oldOrder = await _context.Orders.FirstOrDefaultAsync(t => t.Id == request.Id);
            if (oldOrder != null)
            {
                oldOrder.OrderDate = request.OrderDate;
                oldOrder.OrderName = request.OrderName;
                oldOrder.Amount = request.Amount;
                oldOrder.CustomerId = request.CustomerId;
                oldOrder.ProductId = request.ProductId;
            }
            else
            {
                throw new CiberNitecoException($"Không tìm thấy đơn hàng có Id {request.Id}");
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int orderId)
        {
            var oldOrder = await _context.Orders.FirstOrDefaultAsync(t => t.Id == orderId);
            if (oldOrder != null)
            {
                _context.Orders.Remove(oldOrder);
            }
            else
            {
                throw new CiberNitecoException($"Không tìm thấy đơn hàng có Id {orderId}");
            }

            return await _context.SaveChangesAsync();
        }

        public Task<Order> GetOrder(int orderId)
        {
            return _context.Orders.Include(a => a.Customer)
                .Include(a => a.Product)
                .ThenInclude(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == orderId);
        }
        
        public async Task<List<Order>> GetAllOrder()
        {
            return await _context.Orders.Include(t => t.Customer)
                .Include(t => t.Product)
                .ThenInclude(a=>a.Category)
                .ToListAsync();
        }

        public async Task<ListResult<Order>> GetOrders(string filter, int page, int pageSize)
        {
            var q = _context.Orders.Include(t => t.Customer)
                .Include(t => t.Product)
                .ThenInclude(a=>a.Category)
                .Where(t=> string.IsNullOrEmpty(filter) || t.Product.Name.ToLower().Contains(filter.ToLower()));
            var total = await q.CountAsync();
            var data = await q
                .OrderByDescending(t => t.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new ListResult<Order> { Total = total, Data = data };
        }
    }
}