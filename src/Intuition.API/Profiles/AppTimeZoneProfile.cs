using AutoMapper;
using Intuition.Domains.References;
using Intuition.ViewModels;

namespace Intuition.API.Profiles
{
    public class AppTimeZoneProfile : Profile
    {
        public AppTimeZoneProfile()
        {
            CreateMap<AppTimeZoneViewModel, AppTimeZone>()
                .ReverseMap();
        }
    }
}
