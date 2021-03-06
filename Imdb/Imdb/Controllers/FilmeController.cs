using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Interfaces.Services;
using System;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace Imdb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService) => _filmeService = filmeService;

        // GET: api/Filme
        [HttpGet]
        [Route("~/api/Filme/GetFilmes/")]
        [Route("~/api/Filme/GetFilmes/{pagina}")]
        [SwaggerOperation(Summary = "Listagem de filmes com filtro por {diretor, nome, gênero e/ou atores}, paginação opcional e ordenação composta por qtd. votos / nome | Acesso: AUTENTICADOS")]
        public async Task<ActionResult<IEnumerable<Filme>>> GetFilmes([FromBody]Filme filme, [FromRoute] int pagina = 0)
        {
            var filmes = await _filmeService.ListAsync(pagina, filme);
            return filmes.ToList();
        }

        // GET: api/Filme/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Consulta de detalhes do filme por id | Acesso: AUTENTICADOS")]
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
        [HttpPut]
        [Authorize(Roles = "ADMINISTRADOR")]
        [SwaggerOperation(Summary = "Alteração das informações de filme | Acesso: ADMINISTRADOR")]
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
        [HttpPost]
        [Authorize(Roles = "ADMINISTRADOR")]
        [SwaggerOperation(Summary = "Inclusão das informações de filme | Acesso: ADMINISTRADOR")]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            await _filmeService.Incluir(filme);

            return CreatedAtAction("GetFilme", new { id = filme.FilmeId }, filme);
        }

        // POST: api/Filme/Votar
        [Authorize(Roles = "COMUM")]
        [HttpPost("~/api/Filme/Votar")]
        [SwaggerOperation(Summary = "Votação de filme por usuário comum | Acesso: COMUM")]
        public async Task<IActionResult> Votar(Voto voto)
        {
            try
            {
                await _filmeService.Votar(voto);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }
    }
}
