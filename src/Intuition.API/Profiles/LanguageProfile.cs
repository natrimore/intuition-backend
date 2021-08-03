using AutoMapper;
using Intuition.Domains.References;
using Intuition.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intuition.API.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageViewModel, Language>()
                .ReverseMap();
        }
    }
}
