using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ImdbIoasys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService) => _usuarioService = usuarioService;
        //    // GET: api/Usuario
        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        //    {
        //        return await _context.Usuarios.ToListAsync();
        //    }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        //    // PUT: api/Usuario/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        //    {
        //        if (id != usuario.UsuarioId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(usuario).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UsuarioExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Usuario
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        //    {
        //        usuario.Senha = usuario.Senha.Criptografar();
        //        _context.Usuarios.Add(usuario);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioId }, usuario);
        //    }

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
