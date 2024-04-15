using agendamento_webapi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassModels;

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
            var consultas = await _context.Consultas!.ToListAsync();

            // Percorra todas as consultas e preencha os médicos e pacientes associados
            foreach (var consulta in consultas)
            {
                consulta.Medico = await _context.Medicos.FindAsync(consulta.IdMedico);
                consulta.Paciente = await _context.Pacientes.FindAsync(consulta.IdPaciente);
            }

            return Ok(consultas);
        }


        // Ação GET para obter uma consulta por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var consulta = await _context.Consultas!.FindAsync(id);
            if (consulta == null)
            {
                return NotFound(); // Retorna 404 Not Found se a consulta não for encontrada
            }

            return Ok(consulta);
        }

        [HttpPost]
        public async Task<IActionResult> CriarConsultaMedica([FromBody] ConsultaModel consultaMedica)
        {
            try
            {
                // Verifique se os médicos e pacientes existem no banco de dados
                MedicoModel medico = await _context.Medicos.FindAsync(consultaMedica.IdMedico);
                var paciente = await _context.Pacientes.FindAsync(consultaMedica.IdPaciente);

                if (medico == null || paciente == null)
                {
                    return NotFound("Médico ou paciente não encontrado.");
                }

                // Associe o médico e o paciente à consulta médica
                consultaMedica.Medico = medico;
                consultaMedica.Paciente = paciente;
                consultaMedica.Observações = "Observações";

                // Adicione a consulta médica ao contexto e salve no banco de dados
                _context.Consultas.Add(consultaMedica);
                await _context.SaveChangesAsync();

                return Ok("Consulta médica criada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ConsultaModel consulta)
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
                if (!_context.Consultas!.Any(c => c.IdConsulta == id))
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
            var consulta = await _context.Consultas!.FindAsync(id);
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
