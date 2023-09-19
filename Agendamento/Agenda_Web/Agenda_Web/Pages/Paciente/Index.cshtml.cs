using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Agenda_Web.Models; // Importe o namespace correto
using Agenda_Web.Data;
using Microsoft.EntityFrameworkCore;
using Agenda_Web.Models.Agendamento.Model;

namespace Agenda_Web.Pages.Paciente
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context; // Substitua pelo seu contexto de banco de dados

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<PacienteModel> Pacientes { get; set; }

        public void OnGet()
        {
            Microsoft.EntityFrameworkCore.DbSet<Models.Agendamento.Model.PacienteModel>? pacientes = _context.Pacientes;
            Pacientes = pacientes.ToList();
        }
    }
}
