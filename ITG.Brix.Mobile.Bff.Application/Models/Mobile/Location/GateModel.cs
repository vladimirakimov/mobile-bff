using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Mobile.Location
{
    public class GateModel
    {
        public string Name { get; set; }
        public IList<RowModel> Rows { get; set; }
    }
}
