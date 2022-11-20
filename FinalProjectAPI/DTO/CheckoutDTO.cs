namespace FinalProjectAPI.DTO
{
    public class CheckoutDTO
    {
        public int id { get; set; }
        public string productName { get; set; }
        public double sellingPrice { get; set; }
        public int quantity { get; set; }
        public double buyingPrice { get; set; }
    }
}