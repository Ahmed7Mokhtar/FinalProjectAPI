using FinalProjectDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectModels.Models
{
    public class الحركة
    {
        // 2- create حركة
        [Key]
        public int رقم_الحركة { get; set; }
        public string? نوع_الحركة { get; set; } // بيع,شراء,مرتجع بيع,مرتجع شراء
        public DateTime تاريخ_الحركة { get; set; }
        public double المبلغ { get; set; }
        //public virtual الفواتير? فاتورة { get; set; }
    }
}
