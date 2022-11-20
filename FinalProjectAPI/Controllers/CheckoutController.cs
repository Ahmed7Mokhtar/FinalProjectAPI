using FinalProjectAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {

        [HttpPost]
        public IActionResult Checkout(List<CheckoutDTO> var)
        {
            List<CheckoutDTO> here = var;

            return Ok(here);
        }
    }
}
