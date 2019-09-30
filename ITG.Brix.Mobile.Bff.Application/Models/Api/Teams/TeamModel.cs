using System;

namespace ITG.Brix.Mobile.Bff.Application.Models.Api
{
    public class TeamModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Layout { get; set; }
        public string FilterContent { get; set; }
    }
}
