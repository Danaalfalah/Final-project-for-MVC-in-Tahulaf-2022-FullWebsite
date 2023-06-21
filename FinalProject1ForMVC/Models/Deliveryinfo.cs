using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Deliveryinfo
    {
        public decimal Id { get; set; }
        public decimal? Deliverycharge { get; set; }
        public decimal? Deliveryfreeabove { get; set; }
        public string Numberofdaydelivery { get; set; }
    }
}
