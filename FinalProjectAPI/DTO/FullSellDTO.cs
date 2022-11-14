namespace FinalProjectAPI.DTO
{
    public class FullSellDTO
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
        //public DateTime التاريخ { get; set; }
        //public string? الحساب { get; set; }
        public string? طريقه_الحساب { get; set; }
        public int الكميه { get; set; }
        public double الخصم { get; set; }
        //public double النهائي { get; set; }
        //public double درج_النقديه { get; set; }
        //public ICollection<int>? ارقام_البضاعة { get; set; }

        // الخزنة
        //public int رقم_المسلسل { get; set; }
        //public string الحركه { get; set; }
        //public DateTime التاريخ { get; set; }
        //public double وارد { get; set; }
        //public double منصرف { get; set; }
        //public double رصيد { get; set; }
        //public double الحساب_الكلي{ get; set; }

        public Dictionary<string, int> رقم_وعدد_البضاعة { get; set; }
    }
}
