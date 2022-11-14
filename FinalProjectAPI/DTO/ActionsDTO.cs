using FinalProjectDB.Models;

namespace FinalProjectAPI.DTO
{
    public class ActionsDTO
    {
        public int رقم_الحركة { get; set; }
        public string? نوع_الحركة { get; set; }
        public DateTime تاريخ_الحركة { get; set; }
        public double المبلغ { get; set; }
        //public int رقم_الفاتورة { get; set; }
    }
}
