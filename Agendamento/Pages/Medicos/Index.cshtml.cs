using Microsoft.AspNetCore.Mvc.RazorPages;
using Agendamento.Repositories;
using Agendamento.Model;

namespace PlataformaAgendamentoConsultas.Pages.Medicos
{
    public class IndexModel : PageModel
    {
        private readonly MedicoRepository _medicoRepository;


        public IndexModel(MedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public List<Medico> Medicos { get; set; }

        public void OnGet()
        {
            Medicos = _medicoRepository.GetAllMedicos();
        }
    }
}
