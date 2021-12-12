using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class OrderProductsDetails
    {
        public int OrderProductsDetailsId { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string Navn { get; set; }
        [Required]
        public double Pris { get; set; }

        //Navigation
        [Required]
        public int OrderID { get; set; }
        public Order Order { get; set; }

    }
}
