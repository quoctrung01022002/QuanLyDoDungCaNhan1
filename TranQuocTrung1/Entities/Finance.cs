using System;
using System.Collections.Generic;

namespace TranQuocTrung1.Entities
{
    public partial class Finance
    {
        public int Id { get; set; }
        public string? Bill { get; set; }
        public decimal? Pay { get; set; }
        public string? MovinContract { get; set; }
        public decimal? PortFee { get; set; }
    }
}
