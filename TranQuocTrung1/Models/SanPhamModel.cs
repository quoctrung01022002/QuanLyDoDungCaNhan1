namespace TranQuocTrung1.Models
{
    public partial class SanPhamModel
    {
        public int Id { get; set; }
        public int? PhanLoaiId { get; set; }
        public string? TenSanPham { get; set; }
        public string? MoTaSanPham { get; set; }
        public decimal? GiaBan { get; set; }
        public DateTime? NgayThemVao { get; set; }
        public string? HinhSanPham { get; set; }
    }
}
