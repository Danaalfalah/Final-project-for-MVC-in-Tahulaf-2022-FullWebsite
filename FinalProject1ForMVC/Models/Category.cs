﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FinalProject1ForMVC.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public decimal Id { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { set; get; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
