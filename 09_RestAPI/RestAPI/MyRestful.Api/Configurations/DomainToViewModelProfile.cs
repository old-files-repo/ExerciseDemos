using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MuRestful.Core.Domains;
using MyRestful.Api.ViewModels;

namespace MyRestful.Api.Configurations
{
    public class DomainToViewModelProfile : Profile
    {
        public override string ProfileName { get; } = "DomainToViewModelMappings";

        public DomainToViewModelProfile()
        {
            CreateMap<Country, CountryViewModel>();
        }
    }
}
