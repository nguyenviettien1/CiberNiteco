using System.Threading.Tasks;
using CiberNiteco.Entities.Models.Users;

namespace CiberNiteco.Api.Systems.Users
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginRequest request);
    }
}