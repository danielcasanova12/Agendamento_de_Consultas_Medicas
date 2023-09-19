using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agenda_Web.Models; // Importe o namespace correto
using Microsoft.AspNetCore.Mvc.Rendering;
using Agenda_Web.Data;

namespace Agenda_Web.Pages.Medico
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context; // Substitua pelo seu contexto de banco de dados

        [BindProperty]
        public MedicoModel Medico { get; set; }
        public SelectList Especialidades { get; set; }

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Especialidades = new SelectList(_context.Especialidades.ToList(), "Id", "Nome");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Especialidades = new SelectList(_context.Especialidades.ToList(), "Id", "Nome");
                return Page();
            }

            _context.Medicos.Add(Medico);
            _context.SaveChanges();

            return RedirectToPage("./Index"); // Redireciona para a lista de médicos
        }
    }
}
