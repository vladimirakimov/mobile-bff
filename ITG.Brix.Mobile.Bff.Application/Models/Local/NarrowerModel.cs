using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Local
{
    public class NarrowerItem
    {
        public string Key { get; set; }
        public string Operation
        {
            get
            {
                return "equal";
            }
        }
        public string Value { get; set; }
    }

    public class NarrowerModel
    {
        public TeamNarrowerModel TeamNarrower { get; set; }
        public LayoutTabNarrowerModel LayoutTabNarrower { get; set; }
    }

    public class TeamNarrowerModel
    {
        public IEnumerable<NarrowerItem> Sources { get; set; }
        public IEnumerable<NarrowerItem> Sites { get; set; }
        public IEnumerable<NarrowerItem> Operations { get; set; }
        public IEnumerable<NarrowerItem> OperationalDepartments { get; set; }
        public IEnumerable<NarrowerItem> TypePlannings { get; set; }
        public IEnumerable<NarrowerItem> Customers { get; set; }
        public IEnumerable<NarrowerItem> ProductionSites { get; set; }
        public IEnumerable<NarrowerItem> TransportTypes { get; set; }
        public NarrowerItem DriverWait { get; set; }
    }

    public class LayoutTabNarrowerModel
    {
        public IEnumerable<NarrowerItem> Items { get; set; }
    }
}
