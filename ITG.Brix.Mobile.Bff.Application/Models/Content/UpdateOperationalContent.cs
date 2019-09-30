using ITG.Brix.Mobile.Bff.Application.Models.Dtos;
using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Content
{
    public class UpdateOperationalContent
    {
        public IEnumerable<HandledUnitDto> Units { get; set; }
        public IEnumerable<RemarkDto> Remarks { get; set; }
        public IEnumerable<PictureDto> Pictures { get; set; }
        public IEnumerable<InputDto> Inputs { get; set; }
    }
}
