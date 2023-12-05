using System;
using System.Collections.Generic;

namespace TranQuocTrung.Entitys
{
    public partial class THangSx
    {
        public THangSx()
        {
            TDanhMucSps = new HashSet<TDanhMucSp>();
        }

        public string MaHangSx { get; set; } = null!;
        public string? HangSx { get; set; }
        public string? MaNuocThuongHieu { get; set; }

        public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; }
    }
}
