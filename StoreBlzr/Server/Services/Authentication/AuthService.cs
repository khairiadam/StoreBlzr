using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StoreBlzr.Server.Help;
using StoreBlzr.Shared;
using StoreBlzr.Shared.Dto;

namespace StoreBlzr.Server.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IOptions<Jwt> _jwt;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<AppClient> _userManager;

        public AuthService(UserManager<AppClient> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper,
            IOptions<Jwt> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _jwt = jwt;
        }


        #region Registration

        public async Task<AuthModel> RegisterAsync(UserModel model)
        {
            //Check For Duplicate Email and Username
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel {Message = "Email is already Registered"};

            if (await _userManager.FindByNameAsync(model.UserName) is not null)
                return new AuthModel {Message = "Username is already Registered"};

            //Create new User

            var user = _mapper.Map<AppClient>(model);

            //Create User and Hash Password While Creating
            var result = await _userManager.CreateAsync(user, model.Password);


            //If Not succeed
            if (!result.Succeeded)
            {
                var errors = string.Empty;

                //Get Errors Description
                foreach (var error in result.Errors) errors += $"{error.Description} \n ";

                //Return Errors
                return new AuthModel {Message = errors};
            }

            //Add new Users To [User] Role
            await _userManager.AddToRoleAsync(user, "Client");

            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthModel
            {
                Email = user.Email,
                UserName = user.UserName,
                //TODO To Change ==>
                Roles = new List<string> {"Client"},
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };
        }

        #endregion


        #region Get Token From Login

        public async Task<AuthModel> GetTokenAsync(Login model)
        {
            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email/Password is Incorrect !";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);


            //TODO ==> Mapper
            authModel = _mapper.Map<AuthModel>(user);

            //authModel.Email = user.Email;
            //authModel.UserName = user.UserName;
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            return authModel;
        }

        #endregion


        #region Create a Token JWT

        private async Task<JwtSecurityToken> CreateJwtToken(AppClient user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("uid", user.Id)
                }
                .Union(userClaims)
                .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Value.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            // var signingCredentials = new SigningCredentials( SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken
            (
                _jwt.Value.Issuer,
                _jwt.Value.Audience,
                claims,
                expires: DateTime.Now.AddDays(_jwt.Value.DurationInDays),
                signingCredentials: signingCredentials
            );

            return jwtSecurityToken;
        }

        #endregion
    }
}