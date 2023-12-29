

namespace TranQuocTrung1.Models
{
    public partial class ArrivalModel
    {
        public int Id { get; set; }
        public int? ShipId { get; set; }
        public int? BerthId { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
    }
}
