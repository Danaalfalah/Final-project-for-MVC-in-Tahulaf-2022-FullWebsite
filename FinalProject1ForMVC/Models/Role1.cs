using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Role1
    {
        public Role1()
        {
            Userlogin1s = new HashSet<Userlogin1>();
        }

        public decimal Roleid { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<Userlogin1> Userlogin1s { get; set; }
    }
}
