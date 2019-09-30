using AutoMapper;
using ITG.Brix.Mobile.Bff.Application.Models.Content;
using ITG.Brix.Mobile.Bff.Application.Models.From;

namespace ITG.Brix.Mobile.Bff.Application.MappingProfiles
{
    public class FromBodyToContentProfile : Profile
    {
        public FromBodyToContentProfile()
        {
            CreateMap<UpdateRemarksFromBody, UpdateRemarksContent>();
            CreateMap<UpdateOperationalFromBody, UpdateOperationalContent>();
        }
    }
}
