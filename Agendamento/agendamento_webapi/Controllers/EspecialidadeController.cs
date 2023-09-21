using agendamento_webapi.Data;
using ClassModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agendamento_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EspecialidadeController(AppDbContext context)
        {
            _context = context;
        }

        // Ação GET para obter todas as especialidades
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var especialidades = await _context.Especialidades!.ToListAsync();
            return Ok(especialidades);
        }

        // Ação GET para obter uma especialidade por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var especialidade = await _context.Especialidades!.FindAsync(id);
            if (especialidade == null)
            {
                return NotFound(); // Retorna 404 Not Found se a especialidade não for encontrada
            }

            return Ok(especialidade);
        }

        // Ação POST para adicionar uma nova especialidade
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EspecialidadeModel especialidade)
        {
            if (especialidade == null)
            {
                return BadRequest();
            }

            _context.Especialidades!.Add(especialidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = especialidade.IdEspecialidade }, especialidade);
        }

        // Ação PUT para atualizar uma especialidade por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EspecialidadeModel especialidade)
        {
            if (id != especialidade.IdEspecialidade)
            {
                return BadRequest();
            }

            _context.Entry(especialidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Especialidades!.Any(e => e.IdEspecialidade == id))
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

        // Ação DELETE para excluir uma especialidade por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var especialidade = await _context.Especialidades!.FindAsync(id);
            if (especialidade == null)
            {
                return NotFound();
            }

            _context.Especialidades.Remove(especialidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
