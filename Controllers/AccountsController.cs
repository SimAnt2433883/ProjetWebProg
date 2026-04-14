using Microsoft.AspNetCore.Mvc;
using ProjetWebProg.Auth;

namespace ProjetWebProg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(IAuthManager authManager) : ControllerBase
    {
        private readonly IAuthManager _authManager = authManager;
        // POST: api/Account/register-admin
        //[HttpPost]
        //[Route("register-admin")]
        //public async Task<ActionResult> RegisterAdmin([FromBody] Models.RegisterModel register)
        //{
        //    var errors = await _authManager.RegisterAdmin(register);
        //    if (errors.Any())
        //    {
        //        foreach (var error in errors)
        //            ModelState.AddModelError(error.Code, error.Description);
        //        return BadRequest(ModelState);
        //    }
        //    return Ok();
        //}

        // POST: api/Account/register-utilisateur
        [HttpPost]
        [Route("register-utilisateur")]
        public async Task<ActionResult> RegisterUtilisateur([FromBody] Models.RegisterModel
        register)
        {
            var errors = await _authManager.RegisterUtilisateur(register);
            if (errors.Any())
            {
                foreach (var error in errors)
                    ModelState.AddModelError(error.Code, error.Description);
                return BadRequest(ModelState);
            }
            return Ok();
        }
        // POST: api/Account/register
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] Models.LoginModel login)
        {
            var authResponse = await _authManager.Login(login);
            if (authResponse is null)
                return Unauthorized();
            return Ok(authResponse);
        }
    }
}
