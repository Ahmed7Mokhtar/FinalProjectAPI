namespace FinalProjectAPI.DTO
{
    public class AddNewProductImg
    {
        public int رقم_الصنف { get; set; }
        public string? اسم_الصنف { get; set; }
        public double سعر_البيع { get; set; }
        public int اجمالي_الكميه { get; set; }
        public double سعر_الشراء { get; set; }
        public string? الوصف { get; set; }

        public IFormFile? formFile { get; set; }

        public ICollection<int>? ارقام_الفواتير { get; set; }
    }
}
