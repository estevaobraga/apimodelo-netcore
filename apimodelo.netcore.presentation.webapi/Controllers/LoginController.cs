using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using apimodelo.netcore.domain.domain.Models;
using apimodelo.netcore.domain.domain.Validations;
using apimodelo.netcore.presentation.webapi.Models;
using apimodelo.netcore.presentation.webapi.Swagger.Example;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Examples;

namespace apimodelo.netcore.presentation.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly TokenConfigurations _tokenConfigurations;

        public LoginController(TokenConfigurations _tokenConfigurations)
        {
            this._tokenConfigurations = _tokenConfigurations;
        }

        /// <summary>
        /// Gerar token para acesso as rotas protegidas
        /// </summary>
        [HttpPost]
        [SwaggerRequestExample(typeof(LoginViewModel), typeof(LoginViewModelEx))]
        public async Task<IActionResult> Post([FromServices] IMapper _mapper, [FromServices] LoginValidations validation, LoginViewModel login)
        {
            var usuario = _mapper.Map<Usuario>(login);

            //Valida usuario na base
            var entrar = await validation.ValidateAsync(usuario);
            if (!entrar.IsValid)
                return BadRequest(entrar);

            //Gera o token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfigurations.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("Usuario", usuario.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_tokenConfigurations.Issuer,
                _tokenConfigurations.Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return Ok(new { accessToken = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        /// <summary>
        /// Rota para teste do token
        /// </summary>
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2", "value3", "value4", "value5" };
        }
    }
}