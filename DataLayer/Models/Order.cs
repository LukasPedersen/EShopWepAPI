using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        [Required]
        [StringLength(320)]
        public string Email { get; set; }
        public DateTime BuyDate { get; set; }

        //Navigation
        public ICollection<OrderProductsDetails> OrderProductsDetails { get; set; }
    }
}
