using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Manufacturer
    {
        public int ManufacturerID { get; set; }
        [Required]
        public string ManufacturerName { get; set; }
        public int? PhoneNumbér { get; set; }
        public string? Email { get; set; }

        //Navigation
        public int? InfoID { get; set; } //FK
        public Info Info { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
