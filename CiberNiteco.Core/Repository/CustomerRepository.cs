using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CiberNiteco.Entities.EF;
using CiberNiteco.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CiberNiteco.Core.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CiberNitecoDbContext _context;
        public CustomerRepository(CiberNitecoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}