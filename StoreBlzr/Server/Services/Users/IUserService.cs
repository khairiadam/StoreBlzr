using System.Collections.Generic;
using System.Threading.Tasks;
using StoreBlzr.Shared.Dto;

namespace StoreBlzr.Server.Services.Users
{
    public interface IUserService
    {

        Task<List<UserModel>> GetUsersAsync();
        Task<UserModel> GetUserAsync(string userId);
        Task<UserModel> PutUserAsync(string userId, EditUserModel updatedUser);
        Task<bool> DeleteUserAsync(string userId);

        // Roles
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<List<object>> GetRolesList();
        Task<List<object>> GetUsersList();
    }
}