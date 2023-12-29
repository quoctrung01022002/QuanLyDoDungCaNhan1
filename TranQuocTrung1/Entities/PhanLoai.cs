using System;
using System.Collections.Generic;

namespace TranQuocTrung1.Entities
{
    public partial class PhanLoai
    {
        public PhanLoai()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int Id { get; set; }
        public string? TenLoai { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
