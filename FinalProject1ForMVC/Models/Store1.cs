using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Store1
    {
        public Store1()
        {
            Categoryproduct1s = new HashSet<Categoryproduct1>();
        }

        public decimal Storeid { get; set; }
        public string Storename { get; set; }
        public string Imagepath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { set; get; }
        public string Descriptions { get; set; }
        public decimal? Categorystoreid { get; set; }

        public virtual Categorystore1 Categorystore { get; set; }
        public virtual ICollection<Categoryproduct1> Categoryproduct1s { get; set; }
    }
}
