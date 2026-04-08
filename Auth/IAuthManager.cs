using Microsoft.AspNetCore.Identity;
using ProjetWebProg.Models;

namespace ProjetWebProg.Auth
{
    public interface IAuthManager
    {

        Task<IEnumerable<IdentityError>> RegisterAdmin(RegisterModel register);
        Task<IEnumerable<IdentityError>> RegisterUtilisateur(RegisterModel register);
        Task<AuthResponse> Login(LoginModel login); 
    }
}
