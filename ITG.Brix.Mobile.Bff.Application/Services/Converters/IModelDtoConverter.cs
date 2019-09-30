using ITG.Brix.Mobile.Bff.Application.Models.Dtos;
using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Services.Converters
{
    public interface IModelDtoConverter
    {
        IEnumerable<HandledUnitDto> Convert(IEnumerable<HandledUnitMobileDto> handledUnitMobileDtos);
    }
}
