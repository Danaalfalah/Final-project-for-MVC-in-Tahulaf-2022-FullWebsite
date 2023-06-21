using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Slidehome
    {
        public decimal Id { get; set; }
        public string Img1 { get; set; }
        [NotMapped]
        public IFormFile ImageFile1 { set; get; }
        public string Img2 { get; set; }
        [NotMapped]
        public IFormFile ImageFile2 { set; get; }
        public string Img3 { get; set; }
        [NotMapped]
        public IFormFile ImageFile3 { set; get; }
    }
}
