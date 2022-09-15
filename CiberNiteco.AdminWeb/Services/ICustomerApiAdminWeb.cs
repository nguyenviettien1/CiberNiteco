using System.Collections.Generic;
using System.Threading.Tasks;
using CiberNiteco.Entities.Entities;

namespace CiberNiteco.AdminWeb.Services
{
    public interface ICustomerApiAdminWeb
    {
        Task<List<Customer>> GetAllCustomer();
    }
}