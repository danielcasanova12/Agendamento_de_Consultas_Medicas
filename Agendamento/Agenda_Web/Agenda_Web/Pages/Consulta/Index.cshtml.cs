using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agenda_Web.Models; // Importe o namespace correto
using Agenda_Web.Data;

namespace Agenda_Web.Pages.Consulta
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context; // Substitua pelo seu contexto de banco de dados

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<TipoConsulta> Consultas { get; set; }

        public void OnGet()
        {
            DbSet<Models.ConsultaModel>? consultas = _context.Consultas;
            Consultas = (IList<TipoConsulta>)consultas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .ToList();
        }
    }
}
