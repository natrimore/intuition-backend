using AutoMapper;
using Intuition.Domains;
using Intuition.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intuition.API.Profiles
{
    public class ErrorProfile : Profile
    {
        public ErrorProfile()
        {
            CreateMap<ErrorViewModel, Error>()
                .ForMember(d => d.Language, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
