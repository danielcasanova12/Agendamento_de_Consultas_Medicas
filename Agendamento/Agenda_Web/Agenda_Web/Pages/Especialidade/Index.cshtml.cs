using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Agenda_Web.Models; // Importe o namespace correto
using Agenda_Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Web.Pages.Especialidade
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context; // Substitua pelo seu contexto de banco de dados
        private IList<EspecialidadeModel> especialidades;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<EspecialidadeModel> Especialidades { get => especialidades; set => especialidades = value; }
        public IList<EspecialidadeModel> Especialidades1 { get => especialidades; set => especialidades = value; }

        public void OnGet() => Especialidades = (IList<Especialidade>)_context.Especialidades.ToList();
    }
}
