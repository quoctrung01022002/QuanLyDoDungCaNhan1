namespace TranQuocTrung1.Models
{
    public partial class SortShipModel
    {
        public int Id { get; set; }
        public int? ShipId { get; set; }
        public int? BerthId { get; set; }
        public long? LocationBerth { get; set; }
    }
}
