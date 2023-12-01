using System;
using System.Collections.Generic;

namespace TranQuocTrung_62132908._62.CNTT_3.Models
{
    public partial class TQuocGium
    {
        public TQuocGium()
        {
            TDanhMucSps = new HashSet<TDanhMucSp>();
        }

        public string MaNuoc { get; set; } = null!;
        public string? TenNuoc { get; set; }

        public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; }
    }
}
