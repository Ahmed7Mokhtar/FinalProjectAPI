namespace FinalProjectAPI.DTO
{
    public class ProductsWithImagesDTO
    {
        public int id { get; set; }
        public string productName { get; set; }
        public string sellingPrice { get; set; }
        public string quantity { get; set; }
        public string buyingPrice { get; set; }
        public string disc { get; set; }
        public string category { get; set; }
        public string? location { get; set; }
    }
}
