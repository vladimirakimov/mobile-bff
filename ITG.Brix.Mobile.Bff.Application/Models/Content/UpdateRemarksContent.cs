using ITG.Brix.Mobile.Bff.Application.Models.Dtos;
using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Content
{
    public class UpdateRemarksContent
    {
        public IEnumerable<RemarkDto> Remarks { get; set; }
    }
}
