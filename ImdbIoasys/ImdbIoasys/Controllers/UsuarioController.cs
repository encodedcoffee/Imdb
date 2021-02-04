using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbIoasys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMINISTRADOR")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService) => _usuarioService = usuarioService;
        
        // GET: api/Usuario
        [HttpGet]
        [Route("~/api/Usuario/GetUsuarios/")]
        [Route("~/api/Usuario/GetUsuarios/{pagina}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios(int pagina = 0)
        {
            var usuarios = await _usuarioService.ListAsync(pagina);
            return usuarios.ToList();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetAsync(u => u.UsuarioId == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        //    // PUT: api/Usuario/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> AlterarUsuario([FromBody]Usuario usuario)
        {
            try
            {
                await _usuarioService.Alterar(usuario);
            }
            catch (Exception)
            {
                var usuarioExiste = await _usuarioService.UsuarioExiste(u => u.UsuarioId == usuario.UsuarioId);
                if (!usuarioExiste)
                    return NotFound();

                return BadRequest();
            }

            return NoContent();
        }

        //    // POST: api/Usuario
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            await _usuarioService.Incluir(usuario);

            return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioId }, usuario);
        }

        //TODO Implementar exclusão lógica
        //    // DELETE: api/Usuario/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteUsuario(int id)
        //    {
        //        var usuario = await _context.Usuarios.FindAsync(id);
        //        if (usuario == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Usuarios.Remove(usuario);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool UsuarioExists(int id)
        //    {
        //        return _context.Usuarios.Any(e => e.UsuarioId == id);
        //    }
    }
}
