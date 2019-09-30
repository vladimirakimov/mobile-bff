using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Api
{
    public class TeamsModel
    {
        public long Count { get; set; }
        public string NextLink { get; set; }
        public IEnumerable<TeamModel> Value { get; set; }
    }
}
