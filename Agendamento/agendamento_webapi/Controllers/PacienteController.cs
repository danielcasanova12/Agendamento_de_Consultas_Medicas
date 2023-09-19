using agendamento_webapi.Data;
using ClassModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agendamento_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PacienteController(AppDbContext context)
        {
            _context = context;
        }

        // Ação GET para obter todos os pacientes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pacientes = await _context.Pacientes!.ToListAsync();
            return Ok(pacientes);
        }

        // Ação GET para obter um paciente por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var paciente = await _context.Pacientes!.FindAsync(id);
            if (paciente == null)
            {
                return NotFound(); // Retorna 404 Not Found se o paciente não for encontrado
            }

            return Ok(paciente);
        }

        // Ação POST para adicionar um novo paciente
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PacienteModel paciente)
        {
            if (paciente == null)
            {
                return BadRequest();
            }

            _context.Pacientes!.Add(paciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = paciente.IdPaciente }, paciente);
        }

        // Ação PUT para atualizar um paciente por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PacienteModel paciente)
        {
            if (id != paciente.IdPaciente)
            {
                return BadRequest();
            }

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pacientes!.Any(p => p.IdPaciente == id))
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

        // Ação DELETE para excluir um paciente por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var paciente = await _context.Pacientes!.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
