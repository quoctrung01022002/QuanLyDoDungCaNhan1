using System;
using System.Collections.Generic;

namespace TranQuocTrung1.Entities
{
    public partial class AuthUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }
    }
}
