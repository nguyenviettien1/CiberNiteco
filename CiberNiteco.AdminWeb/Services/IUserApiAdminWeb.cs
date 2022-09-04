using CiberNiteco.Entities.Models.Users;
using System.Threading.Tasks;

namespace CiberNiteco.AdminWeb.Services
{
    public interface IUserApiAdminWeb
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
