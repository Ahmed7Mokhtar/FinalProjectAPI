using FinalProjectAPI.DTO;
using FinalProjectDB.Models;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Principal;

namespace FinalProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly FinalProjectEntity context;

        public InvoicesController(FinalProjectEntity _context)
        {
            context = _context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<الفواتير> invoices = context.الفواتير.Include(a => a.حركة).Include(i => i.البضاعه).ToList();

            var invsDTO = new List<InvoicesDTO>();

            foreach (var invoice in invoices)
            {
                invsDTO.Add(new InvoicesDTO
                {
                    رقم_الفاتوره = invoice.رقم_الفاتوره,
                    التاريخ = invoice.التاريخ,
                    الحساب = invoice.الحساب,
                    طريقه_الحساب = invoice.طريقه_الحساب,
                    الكميه = invoice.الكميه,
                    الخصم = invoice.الخصم,
                    النهائي = invoice.النهائي,
                    درج_النقديه = invoice.درج_النقديه,
                    رقم_الحركة  = invoice.حركة.رقم_الحركة, // new
                    ارقام_البضاعة = invoice.البضاعه.Select(p => p.رقم_الصنف).ToList(),
                });
            }

            return Ok(invsDTO);
        }

        [HttpGet("GetById/{id:int}", Name = "GetOneInvoiceRoute")]
        public IActionResult GetById(int id)
        {
            الفواتير invoice = context.الفواتير.Include(a => a.حركة).Include(i => i.البضاعه)
                    .FirstOrDefault(i => i.رقم_الفاتوره == id);

            if(invoice != null)
            {
                InvoicesDTO invDTO = new InvoicesDTO
                {
                    رقم_الفاتوره = invoice.رقم_الفاتوره,
                    التاريخ = invoice.التاريخ,
                    الحساب = invoice.الحساب,
                    طريقه_الحساب = invoice.طريقه_الحساب,
                    الكميه = invoice.الكميه,
                    الخصم = invoice.الخصم,
                    النهائي = invoice.النهائي,
                    درج_النقديه = invoice.درج_النقديه,
                    رقم_الحركة = invoice.حركة.رقم_الحركة,
                    ارقام_البضاعة = invoice.البضاعه.Select(p => p.رقم_الصنف).ToList(),
                };

                return Ok(invDTO);
            }

            return BadRequest("لا يوجد فاتورة بهذا الرقم!");
        }

        [HttpPost("AddNewInvoice")]
        public IActionResult AddNewInvoice(InvoicesDTO newInvoice)
        {
            if(ModelState.IsValid)
            {
                الفواتير invoice = new الفواتير
                {
                    الحساب = newInvoice.الحساب,
                    التاريخ = newInvoice.التاريخ,
                    الخصم = newInvoice.الخصم,
                    الكميه = newInvoice.الكميه,
                    النهائي = newInvoice.النهائي,
                    درج_النقديه = newInvoice.درج_النقديه,
                    طريقه_الحساب = newInvoice.طريقه_الحساب,
                    حركة = context.الحركة.FirstOrDefault(a => a.رقم_الحركة == newInvoice.رقم_الحركة),
                };

                List<البضاعه> prod = new List<البضاعه>();
                foreach (var num in newInvoice.ارقام_البضاعة)
                {
                    prod.Add(context.البضاعه.FirstOrDefault(p => p.رقم_الصنف == num));
                }
                invoice.البضاعه = prod;

                context.الفواتير.Add(invoice);
                context.SaveChanges();

                string url = Url.Link("GetOneInvoiceRoute", new { id = invoice.رقم_الفاتوره });
                return Created(url, newInvoice);
            }

            return BadRequest(ModelState);
        }


        [HttpPut("Update/{id:int}")]
        public IActionResult UodateInvoice(int id, [FromBody]InvoicesDTO NewInvoice)
        {
            if (ModelState.IsValid)
            {
                الفواتير Oldinvoice = context.الفواتير.Include(a => a.حركة).Include(i => i.البضاعه)
                        .FirstOrDefault(i => i.رقم_الفاتوره == id);

                if(Oldinvoice != null)
                {
                    Oldinvoice.التاريخ = NewInvoice.التاريخ;
                    Oldinvoice.الحساب = NewInvoice.الحساب;
                    Oldinvoice.طريقه_الحساب = NewInvoice.طريقه_الحساب;
                    Oldinvoice.الكميه = NewInvoice.الكميه;
                    Oldinvoice.الخصم = NewInvoice.الخصم;
                    Oldinvoice.النهائي = NewInvoice.النهائي;
                    Oldinvoice.درج_النقديه = NewInvoice.درج_النقديه;
                    Oldinvoice.حركة = context.الحركة.FirstOrDefault(a => a.رقم_الحركة == NewInvoice.رقم_الحركة);

                    List<البضاعه> prds = new List<البضاعه>();

                    foreach (var num in NewInvoice.ارقام_البضاعة)
                    {
                        prds.Add(context.البضاعه.FirstOrDefault(p => p.رقم_الصنف == num));
                    }

                    Oldinvoice.البضاعه = prds;
                    context.SaveChanges();

                    return StatusCode(204, "تم تعديل الفاتورة بنجاح");
                }

                return BadRequest("لا يوجد فاتورة بهذا الرقم!");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult RemoveInvoice(int id)
        {
            if (ModelState.IsValid)
            {
                الفواتير invoice = context.الفواتير.FirstOrDefault(i => i.رقم_الفاتوره == id);
                if(invoice != null)
                {
                    try
                    {
                        context.الفواتير.Remove(invoice);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }

                    return StatusCode(204, "تم حذف الفاتورة بنجاح");
                }

                return BadRequest("لا يوجد فاتورة بهذا الرقم!");
            }

            return BadRequest(ModelState);
        }
    }
}
