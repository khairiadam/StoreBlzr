using System.Threading.Tasks;
using StoreBlzr.Shared.Dto;

namespace StoreBlzr.Server.Services.Authentication
{
    public interface IAuthService
    {

        Task<AuthModel> RegisterAsync(UserModel model);
        Task<AuthModel> GetTokenAsync(Login model);
    }
}