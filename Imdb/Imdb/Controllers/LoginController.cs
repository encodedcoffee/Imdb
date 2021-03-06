using Application.Interfaces.Services;
using Domain.Entities;
using GlobalUtils;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace Imdb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public LoginController(IUsuarioService usuarioService) => _usuarioService = usuarioService;

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/Autenticar")]
        [SwaggerOperation(Summary = "Login de usuário/admin | Acesso: TODOS")]
        public async Task<IActionResult> Auth([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioExiste = await _usuarioService.UsuarioExiste(u => u.Login.Equals(usuario.Login));

                if (!usuarioExiste)
                    return BadRequest(new { Message = ObterMensagemLoginInvalido() });

                var usuarioConsultado = await _usuarioService.GetAsync(u => u.Login.Equals(usuario.Login));

                if (usuarioConsultado.Senha != usuario.Senha.Criptografar())
                    return BadRequest(new { Message = ObterMensagemLoginInvalido() });

                var token = AutenticadorJwt.GenerateToken(usuarioConsultado);

                usuarioConsultado.Senha = string.Empty;
                
                return Ok(new
                {
                    Token = token,
                    Usuario = usuarioConsultado
                });

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        private string ObterMensagemLoginInvalido() => "Login e/ou senha inválido(s).";
    }
}
