using System;
using System.Collections.Generic;

namespace TranQuocTrung1.Entities
{
    public partial class Cargo
    {
        public Cargo()
        {
            CargoDetails = new HashSet<CargoDetail>();
        }

        public int Id { get; set; }
        public int? ShipId { get; set; }
        public string? CargoDesc { get; set; }

        public virtual Ship? Ship { get; set; }
        public virtual ICollection<CargoDetail> CargoDetails { get; set; }
    }
}
