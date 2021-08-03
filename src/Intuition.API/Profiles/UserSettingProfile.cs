using AutoMapper;
using Intuition.Domains;
using Intuition.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intuition.API.Profiles
{
    public class UserSettingProfile : Profile
    {
        public UserSettingProfile()
        {
            CreateMap<UserSettingViewModel, UserSetting>()
                .ForMember(d => d.AppTimeZone, opt => opt.Ignore())
                .ForMember(d => d.AppUser, opt => opt.Ignore())
                .ForMember(d => d.Language, opt => opt.Ignore())
                .ReverseMap();

            //CreateMap<UserSettingForUpdateViewModel, UserSettingViewModel>()
            //    .ForMember(w => w.Language, opt => opt.Ignore())
            //    .ForMember(w => w.AppTimeZone, opt => opt.Ignore())
            //.ReverseMap();

            //CreateMap<UserSettingForUpdateViewModel, UserSetting>()
            //   .ForMember(d => d.AppTimeZone, opt => opt.Ignore())
            //   .ForMember(d => d.AppUser, opt => opt.Ignore())
            //   .ForMember(d => d.Language, opt => opt.Ignore())
            //   .ReverseMap();
        }
    }
}
