using System.Threading.Tasks;
using StoreBlzr.Shared.Dto;

namespace StoreBlzr.Shared.Services.Auth
{
    public interface IAuthDataService
    {

        Task<AuthModel> RegisterAsync(UserModel model);
        Task<AuthModel> GetTokenAsync(Login model);
    }
}