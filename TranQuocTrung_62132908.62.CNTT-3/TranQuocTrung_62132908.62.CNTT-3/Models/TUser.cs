using System;
using System.Collections.Generic;

namespace TranQuocTrung_62132908._62.CNTT_3.Models
{
    public partial class TUser
    {
        public TUser()
        {
            TKhachHangs = new HashSet<TKhachHang>();
            TNhanViens = new HashSet<TNhanVien>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte? LoaiUser { get; set; }

        public virtual ICollection<TKhachHang> TKhachHangs { get; set; }
        public virtual ICollection<TNhanVien> TNhanViens { get; set; }
        public string Role { get; internal set; }
    }
}
