using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Agenda_Web.Models; // Importe o namespace correto
using Agenda_Web.Data;
using Microsoft.EntityFrameworkCore;
using Agenda_Web.Models.Agendamento.Model;

namespace Agenda_Web.Pages.Paciente
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context; // Substitua pelo seu contexto de banco de dados
        private PacienteModel paciente;

        [BindProperty]
        public PacienteModel Paciente1 { get => paciente; set => paciente = value; }

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _ = _context.Pacientes.Add(entity: paciente);
            _context.SaveChanges();

            return RedirectToPage("./Index"); // Redireciona para a lista de pacientes
        }
    }
}
