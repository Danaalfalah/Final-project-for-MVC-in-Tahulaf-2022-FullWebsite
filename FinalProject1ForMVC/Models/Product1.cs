using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Product1
    {
        public Product1()
        {
            Orderitem1s = new HashSet<Orderitem1>();
        }

        public decimal Productid { get; set; }
        public string Productname { get; set; }
        public decimal? Sale { get; set; }
        public decimal? Price { get; set; }
        public string Descriptions { get; set; }
        public decimal? Quantity { get; set; }
        public string Imagepath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { set; get; }
        public decimal? Categoryproductid { get; set; }

        public virtual Categoryproduct1 Categoryproduct { get; set; }
        public virtual ICollection<Orderitem1> Orderitem1s { get; set; }
    }
}
