namespace TranQuocTrung1.Models
{
    public partial class ShipModel
    {
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
    }
}
