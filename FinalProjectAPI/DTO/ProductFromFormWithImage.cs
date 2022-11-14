using System.Buffers.Text;

namespace FinalProjectAPI.DTO
{
    public class ProductFromFormWithImage
    {
        public string productName { get; set; }
        public double sellingPrice { get; set; }
        public int quantity { get; set; }
        public double buyingPrice { get; set; }
        public string disc { get; set; }
        public string category { get; set; }
        public string? imageName { get; set; }
        public byte[]? bytes { get; set; }

    }
}
