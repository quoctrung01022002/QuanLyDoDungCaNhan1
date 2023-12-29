using System;
using System.Collections.Generic;

namespace TranQuocTrung1.Entities
{
    public partial class Ship
    {
        public Ship()
        {
            Arrivals = new HashSet<Arrival>();
            Cargos = new HashSet<Cargo>();
            Departures = new HashSet<Departure>();
            SortShips = new HashSet<SortShip>();
            TrainSchedules = new HashSet<TrainSchedule>();
        }

        public int Id { get; set; }
        public string? ShipName { get; set; }
        public string? ShipNameAuth { get; set; }
        public string? ShipNationality { get; set; }
        public string? ShipPlate { get; set; }
        public decimal? ShipSize { get; set; }
        public decimal? ShipWeight { get; set; }
        public decimal? ShipWattage { get; set; }
        public string? ShipCheckIn { get; set; }
        public int? ShipAuthInfo { get; set; }
        public string? ShipImage { get; set; }

        public virtual ICollection<Arrival> Arrivals { get; set; }
        public virtual ICollection<Cargo> Cargos { get; set; }
        public virtual ICollection<Departure> Departures { get; set; }
        public virtual ICollection<SortShip> SortShips { get; set; }
        public virtual ICollection<TrainSchedule> TrainSchedules { get; set; }
    }
}
