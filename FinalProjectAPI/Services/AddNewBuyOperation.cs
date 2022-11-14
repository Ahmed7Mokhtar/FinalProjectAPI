using FinalProjectAPI.DTO;
using FinalProjectDB.Models;
using FinalProjectModels.Models;

namespace FinalProjectAPI.Services
{
    public class AddNewBuyOperation
    {
        private readonly FinalProjectEntity context;

        public AddNewBuyOperation(FinalProjectEntity _context)
        {
            context = _context;
        }

        public int Add(FullBuyDTO buyobj)
        {
            // impact on الحسابات
            الحسابات account = new الحسابات
            {
                اسم_الحساب = buyobj.اسم_الحساب,
                التليفون = buyobj.التليفون,
                التصنيف = buyobj.التصنيف,
                العنوان = buyobj.العنوان,
                مدين = buyobj.مدين,
                طبيعه_الحساب = buyobj.طبيعه_الحساب,
                كود_الحساب = buyobj.كود_الحساب,
                دائن = buyobj.دائن,
            };

            context.الحسابات.Add(account);

            // impact on الحركة
            الحركة action = new الحركة
            {
                نوع_الحركة = buyobj.نوع_الحركة,
                تاريخ_الحركة = buyobj.تاريخ_الحركة,
                المبلغ = buyobj.المبلغ - ((buyobj.الخصم / 100) * buyobj.المبلغ),
            };

            context.الحركة.Add(action);

            context.SaveChanges();

            // impact on الفواتير
            الفواتير invoice = new الفواتير
            {
                التاريخ = buyobj.تاريخ_الحركة,
                الحساب = buyobj.اسم_الحساب,
                الخصم = buyobj.الخصم,
                الكميه = buyobj.الكميه,
                النهائي = buyobj.المبلغ - ((buyobj.الخصم / 100) * buyobj.المبلغ),
                رقم_الحركة = action.رقم_الحركة,
                طريقه_الحساب = buyobj.طريقه_الحساب,
            };
            invoice.درج_النقديه = invoice.النهائي;


            List<البضاعه> prod = new List<البضاعه>();
            foreach (var num in buyobj.رقم_وعدد_البضاعة)
            {
                prod.Add(context.البضاعه.FirstOrDefault(p => p.رقم_الصنف == int.Parse(num.Key)));
            }
            invoice.البضاعه = prod;

            context.الفواتير.Add(invoice);


            // impact on الخزنة
            الخزنه safe = new الخزنه
            {
                التاريخ = buyobj.تاريخ_الحركة,
                الحركه = buyobj.نوع_الحركة,
                منصرف = invoice.النهائي,
                رصيد = context.الخزنه.OrderByDescending(s => s.رقم_المسلسل).
                                    Select(s => s.الحساب).FirstOrDefault(),
            };
            safe.الحساب = context.الخزنه.OrderByDescending(s => s.رقم_المسلسل).
                        Select(s => s.الحساب).FirstOrDefault() - invoice.النهائي;

            context.الخزنه.Add(safe);


            // impact on البضاعة
            //for (int i = 0; i < buyobj.رقم_وعدد_البضاعة.Count; i++)
            //{
            //    var item = buyobj.رقم_وعدد_البضاعة.ElementAt(i);
            //    var product = context.البضاعه.FirstOrDefault(p => p.رقم_الصنف == int.Parse(item.Key));
            //    product.اجمالي_الكميه -= item.Value;
            //}

            foreach (var item in buyobj.رقم_وعدد_البضاعة)
            {
                var prd = context.البضاعه.FirstOrDefault(p => p.رقم_الصنف == int.Parse(item.Key));
                prd.اجمالي_الكميه += item.Value;
            }

            context.SaveChanges();


            return 1;
        }
    }
}
