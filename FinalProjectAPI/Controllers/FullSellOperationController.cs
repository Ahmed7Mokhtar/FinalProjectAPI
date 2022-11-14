using FinalProjectAPI.DTO;
using FinalProjectAPI.Services;
using FinalProjectDB.Models;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("FullSellOperation/[controller]")]
    [ApiController]
    public class FullSellOperationController : ControllerBase
    {
        private readonly FinalProjectEntity context;

        public FullSellOperationController(FinalProjectEntity _context)
        {
                context = _context;
        }

        [HttpPost]
        public IActionResult SellOperation(FullSellDTO sellobj)
        {
            if(ModelState.IsValid)
            {
                AddNewSellOperation sell = new AddNewSellOperation(context);
                sell.Add(sellobj);
                return Ok(sell);
            }
            return BadRequest(ModelState);
        }
    }
}
