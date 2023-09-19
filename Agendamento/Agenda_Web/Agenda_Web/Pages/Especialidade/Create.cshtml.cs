using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Agenda_Web.Models; // Importe o namespace correto
using Agenda_Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Web.Pages.Especialidade
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context; // Substitua pelo seu contexto de banco de dados
        private EspecialidadeModel especialidade;

        [BindProperty]
        public EspecialidadeModel Especialidade { get => Especialidade1; set => Especialidade1 = value; }
        public EspecialidadeModel Especialidade1 { get => especialidade; set => especialidade = value; }

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

            _context.Especialidades.Add(Especialidade);
            _context.SaveChanges();

            return RedirectToPage("./Index"); // Redireciona para a lista de especialidades
        }
    }
}
