using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Shared;

namespace Server.Help
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // this.CreateMap<>();
            // this.CreateMap<UserModel, User>();
            // this.CreateMap<User, UserModel>();
            // this.CreateMap<User, RegisterModel>();
            // this.CreateMap<User, AuthModel>();
            // this.CreateMap<User, User>();
            // this.CreateMap<EditUserModel, RegisterModel>();
            // this.CreateMap<EditUserModel, UserModel>();

            // this.CreateMap<EditUserModel, User>()

            // .ForMember(dest => dest.Email, opt => opt.PreCondition(src => !string.IsNullOrEmpty(src.Email)))
            // .ForMember(dest => dest.FirstName, opt => opt.PreCondition(src => string.IsNullOrEmpty(src.FirstName)))
            // .ForMember(dest => dest.LastName, opt => opt.PreCondition(src => !string.IsNullOrEmpty(src.LastName)))
            // .ForMember(dest => dest.PhoneNumber, opt => opt.PreCondition(src => !string.IsNullOrEmpty(src.PhoneNumber)));

        }
    }
}