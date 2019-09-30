using System;

namespace ITG.Brix.Mobile.Bff.Application.Models.From
{
    public class MarkOrderStartedFromBody
    {
        public Guid OrderId { get; set; }
        public string Operant { get; set; }
        public string Version { get; set; }
    }
}
