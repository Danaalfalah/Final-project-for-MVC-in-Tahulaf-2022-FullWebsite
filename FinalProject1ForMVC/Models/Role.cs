using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Role
    {
        public Role()
        {
            Userlogins = new HashSet<Userlogin>();
        }

        public decimal Id { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<Userlogin> Userlogins { get; set; }
    }
}
