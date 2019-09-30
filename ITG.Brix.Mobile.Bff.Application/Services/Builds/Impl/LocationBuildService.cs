using ITG.Brix.Mobile.Bff.Application.Models.Api.Location;
using ITG.Brix.Mobile.Bff.Application.Models.Mobile.Location;
using System.Collections.Generic;
using System.Linq;

namespace ITG.Brix.Mobile.Bff.Application.Services.Builds.Impl
{
    public class LocationBuildService : ILocationBuildService
    {
        public LocationSiteModel BuildLocation(LocationsModel locationsModel)
        {
            var locations = locationsModel.Value;
            var warehouses = locations.GroupBy(x => x.Warehouse)
                                  .Select(loc => new { Name = loc.Key, Items = loc.ToList() });

            var location = new LocationSiteModel();
            location.Warehouses = new List<WarehouseModel>();

            foreach (var warehouse in warehouses)
            {
                var warehouseLocal = new WarehouseModel();
                warehouseLocal.Name = warehouse.Name;
                warehouseLocal.Gates = new List<GateModel>();

                var gates = warehouse.Items.GroupBy(x => x.Gate)
                                   .Select(g => new { Name = g.Key, Items = g.ToList() });

                foreach (var gate in gates)
                {
                    var gateLocal = new GateModel { Name = gate.Name };
                    gateLocal.Rows = new List<RowModel>();

                    var rows = gate.Items.GroupBy(x => x.Row)
                                         .Select(r => new { Name = r.Key, Items = r.ToList() });

                    foreach (var row in rows)
                    {
                        var rowLocal = new RowModel
                        {
                            Name = row.Name
                        };

                        var positions = row.Items.GroupBy(x => x.Position)
                                                 .Select(p => new PositionModel { Name = p.Key });

                        rowLocal.Positions = new List<PositionModel>(positions);
                        gateLocal.Rows.Add(rowLocal);
                    }
                    warehouseLocal.Gates.Add(gateLocal);
                }
                location.Warehouses.Add(warehouseLocal);
            }

            return location;
        }
    }
}
