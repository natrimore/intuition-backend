using AutoMapper;
using Intuition.Domains.Records;
using Intuition.ViewModels;

namespace Intuition.API.Profiles
{
    public class RecordProfile : Profile
    {
        public RecordProfile()
        {
            CreateMap<Record, RecordViewModel>()
                .ReverseMap();
        }
    }
}
