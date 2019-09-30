using System;
using System.Collections.Generic;
using System.Text;

namespace ITG.Brix.Mobile.Bff.Application.Models.Dtos
{
    public class InputDto
    {
        public string Operant { get; set; }
        public Guid OperantId { get; set; }
        public string CreatedOn { get; set; }
        public string Value { get; set; }
        public string Property { get; set; }
    }
}
