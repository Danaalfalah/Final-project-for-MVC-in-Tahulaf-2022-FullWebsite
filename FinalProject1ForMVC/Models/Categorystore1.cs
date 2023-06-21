using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Categorystore1
    {
        public Categorystore1()
        {
            Store1s = new HashSet<Store1>();
        }

        public decimal Categoryid { get; set; }
        public string Categoryname { get; set; }
        public string Imagepath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { set; get; }
        public string Discription { get; set; }

        public virtual ICollection<Store1> Store1s { get; set; }
    }
}
