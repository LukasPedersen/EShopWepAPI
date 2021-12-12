using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public String ProductName { get; set; }
        public string? ProductDescription { get; set; }
        [Required]
        public double Price { get; set; }


        //Navigation
        [Required]
        public int ManufacturerID { get; set; } //FK
        public Manufacturer Manufacturer { get; set; }

        public ICollection<ProductCatagory>? Catagories { get; set; }
        public ICollection<Image>? Images { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
