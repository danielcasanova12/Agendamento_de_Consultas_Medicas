using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Agenda_Web.Models; // Importe o namespace correto
using Agenda_Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Web.Pages.Recepcionista
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext AppDbcontext; // Substitua pelo seu contexto de banco de dados

        public IndexModel(AppDbContext context)
        {
            AppDbcontext = context;
        }

        public IList<RecepcionistaModel> Recepcionistas { get => Recepcionistas1; set => Recepcionistas1 = value; }
        public IList<RecepcionistaModel> Recepcionistas1 { get; set; }

        public void OnGet()
        {
            Recepcionistas = (IList<RecepcionistaModel>)AppDbcontext.Recepcionistas.ToList();
        }
    }
}
