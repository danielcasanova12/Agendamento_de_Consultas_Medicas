using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agenda_Web.Models; // Importe o namespace correto
using Microsoft.AspNetCore.Mvc.Rendering;
using Agenda_Web.Data;

namespace Agenda_Web.Pages.ConsultaModel
{
    public class Create : PageModel
    {
        private readonly AppDbContext _context; // Substitua pelo seu contexto de banco de dados

        [BindProperty]
        public TipoConsulta ConsultaModel { get; set; }
        public SelectList Medicos { get; set; }
        public object AppDbcontext { get; private set; }

        public Create(AppDbContext context) => _context = context;

        public IActionResult OnGet()
        {
            Medicos = new SelectList(items: AppDbcontext.Medicos.ToList(), "Id", "Nome");
            return Page();
        }

        public TipoConsulta GetConsultaModel()
        {
            return ConsultaModel;
        }

        public IActionResult OnPost(TipoConsulta consultaModel)
        {
            if (!ModelState.IsValid)
            {
                Medicos = new SelectList(_context.Medicos.ToList(), "Id", "Nome");
                return Page();
            }

            _context.Consultas.Add(consultaModel);
            _context.SaveChanges();

            return RedirectToPage("./Index"); // Redireciona para a lista de consultas
        }
    }
}
