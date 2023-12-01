using System;
using System.Collections.Generic;

namespace TranQuocTrung_62132908._62.CNTT_3.Models
{
    public partial class TLoaiDt
    {
        public TLoaiDt()
        {
            TDanhMucSps = new HashSet<TDanhMucSp>();
        }

        public string MaDt { get; set; } = null!;
        public string? TenLoai { get; set; }

        public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; }
    }
}
