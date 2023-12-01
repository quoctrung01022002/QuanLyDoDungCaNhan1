using System;
using System.Collections.Generic;

namespace TranQuocTrung_62132908._62.CNTT_3.Models
{
    public partial class TKichThuoc
    {
        public TKichThuoc()
        {
            TChiTietSanPhams = new HashSet<TChiTietSanPham>();
        }

        public string MaKichThuoc { get; set; } = null!;
        public string? KichThuoc { get; set; }

        public virtual ICollection<TChiTietSanPham> TChiTietSanPhams { get; set; }
    }
}
