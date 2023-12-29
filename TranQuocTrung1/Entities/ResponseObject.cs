using System;
using System.Collections.Generic;

namespace TranQuocTrung1.Entities
{
    public partial class ResponseObject
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
        public string? Data { get; set; }
    }
}
