using System;

namespace DataLayer.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public string Email { get; set; }
        public DateTime BuyDate { get; set; }
        public int OrderProductsDetailsId { get; set; }
    }
}
