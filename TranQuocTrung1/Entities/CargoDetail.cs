using System;
using System.Collections.Generic;

namespace TranQuocTrung1.Entities
{
    public partial class CargoDetail
    {
        public int Id { get; set; }
        public int? CargoId { get; set; }
        public string? CargoType { get; set; }
        public long? CargoQuantity { get; set; }
        public string? CargoStart { get; set; }
        public string? CargoEnd { get; set; }
        public DateTime? CargoStartDate { get; set; }
        public TimeSpan? CargoStartTime { get; set; }
        public DateTime? CargoEndDate { get; set; }
        public TimeSpan? CargoEndTime { get; set; }

        public virtual Cargo? Cargo { get; set; }
    }
}
