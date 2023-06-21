using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Worktime
    {
        public decimal Id { get; set; }
        public string SunThursdayopen { get; set; }
        public string SunThursdayclose { get; set; }
        public string FriSatopen { get; set; }
        public string FriSatclose { get; set; }
    }
}
