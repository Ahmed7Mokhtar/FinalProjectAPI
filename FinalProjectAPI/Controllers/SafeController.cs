using FinalProjectAPI.DTO;
using FinalProjectDB.Models;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SafeController : ControllerBase
    {
        private readonly FinalProjectEntity context;

        public SafeController(FinalProjectEntity _context)
        {
            context = _context;
        }

        [HttpGet("Get")]
        public IActionResult GetAll()
        {
            List<الخزنه> safe = context.الخزنه.ToList();
            return Ok(safe);
        }

        [HttpGet("Get/{id:int}", Name = "GetOneSafeRecordRoute")]
        public IActionResult GetById(int id)
        {
            الخزنه safe = context.الخزنه.FirstOrDefault(a => a.رقم_المسلسل == id);
            if(safe != null)
            {
                return Ok(safe);
            }

            return BadRequest("لا يوجد صف خزنة بهذا الرقم!");
        }

        [HttpPost("Add")]
        public IActionResult AddNewSafe(SafeDTO newSafe)
        {
            if(ModelState.IsValid)
            {
                الخزنه safe = new الخزنه
                {
                    التاريخ = newSafe.التاريخ,
                    الحركه = newSafe.الحركه,
                    الحساب = newSafe.الحساب,
                    رصيد = newSafe.رصيد,
                    منصرف = newSafe.منصرف,
                    وارد = newSafe.وارد,
                };
                context.الخزنه.Add(safe);
                context.SaveChanges();
                string url = Url.Link("GetOneAccountRoute", new { id = safe.رقم_المسلسل });
                return Created(url, newSafe);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id:int}")]
        public IActionResult UpdateSafe(int id, SafeDTO newSafe)
        {
            if(ModelState.IsValid)
            {
                الخزنه safe  = context.الخزنه.FirstOrDefault(s => s.رقم_المسلسل == id);
                if(safe != null)
                {
                    safe.الحركه = newSafe.الحركه;
                    safe.التاريخ = newSafe.التاريخ;
                    safe.وارد = newSafe.وارد;
                    safe.منصرف = newSafe.منصرف;
                    safe.رصيد = newSafe.رصيد;
                    safe.الحساب = newSafe.الحساب;

                    context.SaveChanges();
                    return StatusCode(204, "تم تعديل الخزنة بنجاح");
                }

                return BadRequest("لا يوجد صف خزنة بهذا الرقم!");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult Remove(int id)
        {
            الخزنه safe = context.الخزنه.FirstOrDefault(s => s.رقم_المسلسل == id);
            if(safe != null)
            {
                try
                {
                    context.الخزنه.Remove(safe);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return StatusCode(204, "تم حذف الحزنة بنجاح");
            }

            return BadRequest("لا يوجد صف خزنة بهذا الرقم!");
        }
    }
}
