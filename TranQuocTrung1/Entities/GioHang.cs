using System;
using System.Collections.Generic;

namespace TranQuocTrung1.Entities
{
    public partial class GioHang
    {
        public int Id { get; set; }
        public int? SanPhamId { get; set; }

        public virtual SanPham? SanPham { get; set; }
    }
}
