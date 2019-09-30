using ITG.Brix.Mobile.Bff.Application.Models.Dtos;
using System;
using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.From
{
    public class UpdateOperationalFromBody
    {
        public Guid OrderId { get; set; }
        public string Version { get; set; }
        public IEnumerable<HandledUnitMobileDto> Units { get; set; }
        public IEnumerable<RemarkDto> Remarks { get; set; }
        public IEnumerable<PictureDto> Pictures { get; set; }
        public IEnumerable<InputDto> Inputs { get; set; }
    }
}
