using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject1ForMVC.Models
{
    public class JoinTable
    {


        // define properities for new model or class name jin table 

        public Customer1 Customer1 { get; set; }
        public Orderitem1 Orderitem1 { get; set; }

        public Order1 Order1 { get; set; }
        public Product1 Product1 { get; set; }
        public Categoryproduct1 Categoryproduct1 { get; set; }
        public Store1 Store1 { get; set; }
        public Categorystore1 Categorystore1 { get; set; }

    }
}
