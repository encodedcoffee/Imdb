using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.DbConfiguration.EfCore;
using Application.Interfaces.Services;
using System;

namespace ImdbIoasys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService) => _filmeService = filmeService;

        // GET: api/Filme
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> GetFilmes()
        {
            var filmes = await _filmeService.ListAsync();
            return filmes.ToList();
        }

        // GET: api/Filme/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetFilme(int id)
        {
            var filme = await _filmeService.GetAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        // PUT: api/Filme/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutFilme([FromBody] Filme filme)
        {
            try
            {
                await _filmeService.Alterar(filme);
            }
            catch (Exception)
            {
                var filmeExiste = await _filmeService.FilmeExiste(filme.FilmeId);
                if (!filmeExiste)
                    return NotFound();

                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Filme
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            await _filmeService.Incluir(filme);

            return CreatedAtAction("GetFilme", new { id = filme.FilmeId }, filme);
        }

        // POST: api/Filme/Votar
        [HttpPost("~/api/Filme/Votar")]
        public async Task<IActionResult> Votar(Voto voto)
        {
            await _filmeService.Votar(voto);

            return NoContent();
        }
    }
}
