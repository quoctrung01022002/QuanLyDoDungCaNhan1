namespace TranQuocTrung1.Models
{
    public partial class DepartureModel
    {
        public int Id { get; set; }
        public int? ShipId { get; set; }
        public int? BerthId { get; set; }
        public DateTime? DepartureDate { get; set; }
        public TimeSpan? DepartureTime { get; set; }
    }
}
