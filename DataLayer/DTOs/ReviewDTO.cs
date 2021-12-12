namespace DataLayer.DTO
{
    public class ReviewDTO
    {
        public int ReviewID { get; set; }
        public string ReviewComment { get; set; }
        public int NumStars { get; set; }
        public int ProductId { get; set; }
    }
}
