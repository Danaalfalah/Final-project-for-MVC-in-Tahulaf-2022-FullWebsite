using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Contactusform
    {
        public decimal Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}
