using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Card1
    {
        public decimal Cardid { get; set; }
        public decimal Cvv { get; set; }
        public decimal Balance { get; set; }
        public string Typeofcard { get; set; }
        public DateTime Validdate { get; set; }
        public string Customername { get; set; }
        public decimal? Customerid { get; set; }

        public virtual Customer1 Customer { get; set; }
    }
}
