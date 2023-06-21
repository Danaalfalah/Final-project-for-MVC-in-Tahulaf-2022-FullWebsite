using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Orderitem1
    {
        public Orderitem1()
        {
            Order1s = new HashSet<Order1>();
        }

        public decimal Orderitemid { get; set; }
        public decimal? Quantityitem { get; set; } 
        public decimal? Productid { get; set; }

        public virtual Product1 Product { get; set; }
        public virtual ICollection<Order1> Order1s { get; set; }
    }
}
