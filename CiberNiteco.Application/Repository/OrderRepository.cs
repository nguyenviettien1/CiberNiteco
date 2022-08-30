using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CiberNiteco.Application.Dtos;
using CiberNiteco.Entities.EF;
using CiberNiteco.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CiberNiteco.Application.Repository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(IDbContextFactory<CiberNitecoDbContext> factory, ILogger<OrderRepository> logger) : base(factory)
        {
            _logger = logger;
        }
        
        public async Task<int> Create(OrderCreateRequest request)
        {
            await using var db = Create();
            var order = new Order
            {
                CustomerId = request.CustomerId,
                ProductId = request.ProductId,
                Amount = request.Amount,
                OrderDate = DateTime.Today
            };
            db.Orders.Add(order);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Update(OrderUpdateRequest request)
        {
            await using var db = Create();
            var oldOrder = await db.Orders.FirstOrDefaultAsync(t => t.Id == request.Id);
            if (oldOrder != null)
            {
                oldOrder.Amount = request.Amount;
                oldOrder.CustomerId = request.CustomerId;
                oldOrder.ProductId = request.ProductId;
            }
            else
            {
                _logger.LogWarning($"Không tìm thấy đơn hàng có Id {request.Id}");
                throw new CiberNitecoException($"Không tìm thấy đơn hàng có Id {request.Id}");
            }

            return await db.SaveChangesAsync();
        }

        public async Task<int> Delete(int orderId)
        {
            await using var db = Create();
            var oldOrder = await db.Orders.FirstOrDefaultAsync(t => t.Id == orderId);
            if (oldOrder != null)
            {
                db.Orders.Remove(oldOrder);
            }
            else
            {
                _logger.LogWarning($"Không tìm thấy đơn hàng có Id {orderId}");
                throw new CiberNitecoException($"Không tìm thấy đơn hàng có Id {orderId}");
            }

            return await db.SaveChangesAsync();
        }

        public Task<Order> GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }
        
        public async Task<List<Order>> GetAllOrder()
        {
            await using var db = Create();
            return db.Orders.Include(t => t.Customer)
                .Include(t => t.Product).ToList();
        }

        public async Task<ListResult<Order>> GetOrders(string filter, int page, int pageSize)
        {
            await using var db = Create();
            var q = db.Orders.Include(t => t.Customer)
                .Include(t => t.Product);
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