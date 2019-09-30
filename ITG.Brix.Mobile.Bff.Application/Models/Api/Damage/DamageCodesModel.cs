using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Api.Damage
{
    public class DamageCodesModel
    {
        public long Count { get; set; }
        public string NextLink { get; set; }
        public IEnumerable<DamageCodeModel> Value { get; set; }
    }
}
