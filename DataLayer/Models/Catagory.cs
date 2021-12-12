using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{

    public class Catagory
    {
        public int CatagoryID { get; set; }
        [Required]
        public string CatagoryName { get; set; }

        //Navigation
        public ICollection<ProductCatagory> Products { get; set; }
    }

}
