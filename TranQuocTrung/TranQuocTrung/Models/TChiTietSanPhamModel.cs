namespace TranQuocTrung.Models
{
    public partial class TChiTietSanPhamModel
    {
        public string MaChiTietSp { get; set; } = null!;
        public string? MaSp { get; set; }
        public string? MaKichThuoc { get; set; }
        public string? MaMauSac { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? Video { get; set; }
        public double? DonGiaBan { get; set; }
        public double? GiamGia { get; set; }
        public int? Slton { get; set; }
    }
}
