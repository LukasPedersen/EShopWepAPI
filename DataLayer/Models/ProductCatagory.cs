namespace DataLayer.Models
{
    public class ProductCatagory
    {
        public int ProductID { get; set; } //PK
        public int CatagoryID { get; set; }//PK

        //Navigation
        public Product Product { get; set; }
        public Catagory Catagory { get; set; }
    }
}
