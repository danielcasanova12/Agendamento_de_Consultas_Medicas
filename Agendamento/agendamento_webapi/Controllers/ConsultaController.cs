using agendamento_webapi.Data;
using agendamento_webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agendamento_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConsultaController(AppDbContext context)
        {
            _context = context;
        }

        // Ação GET para obter todas as consultas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var consultas = await _context.Consultas.ToListAsync();
            return Ok(consultas);
        }

        // Ação GET para obter uma consulta por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound(); // Retorna 404 Not Found se a consulta não for encontrada
            }

            return Ok(consulta);
        }

        // Ação POST para agendar uma nova consulta
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Consulta consulta)
        {
            if (consulta == null)
            {
                return BadRequest();
            }

            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = consulta.IdConsulta }, consulta);
        }

        // Ação PUT para atualizar uma consulta por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Consulta consulta)
        {
            if (id != consulta.IdConsulta)
            {
                return BadRequest();
            }

            _context.Entry(consulta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Consultas.Any(c => c.IdConsulta == id))
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

        // Ação DELETE para cancelar uma consulta por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
