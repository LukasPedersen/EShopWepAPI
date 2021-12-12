using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        [Required]
        public string Path { get; set; }

        //Navigation
        [Required]
        public int ProductId { get; set; } //FK
        public Product Product { get; set; }
    }
}
