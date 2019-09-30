using AutoMapper;
using ITG.Brix.Mobile.Bff.Application.Models;
using ITG.Brix.Mobile.Bff.Application.Models.Api;

namespace ITG.Brix.Mobile.Bff.Application.MappingProfiles
{
    public class ApiToLocalModelProfile : Profile
    {
        public ApiToLocalModelProfile()
        {
            CreateMap<FlowModel, FlowDataModel>();
        }
    }
}
