namespace FinalProjectAPI.DTO
{
    public class FullBuyDTO
    {
        // الحساب
        public string? اسم_الحساب { get; set; }
        public double? مدين { get; set; }
        public double? دائن { get; set; }
        public string? طبيعه_الحساب { get; set; }
        public string? التصنيف { get; set; }
        public int كود_الحساب { get; set; }
        public string? العنوان { get; set; }
        public string? التليفون { get; set; }


        // الحركة
        public string? نوع_الحركة { get; set; } // بيع,شراء,مرتجع بيع,مرتجع شراء
        public DateTime تاريخ_الحركة { get; set; }
        public double المبلغ { get; set; }

        // الفاتورة
        public string? طريقه_الحساب { get; set; }
        public int الكميه { get; set; }
        public double الخصم { get; set; }

        // البضاعة
        public Dictionary<string, int> رقم_وعدد_البضاعة { get; set; }
    }
}
