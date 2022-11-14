using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDB.Models
{
    public class الحسابات
    {
        //1- create حساب
        [Key]
        public int رقم_الحساب { get; set; }
        public string? اسم_الحساب { get; set; }
        public double? مدين { get; set; }
        public double? دائن { get; set; }
        public string? طبيعه_الحساب { get; set; }
        public string? التصنيف { get; set; }
        public int كود_الحساب { get; set; }
        public string? العنوان { get; set; }
        public string? التليفون { get; set; }
    }
}
