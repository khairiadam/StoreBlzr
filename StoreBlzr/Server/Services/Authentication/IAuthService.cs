using System.Threading.Tasks;
using Shared.Dto;

namespace Server.Services.Authentication
{
    public interface IAuthService
    {

        Task<AuthModel> RegisterAsync(UserModel model);
        Task<AuthModel> GetTokenAsync(Login model);
    }
}