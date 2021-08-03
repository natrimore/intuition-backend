using AutoMapper;
using Intuition.Domains;
using Intuition.ViewModels;

namespace Intuition.API.Profiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserViewModel, AppUser>()
                .ForMember(d => d.UserStatus, opt => opt.Ignore())
                .ForMember(d => d.UserProfile, opt => opt.Ignore())
                .ForMember(d => d.UserSetting, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
