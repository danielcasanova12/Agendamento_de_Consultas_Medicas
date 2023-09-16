using agendamento_webapi.Data;
using agendamento_webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agendamento_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionistaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RecepcionistaController(AppDbContext context)
        {
            _context = context;
        }

        // Ação GET para obter todas as recepcionistas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var recepcionistas = await _context.Recepcionistas!.ToListAsync();
            return Ok(recepcionistas);
        }

        // Ação GET para obter uma recepcionista por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var recepcionista = await _context.Recepcionistas!.FindAsync(id);
            if (recepcionista == null)
            {
                return NotFound(); // Retorna 404 Not Found se a recepcionista não for encontrada
            }

            return Ok(recepcionista);
        }

        // Ação POST para adicionar uma nova recepcionista
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Recepcionista recepcionista)
        {
            if (recepcionista == null)
            {
                return BadRequest();
            }

            _context.Recepcionistas!.Add(recepcionista);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = recepcionista.IdRecepcionista }, recepcionista);
        }

        // Ação PUT para atualizar uma recepcionista por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Recepcionista recepcionista)
        {
            if (id != recepcionista.IdRecepcionista)
            {
                return BadRequest();
            }

            _context.Entry(recepcionista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Recepcionistas!.Any(r => r.IdRecepcionista == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Ação DELETE para excluir uma recepcionista por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var recepcionista = await _context.Recepcionistas!.FindAsync(id);
            if (recepcionista == null)
            {
                return NotFound();
            }

            _context.Recepcionistas.Remove(recepcionista);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
