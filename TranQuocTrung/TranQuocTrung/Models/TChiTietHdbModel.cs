namespace TranQuocTrung.Models
{
    public partial class TChiTietHdbModel
    {
        public string MaHoaDon { get; set; } = null!;
        public string MaChiTietSp { get; set; } = null!;
        public int? SoLuongBan { get; set; }
        public decimal? DonGiaBan { get; set; }
        public double? GiamGia { get; set; }
        public string? GhiChu { get; set; }
    }
}
