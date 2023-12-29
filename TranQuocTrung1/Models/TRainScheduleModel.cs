namespace TranQuocTrung1.Models
{
    public partial class TRainScheduleModel
    {
        public int Id { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public int? DestinationPort { get; set; }
        public int? DeparturePort { get; set; }
        public int? ShipsId { get; set; }
    }
}
