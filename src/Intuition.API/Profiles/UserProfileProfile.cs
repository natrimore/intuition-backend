using AutoMapper;
using Intuition.Domains;
using Intuition.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intuition.API.Profiles
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            CreateMap<UserProfileViewModel, UserProfile>()
                .ForMember(d => d.AppUser, opt => opt.Ignore())
                .ForMember(d => d.Gender, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}
