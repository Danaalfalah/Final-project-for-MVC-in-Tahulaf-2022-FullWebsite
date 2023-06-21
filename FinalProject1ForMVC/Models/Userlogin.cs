using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Userlogin
    {
        public decimal Userloginid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? Roleid { get; set; }
        public decimal? Customerid { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Role Role { get; set; }
    }
}
