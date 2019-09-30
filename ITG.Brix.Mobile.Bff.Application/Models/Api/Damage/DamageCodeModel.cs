using System;

namespace ITG.Brix.Mobile.Bff.Application.Models.Api.Damage
{
    public class DamageCodeModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string DamagedQuantityRequired { get; set; }
        public string Source { get; set; }
    }
}
