using agendamento_webapi.Data;
using agendamento_webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agendamento_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        // Simule uma lista de médicos para este exemplo
        private readonly AppDbContext _context;

        public MedicoController(AppDbContext context)
        {
            _context = context;
        }

        // Ação GET para obter todos os médicos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var medicos = await _context.Medicos.ToListAsync();
            return Ok(medicos);
        }
        // Ação POST para adicionar um médico
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Medico medico)
        {
            if (medico == null)
            {
                return BadRequest();
            }

            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = medico.IdMedico }, medico);
        }
        // Ação PUT para editar um médico
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Medico medico)
        {
            if (id != medico.IdMedico)
            {
                return BadRequest();
            }

            _context.Entry(medico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Medicos.Any(m => m.IdMedico == id))
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




    }
}
