namespace DataLayer.DTO
{
    public class AdminDTO
    {
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsSignedIn { get; set; }
    }
}
