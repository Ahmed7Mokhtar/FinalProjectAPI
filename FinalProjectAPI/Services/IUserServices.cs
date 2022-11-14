using FinalProjectAPI.DTO;
using Microsoft.AspNetCore.Identity;

namespace FinalProjectAPI.Services
{
    public interface IUserServices
    {
        Task<IdentityResult> SignUpAsync(SignUpDTO signUpDTO);
        Task<string> LoginAsync(SignInDTO signInDTO);
    }
}
