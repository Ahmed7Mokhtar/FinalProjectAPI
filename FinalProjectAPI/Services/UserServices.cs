using FinalProjectAPI.DTO;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalProjectAPI.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<WebUsers> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public SignInManager<WebUsers> SignInManager { get; }

        public UserServices(UserManager<WebUsers> _userManager, 
            SignInManager<WebUsers> _signInManager,
            IConfiguration _configuration)
        {
            userManager = _userManager;
            SignInManager = _signInManager;
            configuration = _configuration;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpDTO signUpDTO)
        {
            var user = new WebUsers()
            {
                FirstName = signUpDTO.FirstName,
                LastName = signUpDTO.LastName,
                Email = signUpDTO.Email,
                UserName = signUpDTO.Email,
                PhoneNumber = signUpDTO.PhoneNumber,
            };

            return await userManager.CreateAsync(user, signUpDTO.Password);
        }

        public async Task<string> LoginAsync(SignInDTO signInDTO)
        {
            var result = await SignInManager.PasswordSignInAsync(signInDTO.Email, signInDTO.Password, false, false);

            if(!result.Succeeded)
            {
                return null;
            }

            var user = await userManager.FindByEmailAsync(signInDTO.Email);
            bool isAdmin = await userManager.IsInRoleAsync(user, "Admin");

            string roleName = isAdmin ? "Admin" : "User";

            var authClaims = new List<Claim>
            {
                new Claim("UserName", signInDTO.Email),
                new Claim("role", roleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
