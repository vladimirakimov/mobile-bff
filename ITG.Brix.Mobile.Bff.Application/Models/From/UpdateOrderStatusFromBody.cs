using System;

namespace ITG.Brix.Mobile.Bff.Application.Models.From
{
    public class UpdateOrderStatusFromBody
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
        public string Version { get; set; }
    }
}
