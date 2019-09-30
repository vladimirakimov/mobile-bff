using ITG.Brix.Mobile.Bff.Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITG.Brix.Mobile.Bff.Application.Models.From
{
    public class UpdateRemarksFromBody
    {
        public Guid OrderId { get; set; }
        public string Version { get; set; }
        public IEnumerable<RemarkDto> Remarks { get; set; }
    }
}
