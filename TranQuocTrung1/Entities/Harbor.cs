using System;
using System.Collections.Generic;

namespace TranQuocTrung1.Entities
{
    public partial class Harbor
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public DateTime? Time { get; set; }
        public int? Ability { get; set; }
    }
}
