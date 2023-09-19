using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agenda_Web.Models; // Importe o namespace correto
using Agenda_Web.Data;

namespace Agenda_Web.Pages.Medico
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context; // Substitua pelo seu contexto de banco de dados
        private IList<MedicoModel> medicos;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<MedicoModel> Medicos { get => medicos; set => medicos = value; }

        public void OnGet()
        {
            Medicos = (IList<MedicoModel>)_context.Medicos
                .Include(m => m.Especialidade)
                .ToList();
        }
    }
}
