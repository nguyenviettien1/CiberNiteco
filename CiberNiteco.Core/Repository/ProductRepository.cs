using System.Collections.Generic;
using System.Threading.Tasks;
using CiberNiteco.Entities.EF;
using CiberNiteco.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CiberNiteco.Core.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CiberNitecoDbContext _context;
        public ProductRepository(CiberNitecoDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.Products.Include(a=>a.Category).ToListAsync();
        }
    }
}