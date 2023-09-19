using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Agenda_Web.Models; // Importe o namespace correto
using Agenda_Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Web.Pages.Recepcionista
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context; // Substitua pelo seu contexto de banco de dados
        private RecepcionistaModel recepcionista;

        [BindProperty]
        public RecepcionistaModel Recepcionista { get => Recepcionista1; set => Recepcionista1 = value; }

         //public RecepcionistaModel(RecepcionistaModel recepcionista) => Recepcionista = recepcionista;

        public RecepcionistaModel Recepcionista1 { get => recepcionista; set => recepcionista = value; }
        public RecepcionistaModel Recepcionista2 { get => recepcionista; set => recepcionista = value; }

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

            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Models.RecepcionistaModel> entityEntry = _context.Recepcionistas.Add(Recepcionista);
            _context.SaveChanges();

            return RedirectToPage("./Index"); // Redireciona para a lista de recepcionistas
        }
    }
}
    
