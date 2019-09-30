using System.Collections.Generic;
using ITG.Brix.Mobile.Bff.Application.Models.Dtos;

namespace ITG.Brix.Mobile.Bff.Application.Services.Converters.Impl
{
    public class ModelDtoConverter : IModelDtoConverter
    {
        public IEnumerable<HandledUnitDto> Convert(IEnumerable<HandledUnitMobileDto> handledUnitMobileDtos)
        {
            IList<HandledUnitDto> result = new List<HandledUnitDto>();
            if (handledUnitMobileDtos != null)
            {
                foreach (var handledUnitMobileDto in handledUnitMobileDtos)
                {
                    var handledUnitDto = new HandledUnitDto()
                    {
                        Id = handledUnitMobileDto.Id,

                        OperantId = handledUnitMobileDto.OperantId,
                        OperantLogin = handledUnitMobileDto.OperantLogin,

                        SourceUnitId = handledUnitMobileDto.SourceUnitId,

                        Warehouse = handledUnitMobileDto.Warehouse,
                        Gate = handledUnitMobileDto.Gate,
                        Row = handledUnitMobileDto.Row,
                        Position = handledUnitMobileDto.Position,

                        Quantity = handledUnitMobileDto.Quantity,
                        Units = handledUnitMobileDto.Units,
                        WeightNet = handledUnitMobileDto.WeightNet,
                        WeightGross = handledUnitMobileDto.WeightGross

                    };
                    result.Add(handledUnitDto);
                }
            }
            return result;
        }
    }
}
