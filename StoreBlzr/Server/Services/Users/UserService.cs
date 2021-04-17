using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Server.Services.Users;
using Shared;
using Shared.Dto;
using StoreBlzr.Server.Help;

namespace StoreBlzr.Server.Services.Users
{
    public class UserService : IUserService
    {

        private readonly UserManager<AppClient> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IOptions<Jwt> _jwt;
        // private readonly AuthService _authService;

        public UserService(UserManager<AppClient> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IOptions<Jwt> jwt)
        {

            // _authService = authService;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _jwt = jwt;
        }



        public async Task<UserModel> GetUserAsync(string userId)
        {
            if (userId is null)
                return new UserModel { Message = "Invalid User Id" };


            var user = await _userManager.FindByIdAsync(userId);


            if (await _userManager.FindByIdAsync(userId) is null)
                return new UserModel { Message = $"Couldn't find user with id  {userId}" };

            // var model = new UserModel();

            //user.Email = model.Email;  ...
            var model = _mapper.Map<UserModel>(user);
            return model;

        }



        public async Task<List<UserModel>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            if (users.Count <= 0) return new List<UserModel>();

            // var usersModel = _mapper.Map<List<UserModel>>(users);
            List<UserModel> list = new List<UserModel>();
            users.ForEach(u =>
           {
               var userModell = _mapper.Map<UserModel>(u);
               list.Add(userModell);
           });

            return list;

        }




        public async Task<UserModel> PutUserAsync(string userId, EditUserModel updatedUser)
        {
            var UserModel = new UserModel();
            UserModel = _mapper.Map<UserModel>(updatedUser);

            if (userId == null)
            {
                UserModel.Message = "Invalid Id";
                return UserModel;
            }

            var oldUser = await _userManager.FindByIdAsync(userId);

            if (oldUser is null)
            {
                UserModel.Message = "Invalid User";
                return UserModel;
            }
            if (string.IsNullOrEmpty(updatedUser.Password))
            {
                UserModel.Message = "Please enter your password";
                return UserModel;
            }
            else
            {
                if (!string.IsNullOrEmpty(updatedUser.NewPassword))
                {
                    if (updatedUser.NewPassword != updatedUser.ConfirmNewPassword)
                    {
                        UserModel.Message = "New Passwod and Confirm New Password are not same";
                        return UserModel;
                    }
                    var res = await _userManager.ChangePasswordAsync(oldUser, updatedUser.Password, updatedUser.NewPassword);
                    if (!res.Succeeded)
                    {
                        UserModel.Password = "";
                        UserModel.Message = "Couldn't change your password. Please try again !";
                        return UserModel;
                    }
                }

                UserModel.Password = "";

                oldUser.Email = string.IsNullOrEmpty(updatedUser.Email) ? oldUser.Email : updatedUser.Email;
                oldUser.FirstName = string.IsNullOrEmpty(updatedUser.FirstName) ? oldUser.FirstName : updatedUser.FirstName;
                oldUser.LastName = string.IsNullOrEmpty(updatedUser.LastName) ? oldUser.LastName : updatedUser.LastName;
                oldUser.UserName = string.IsNullOrEmpty(updatedUser.UserName) ? oldUser.UserName : updatedUser.UserName;
                oldUser.PhoneNumber = string.IsNullOrEmpty(updatedUser.PhoneNumber) ? oldUser.PhoneNumber : updatedUser.PhoneNumber;

                // _db.Entry(oldUser).State = EntityState.Modified;
                //oldUser.Email = string.IsNullOrEmpty(updatedUser.Email) ? oldUser.Email : updatedUser.Email;
                // var oldUser1 = _mapper.Map<ApplicationUser>(updatedUser);
                // var uu = _mapper.Map<ApplicationUser>(oldUser1);




                var result = await _userManager.UpdateAsync(oldUser);

                if (!result.Succeeded)
                {
                    UserModel.Message = result.Errors.AsEnumerable().ToString() + ", Somthing whent wrong !";
                    return UserModel;
                }

                //_db.Update(oldUser);
                // await _db.SaveChangesAsync();

                UserModel user = _mapper.Map<UserModel>(oldUser);

                return user;
            };
        }



        public async Task<bool> DeleteUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return false;

            var user = await _userManager.FindByIdAsync(userId);

            var result = await _userManager.DeleteAsync(user);
            // _db.Remove(user);
            if (!result.Succeeded) return false;
            return true;
        }







        #region Add User to Role

        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            //Get User
            var user = await _userManager.FindByIdAsync(model.UserId);

            //Check User and Role if Exist
            if (user is null || !await _roleManager.RoleExistsAsync(model.Role)) return "Invalid user ID Or Role";

            //Check if User have Role
            if (await _userManager.IsInRoleAsync(user, model.Role)) return "User Already Have this Role !";

            //Assign Role To User
            var result = await _userManager.AddToRoleAsync(user, model.Role);

            //Check Result if succeeses
            return result.Succeeded ? "Role Added successfully" : "Something Wrong !!";
        }


        #endregion




        #region GetRoles

        public async Task<List<object>> GetRolesList()
        {
            var rolesList = new List<object>();

            var roles = await _roleManager.Roles.ToListAsync();

            roles.ForEach(r =>
            {
                var role = new
                {
                    roleId = r.Id,
                    name = r.Name
                };
                rolesList.Add(role);
            });
            return rolesList;
        }

        #endregion




        #region GetUsers

        public async Task<List<object>> GetUsersList()
        {
            var usersList = new List<Object>();

            var users = await _userManager.Users.ToListAsync();
            users.ForEach(u =>
           {
               var user = new
               {
                   userId = u.Id,
                   Username = u.UserName,
               };
               usersList.Add(user);
           });
            return usersList;
        }

        #endregion
    }
}