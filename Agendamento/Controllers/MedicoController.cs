
using Agendamento.Model;
using Microsoft.AspNetCore.Mvc;
using Agendamento.Repositories;
using System.Collections.Generic;

namespace PlataformaAgendamentoConsultas.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly MedicoRepository _médicoRepository;

        public MedicosController(MedicoRepository médicoRepository)
        {
            _médicoRepository = médicoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Medico>> GetMédicos()
        {
            var médicos = _médicoRepository.GetAllMédicos();
            return Ok(médicos);
        }

        [HttpGet("{id}")]
        public ActionResult<Medico> GetMédico(int id)
        {
            var médico = _médicoRepository.GetMédicoById(id);
            if (médico == null)
            {
                return NotFound();
            }
            return Ok(médico);
        }

        // Implemente métodos POST, PUT e DELETE conforme necessário para a entidade Médico.
    }
}
