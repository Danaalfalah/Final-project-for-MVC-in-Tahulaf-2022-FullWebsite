using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Order1
    {
        public decimal Orderid { get; set; }
        public System.DateTime? Datefrom { get; set; }
        public string Descriptions { get; set; }
        public decimal? Orderitemid { get; set; }
        public decimal? Totalprice { get; set; }
        public decimal? Customerid { get; set; }

        public virtual Customer1 Customer { get; set; }
        public virtual Orderitem1 Orderitem { get; set; }
    }
}
