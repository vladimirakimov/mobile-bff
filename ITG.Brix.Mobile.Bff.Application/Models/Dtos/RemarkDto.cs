using System;

namespace ITG.Brix.Mobile.Bff.Application.Models.Dtos
{
    public class RemarkDto
    {
        public string Text { get; set; }
        public string CreatedOn { get; set; }
        public string Operant { get; set; }
        public Guid OperantId { get; set; }
    }
}
