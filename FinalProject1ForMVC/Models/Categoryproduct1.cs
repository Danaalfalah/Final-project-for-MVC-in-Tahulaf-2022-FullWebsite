using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Categoryproduct1
    {
        public Categoryproduct1()
        {
            Product1s = new HashSet<Product1>();
        }

        public decimal Categoryproductid { get; set; }
        public string Categoryproductname { get; set; }
        public string Imagepath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { set; get; }
        public string Descriptions { get; set; }
        public decimal? Storeid { get; set; }

        public virtual Store1 Store { get; set; }
        public virtual ICollection<Product1> Product1s { get; set; }
    }
}
