using System;
using System.Collections.Generic;

namespace TranQuocTrung_62132908._62.CNTT_3.Models
{
    public partial class TLoaiSp
    {
        public TLoaiSp()
        {
            TDanhMucSps = new HashSet<TDanhMucSp>();
        }

        public string MaLoai { get; set; } = null!;
        public string? Loai { get; set; }

        public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; }
    }
}
