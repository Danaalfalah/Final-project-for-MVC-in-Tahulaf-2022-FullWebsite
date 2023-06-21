using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Customer
    {
        public Customer()
        {
            ProductCustomers = new HashSet<ProductCustomer>();
            Userlogins = new HashSet<Userlogin>();
        }

        public decimal Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<ProductCustomer> ProductCustomers { get; set; }
        public virtual ICollection<Userlogin> Userlogins { get; set; }
    }
}
