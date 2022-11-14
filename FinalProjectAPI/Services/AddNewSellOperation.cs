using FinalProjectAPI.DTO;
using FinalProjectDB.Models;
using FinalProjectModels.Models;
using System.Security.Principal;

namespace FinalProjectAPI.Services
{
    public class AddNewSellOperation
    {
        private readonly FinalProjectEntity context;

        public AddNewSellOperation(FinalProjectEntity _context)
        {
            context = _context;
        }
        public int Add(FullSellDTO sellobj)
        {
            الحسابات account = new الحسابات
            {
                اسم_الحساب = sellobj.اسم_الحساب,
                التليفون = sellobj.التليفون,
                التصنيف = sellobj.التصنيف,
                العنوان = sellobj.العنوان,
                دائن = sellobj.دائن,
                طبيعه_الحساب = sellobj.طبيعه_الحساب,
                كود_الحساب = sellobj.كود_الحساب,
                مدين = sellobj.المبلغ - ((sellobj.الخصم / 100) * sellobj.المبلغ)
            };

            context.الحسابات.Add(account);

            الحركة action = new الحركة
            {
                نوع_الحركة = sellobj.نوع_الحركة,
                تاريخ_الحركة = sellobj.تاريخ_الحركة,
                المبلغ = sellobj.المبلغ - ((sellobj.الخصم / 100) * sellobj.المبلغ),
            };

            context.الحركة.Add(action);

            context.SaveChanges();
            //
            الفواتير invoice = new الفواتير();
            invoice.التاريخ = sellobj.تاريخ_الحركة;
            invoice.الحساب = sellobj.اسم_الحساب;
            invoice.الخصم = sellobj.الخصم;
            int x = 0;
            invoice.الكميه = x;
            List<البضاعه> prod = new List<البضاعه>();
            foreach (var num in sellobj.رقم_وعدد_البضاعة)
            {
                prod.Add(context.البضاعه.FirstOrDefault(p => p.رقم_الصنف == int.Parse(num.Key)));
                invoice.الكميه += num.Value;
            }
            invoice.البضاعه = prod;
            invoice.النهائي = (sellobj.المبلغ - ((sellobj.الخصم / 100) * sellobj.المبلغ)) * invoice.الكميه;
            invoice.درج_النقديه = invoice.النهائي;
            invoice.رقم_الحركة = action.رقم_الحركة;
            invoice.طريقه_الحساب = sellobj.طريقه_الحساب;
            //

            context.الفواتير.Add(invoice);

            الخزنه safe = new الخزنه
            {
                التاريخ = sellobj.تاريخ_الحركة,
                الحركه = sellobj.نوع_الحركة,
                وارد = invoice.النهائي,
                رصيد = context.الخزنه.OrderByDescending(s => s.رقم_المسلسل).Select(s => s.الحساب).FirstOrDefault(),
                //الحساب = sellobj.المبلغ + context.الخزنه.OrderByDescending(s => s.رقم_المسلسل).Select(s => s.الحساب).FirstOrDefault(),
            };
            safe.الحساب = invoice.النهائي + context.الخزنه.OrderByDescending(s => s.رقم_المسلسل).Select(s => s.الحساب).FirstOrDefault();
            

            context.الخزنه.Add(safe);

            for (int i = 0; i < sellobj.رقم_وعدد_البضاعة.Count; i++)
            {
                var item = sellobj.رقم_وعدد_البضاعة.ElementAt(i);
                var product = context.البضاعه.FirstOrDefault(p => p.رقم_الصنف == int.Parse(item.Key));
                product.اجمالي_الكميه -= item.Value;
            }

            context.SaveChanges();

            return 1;
        }
    }
}
