using FinalProjectAPI.DTO;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace FinalProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {
        private readonly FinalProjectEntity context;

        public ActionsController(FinalProjectEntity _context)
        {
            this.context = _context; 
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<الحركة> actions = context.الحركة.ToList();

            List<ActionsDTO> actionsDTOs = new List<ActionsDTO>();
            foreach (var item in actions)
            {
                actionsDTOs.Add(new ActionsDTO
                {
                    المبلغ = item.المبلغ,
                    تاريخ_الحركة = item.تاريخ_الحركة,
                    رقم_الحركة = item.رقم_الحركة,
                    نوع_الحركة = item.نوع_الحركة,
                });

            }
            
            return Ok(actionsDTOs);
        }

        [HttpGet("GetById/{id:int}", Name = "GetOneActionRoute")]
        public IActionResult GetById(int id)
        {
            الحركة action = context.الحركة.FirstOrDefault(a => a.رقم_الحركة == id);
            if(action != null)
            {
                ActionsDTO actionsDTO = new ActionsDTO
                {
                    المبلغ = action.المبلغ,
                    تاريخ_الحركة = action.تاريخ_الحركة,
                    رقم_الحركة = action.رقم_الحركة,
                    نوع_الحركة = action.نوع_الحركة,
                };

                return Ok(action);
            }

            return BadRequest("لا يوجد حركة بهذا الرقم!");
        }

        [HttpPost("AddAction")]
        public IActionResult AddNewAction(ActionsDTO newAction)
        {
            if(ModelState.IsValid)
            {
                الحركة action = new الحركة
                {
                    المبلغ = newAction.المبلغ,
                    تاريخ_الحركة = newAction.تاريخ_الحركة,
                    نوع_الحركة = newAction.نوع_الحركة,
                    رقم_الحركة = newAction.رقم_الحركة,
                };

                context.الحركة.Add(action);
                context.SaveChanges();
                string url = Url.Link("GetOneActionRoute", new { id = action.رقم_الحركة });
                return Created(url, newAction);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id:int}")]
        public IActionResult UpdateAction(int id, ActionsDTO newAction)
        {
            if(ModelState.IsValid)
            {
                الحركة OldAction = context.الحركة.FirstOrDefault(a => a.رقم_الحركة == id);
                if(OldAction != null)
                {
                    OldAction.المبلغ = newAction.المبلغ;
                    OldAction.نوع_الحركة = newAction.نوع_الحركة;
                    OldAction.تاريخ_الحركة = newAction.تاريخ_الحركة;

                    context.SaveChanges();
                    return StatusCode(204, "تم تعديل الحركة بنجاح");
                }

                return BadRequest("لا توجد حركة به1ا الرقم");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult Remove(int id)
        {
            الحركة action = context.الحركة.FirstOrDefault(a => a.رقم_الحركة == id);
            if (action != null)
            {
                try
                {
                    context.الحركة.Remove(action);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return StatusCode(204, "تم حذف الحركة بنجاح");
            }

            return BadRequest("لا توجد حركة بهذا الرقم!");
        }
    }
}
