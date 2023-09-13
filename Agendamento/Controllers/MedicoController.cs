using Agendamento.Model;
using Microsoft.AspNetCore.Mvc;
using Agendamento.Repositories;
using System.Collections.Generic;

namespace PlataformaAgendamentoConsultas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly MedicoRepository _medicoRepository;

        public MedicosController(MedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }
        [HttpGet("all")]
        public ActionResult<IEnumerable<Medico>> GetAllMedicos()
        {
            var medicos = _medicoRepository.GetAllMedicos();
            return Ok(medicos);
        }


        [HttpGet]
        public ActionResult<IEnumerable<Medico>> GetMedicos()
        {
            var medico = _medicoRepository.GetAllMedicos();
            return Ok(medico);
        }

        [HttpGet("{id}")]
        public ActionResult<Medico> GetMedico(int id)
        {
            var medico = _medicoRepository.GetMedicoById(id);
            if (medico == null)
            {
                return NotFound();
            }
            return Ok(medico);
        }

        [HttpPost]
        public ActionResult<Medico> CreateMedico([FromBody] Medico medico)
        {
            if (medico == null)
            {
                return BadRequest();
            }

            _medicoRepository.AddMedico(medico);
            return CreatedAtAction(nameof(GetMedico), new { id = medico.IdMedico }, medico);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMedico(int id, [FromBody] Medico medico)
        {
            if (medico == null || id != medico.IdMedico)
            {
                return BadRequest();
            }

            var existingMedico = _medicoRepository.GetMedicoById(id);
            if (existingMedico == null)
            {
                return NotFound();
            }

            _medicoRepository.UpdateMedico(medico);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMedico(int id)
        {
            var médico = _medicoRepository.GetMedicoById(id);
            if (médico == null)
            {
                return NotFound();
            }

            _medicoRepository.DeleteMedico(id);
            return NoContent();
        }
    }
}
