using FinalProjectModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDB.Models
{
    public class الفواتير
    {
        //3- create فاتورة
        [Key]
        public int رقم_الفاتوره { get; set; }
        public DateTime التاريخ { get; set; }
        public string? الحساب { get; set; }
        public string? طريقه_الحساب { get; set; }
        public int الكميه { get; set; }
        public double الخصم { get; set; }
        public double النهائي { get; set; }
        public double درج_النقديه { get; set; }

        [ForeignKey("حركة")]
        public int رقم_الحركة { get; set; }
        public virtual الحركة حركة { get; set; }
        public virtual ICollection<البضاعه>? البضاعه { get; set; }
    }
}
