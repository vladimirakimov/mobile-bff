using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.From
{
    public class FiltersFromBody
    {
        public string TeamId { get; set; }
        public IEnumerable<string> ItemKeys { get; set; }
        public Dictionary<string, string> TabFilters { get; set; }
        public string Operant { get; set; }
    }
}
