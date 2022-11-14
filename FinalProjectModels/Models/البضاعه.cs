using FinalProjectModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinalProjectDB.Models
{
    public class البضاعه
    {
        [Key]
        public int رقم_الصنف { get; set; }
        public string? اسم_الصنف { get; set; }
        public double سعر_البيع { get; set; }
        public int اجمالي_الكميه { get; set; }
        public double سعر_الشراء { get; set; }
        public string? الوصف { get; set; }
        public string? نوع_الصنف { get; set; }
        public string? ImageName { get; set; }


        //[JsonIgnore] ignore when serialized
        public virtual ICollection<الفواتير>? الفواتير { get; set; }
        //public virtual الفواتير الفواتير { get; set; }
        //[ForeignKey("شراء")]
        //public int شراءرقم_الصنف { get; set; }
        //public virtual شراء? شراء { get; set; }

        //[ForeignKey("بيع")]
        //public int بيعرقم_الصنف { get; set; }
        //public virtual بيع? بيع { get; set; }

        //[ForeignKey("مرتجع_بيع"),]
        //public int مرتجع_بيعرقم_الصنف { get; set; }
        //public virtual مرتجع_بيع? مرتجع_بيع { get; set; }

        //[ForeignKey("مرتجع_شراء")]
        //public int مرتجع_شراءرقم_الصنف { get; set; }
        //public virtual مرتجع_شراء? مرتجع_شراء { get; set; }
        //public virtual البضاعه بضاعه { get; set; }

    }
}
