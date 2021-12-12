using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public String? ReviewComment { get; set; }
        [Required]
        public int NumStars { get; set; }

        //Navigation
        [Required]
        public int ProductId { get; set; } //FK
        public Product Product { get; set; }

    }
}
