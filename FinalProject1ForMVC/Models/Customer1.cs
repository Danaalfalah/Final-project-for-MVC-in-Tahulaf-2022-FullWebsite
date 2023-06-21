using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Customer1
    {
        public Customer1()
        {
            Order1s = new HashSet<Order1>();
            Userlogin1s = new HashSet<Userlogin1>();
        }

        public decimal Customerid { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Phone]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public string Phone { get; set; }
      
        public string Address { get; set; }

        public virtual ICollection<Order1> Order1s { get; set; }
        public virtual ICollection<Userlogin1> Userlogin1s { get; set; }
    }
}
