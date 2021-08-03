using AutoMapper;
using Intuition.Domains.References;
using Intuition.ViewModels;

namespace Intuition.API.Profiles
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<GenderViewModel, Gender>()
                .ReverseMap();
        }
    }
}
