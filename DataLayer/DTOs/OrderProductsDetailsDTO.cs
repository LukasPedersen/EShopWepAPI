namespace DataLayer.DTO
{
    public class OrderProductsDetailsDTO
    {
        public int OrderProductsDetailsId { get; set; }
        public int ProductID { get; set; }
        public string Navn { get; set; }
        public double Pris { get; set; }
        public int OrderID { get; set; }
    }
}
