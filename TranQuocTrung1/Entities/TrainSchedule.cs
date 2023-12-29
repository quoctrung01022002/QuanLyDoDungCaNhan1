using System;
using System.Collections.Generic;

namespace TranQuocTrung1.Entities
{
    public partial class TrainSchedule
    {
        public int Id { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public int? DestinationPort { get; set; }
        public int? DeparturePort { get; set; }
        public int? ShipsId { get; set; }

        public virtual Ship? Ships { get; set; }
    }
}
