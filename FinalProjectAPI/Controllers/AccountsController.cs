using FinalProjectDB.Models;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace FinalProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly FinalProjectEntity context;

        public AccountsController(FinalProjectEntity _context)
        {
            context = _context;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<الحسابات> accounts = context.الحسابات.ToList();
            return Ok(accounts);
        }

        // رقم الحساب
        [HttpGet]
        [Route("GetById/{id:int}", Name = "GetOneAccountRoute")]
        public IActionResult GetById(int id)
        {
            الحسابات account = context.الحسابات.FirstOrDefault(a => a.رقم_الحساب == id);
            return Ok(account);
        }

        // اسم الحساب
        [HttpGet("GetByname/{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            الحسابات account = context.الحسابات.FirstOrDefault(a => a.اسم_الحساب == name);
            return Ok(account);
        }

        [HttpPost("AddNewAccount")]
        public IActionResult AddNewAccount(الحسابات newAccount)
        {
            if (ModelState.IsValid)
            {
                context.الحسابات.Add(newAccount);
                context.SaveChanges();
                string url = Url.Link("GetOneAccountRoute", new { id = newAccount.رقم_الحساب });
                // location and newAccount in response body
                return Created(url, newAccount);
                //return Ok(newAccount);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id:int}")]
        public IActionResult UodateAccount([FromRoute]int id, [FromBody]الحسابات NewAccount)
        {
            if (ModelState.IsValid)
            {
                الحسابات OldAccount = context.الحسابات.FirstOrDefault(a => a.رقم_الحساب == id);
                if(OldAccount!=null)
                {
                    OldAccount.اسم_الحساب = NewAccount.اسم_الحساب;
                    OldAccount.طبيعه_الحساب = NewAccount.طبيعه_الحساب;
                    OldAccount.كود_الحساب = NewAccount.كود_الحساب;
                    OldAccount.التليفون = NewAccount.التليفون;
                    OldAccount.العنوان = NewAccount.العنوان;
                    OldAccount.التصنيف = NewAccount.التصنيف;
                    OldAccount.دائن = NewAccount.دائن;
                    OldAccount.مدين = NewAccount.مدين;

                    context.SaveChanges();
                    return StatusCode(204, "تم تعديل الحساب بنجاح");
                }

                return BadRequest("لا يوجد حساب بهذا الرقم!");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult RemoveAccount(int id)
        {
            الحسابات account = context.الحسابات.FirstOrDefault(a => a.رقم_الحساب == id);
            if (account != null)
            {
                try
                {
                    context.الحسابات.Remove(account);
                    context.SaveChanges();
                }catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return StatusCode(204, "تم حذف الحساب بنجاح");
            }

            return BadRequest("لا يوجد حساب بهذا الرقم!");
        }
    }
}
