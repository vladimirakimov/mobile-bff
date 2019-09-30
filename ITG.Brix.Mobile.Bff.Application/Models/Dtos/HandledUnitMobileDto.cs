namespace ITG.Brix.Mobile.Bff.Application.Models.Dtos
{
    public class HandledUnitMobileDto
    {
        public string Id { get; set; }

        public string OperantId { get; set; }
        public string OperantLogin { get; set; }

        public string SourceUnitId { get; set; }

        public string Warehouse { get; set; }
        public string Gate { get; set; }
        public string Row { get; set; }
        public string Position { get; set; }

        public string Quantity { get; private set; }
        public string Units { get; private set; }
        public string WeightNet { get; private set; }
        public string WeightGross { get; private set; }
    }
}
