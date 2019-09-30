using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Local
{
    public class TeamFilterModel
    {
        public List<NameModel> Sources { get; set; }
        public List<NameModel> Sites { get; set; }
        public List<NameModel> Operations { get; set; }
        public List<NameModel> OperationalDepartments { get; set; }
        public List<NameModel> TypePlannings { get; set; }
        public List<NameModel> Customers { get; set; }
        public List<NameModel> ProductionSites { get; set; }
        public List<NameModel> TransportTypes { get; set; }
        public string DriverWait { get; set; }
        public Dictionary<string, string> TabFilters { get; set; }
    }
}
