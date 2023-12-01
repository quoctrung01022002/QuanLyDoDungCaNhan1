using System;
using System.Collections.Generic;

namespace TranQuocTrung_62132908._62.CNTT_3.Models
{
    public partial class TAnhSp
    {
        public string MaSp { get; set; } = null!;
        public string TenFileAnh { get; set; } = null!;
        public short? ViTri { get; set; }

        public virtual TDanhMucSp MaSpNavigation { get; set; } = null!;
    }
}
