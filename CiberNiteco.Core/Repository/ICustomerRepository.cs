using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CiberNiteco.Entities.Entities;

namespace CiberNiteco.Core.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomer();
    }
}