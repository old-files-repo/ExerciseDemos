using AutoMapper;
using MuRestful.Core.Domains;
using MyRestful.Api.ViewModels;

namespace MyRestful.Api.Configurations
{
    public class ViewModelToDomainProfile : Profile
    {
        public override string ProfileName { get; } = "ViewModelToDomainMappings";

        public ViewModelToDomainProfile()
        {
            CreateMap<CountryViewModel, Country>();
        }
    }
}