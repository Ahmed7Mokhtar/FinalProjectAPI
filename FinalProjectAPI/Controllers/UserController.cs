using FinalProjectAPI.DTO;
using FinalProjectAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices userServices;

        public UserController(IUserServices _userServices)
        {
            userServices = _userServices;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDTO signUpDTO)
        {
            var result = await userServices.SignUpAsync(signUpDTO);

            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            result.Errors.ToList().ForEach(i =>
            {
                ModelState.AddModelError("Errors", i.Description);
            });

            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(SignInDTO signInDTO)
        {
            var result = await userServices.LoginAsync(signInDTO);

            if(string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
