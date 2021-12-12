namespace DataLayer.Models
{
    public class Info
    {
        public int InfoID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Postal { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }

        //Navigation
        public Manufacturer Manufacturer { get; set; }
    }
}
