
using FinalProjectModels.Models;

namespace FinalProjectAPI.DTO
{
    public class InvoicesDTO
    {
        public int رقم_الفاتوره { get; set; }
        public DateTime التاريخ { get; set; }
        public string? الحساب { get; set; }
        public string? طريقه_الحساب { get; set; }
        public int الكميه { get; set; }
        public double الخصم { get; set; }
        public double النهائي { get; set; }
        public double درج_النقديه { get; set; }

        public int رقم_الحركة { get; set; }

        public ICollection<int>? ارقام_البضاعة { get; set;}
    }
}
