using System;
using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Api
{
    public class UnitModel
    {
        public Guid Id { get; set; }
        public LocationModel Location { get; set; }
        public GroupModel Group { get; set; }
        public MixedModel Mixed { get; set; }
        public int Units { get; set; }
        public bool IsMixed { get; set; }
        public bool IsPartial { get; set; }
        public string Type { get; set; }

        public string WeightNet { get; set; }
        public string WeightGross { get; set; }

        public string PalletNumber { get; set; }
        public string SsccNumber { get; set; }
        public string DateFifo { get; set; }

        public IEnumerable<ProductModel> Products { get; set; }
    }
}
