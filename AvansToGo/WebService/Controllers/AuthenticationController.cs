using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly SignInManager<IdentityUser> _SignInManager;
        private readonly IConfiguration _Configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
            _Configuration = configuration;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginModel LoginModel)
        {
            if (ModelState.IsValid)
            {
                var User = await _UserManager.FindByEmailAsync(LoginModel.Email);

                if (User != null)
                {
                    await _SignInManager.SignOutAsync();

                    var SignInResult = await _SignInManager.PasswordSignInAsync(User, LoginModel.Password, false, false);
                    if (SignInResult.Succeeded)
                    {
                        var securityTokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = (await _SignInManager.CreateUserPrincipalAsync(User)).Identities.First(),
                            Expires = DateTime.Now.AddMinutes(60),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"])),
                            SecurityAlgorithms.HmacSha256Signature),
                            Issuer = _Configuration["Jwt:Issuer"]
                        };

                        var handler = new JwtSecurityTokenHandler();
                        var securityToken = new JwtSecurityTokenHandler().CreateToken(securityTokenDescriptor);
                        return Ok(new { Succes = true, Token = handler.WriteToken(securityToken) });
                    } else
                    {
                        return BadRequest("Could not log in");
                    }
                } else
                {
                    return BadRequest("Could not find user.");
                }
            }
            return BadRequest("Body is invalid.");
        }

        [HttpPost("signout")]
        public async Task<IActionResult> Signout()
        {
            await _SignInManager.SignOutAsync();
            return Ok(new { Success= true, message= "Logged out" });
        }

    }
}
