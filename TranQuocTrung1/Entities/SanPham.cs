using System;
using System.Collections.Generic;

namespace TranQuocTrung1.Entities
{
    public partial class SanPham
    {
        public SanPham()
        {
            GioHangs = new HashSet<GioHang>();
        }

        public int Id { get; set; }
        public int? PhanLoaiId { get; set; }
        public string? TenSanPham { get; set; }
        public string? MoTaSanPham { get; set; }
        public decimal? GiaBan { get; set; }
        public DateTime? NgayThemVao { get; set; }
        public string? HinhSanPham { get; set; }

        public virtual PhanLoai? PhanLoai { get; set; }
        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}
