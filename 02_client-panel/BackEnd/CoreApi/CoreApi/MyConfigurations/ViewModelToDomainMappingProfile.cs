using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreApi.Models.Angular;
using CoreApi.ViewModels.Angular;

namespace CoreApi.Web.MyConfigurations
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMappings";

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClientViewModel, Client>();
            CreateMap<ClientCreationViewModel, Client>();
            CreateMap<ClientModificationViewModel, Client>();
        }
    }
}
