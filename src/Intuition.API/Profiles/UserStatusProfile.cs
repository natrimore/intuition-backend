using AutoMapper;
using Intuition.Domains;
using Intuition.ViewModels;

namespace Intuition.API.Profiles
{
    public class UserStatusProfile : Profile
    {
        public UserStatusProfile()
        {
            CreateMap<UserStatusViewModel, UserStatus>()
              .ReverseMap();
        }
    }
}
