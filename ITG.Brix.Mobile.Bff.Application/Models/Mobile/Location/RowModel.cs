using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Mobile.Location
{
    public class RowModel
    {
        public string Name { get; set; }
        public IList<PositionModel> Positions { get; set; }
    }
}
