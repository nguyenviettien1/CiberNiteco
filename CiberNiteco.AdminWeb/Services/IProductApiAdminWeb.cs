using System.Collections.Generic;
using System.Threading.Tasks;
using CiberNiteco.Entities.Entities;

namespace CiberNiteco.AdminWeb.Services
{
    public interface IProductApiAdminWeb
    {
        Task<List<Product>> GetAllProduct();
    }
}