using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebAPIs.Token;
using WebAPIs_.Models;

namespace WebAPIs_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                return Unauthorized();
            }
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, true);

            if (result.Succeeded)
            {
                var userCurrent = await _userManager.FindByEmailAsync(login.Email);

                var idUser = userCurrent.Id;

                if (idUser == null)
                {
                    return NotFound();
                };

                var token = new TokenJWTBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                    .AddSubject("Teste Identity - JWT")
                    .AddIssuer("Teste.Identity.Bearer")
                    .AddAudience("Teste.Identity.Bearer")
                    .AddClaim("id", idUser)
                    .AddExpiry(5)
                    .Builder();

                return Ok(token.Value);
               
            }
            else
            {
                return Unauthorized();
            }
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/registro")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] Login login)
        {
            if(string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                return NotFound();
            }

            var user = new ApplicationUser
            {
                UserName = login.Email,
                Email = login.Email,
                CPF = login.CPF,
                Tipo = TipoUsuario.Comum
            };

            var resultado = await _userManager.CreateAsync(user, login.Password);

            if(resultado.Errors.Any())
            {
                return BadRequest(resultado.Errors);
            }

            //Geração de confirmação caso precise
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            // retorno email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var resultado2 = await _userManager.ConfirmEmailAsync(user, code);

            if (resultado2.Succeeded)
                return Ok("Usuário Adicionado com Sucesso");
            else
                return BadRequest("Erro ao confirmar usuários");
        }
    }
}

