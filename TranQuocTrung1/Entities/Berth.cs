using System;
using System.Collections.Generic;

namespace TranQuocTrung1.Entities
{
    public partial class Berth
    {
        public Berth()
        {
            Arrivals = new HashSet<Arrival>();
            Departures = new HashSet<Departure>();
            SortShips = new HashSet<SortShip>();
        }

        public int Id { get; set; }
        public string? BerthName { get; set; }
        public int? BerthCapacity { get; set; }
        public string? BerthStatus { get; set; }

        public virtual ICollection<Arrival> Arrivals { get; set; }
        public virtual ICollection<Departure> Departures { get; set; }
        public virtual ICollection<SortShip> SortShips { get; set; }
    }
}
