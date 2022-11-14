using FinalProjectAPI.DTO;
using FinalProjectAPI.Services;
using FinalProjectDB.Models;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("FullBuyOperation/[controller]")]
    [ApiController]
    public class FullBuyOperationController : ControllerBase
    {
        private readonly FinalProjectEntity context;

        public FullBuyOperationController(FinalProjectEntity _context)
        {
            context = _context;
        }

        [HttpPost]
        public IActionResult BuyOperation(FullBuyDTO buyobj)
        {
            if (ModelState.IsValid)
            {
                AddNewBuyOperation buy = new AddNewBuyOperation(context);
                buy.Add(buyobj);
                return Ok(buyobj);
            }
            return BadRequest(ModelState);
        }
    }
}
