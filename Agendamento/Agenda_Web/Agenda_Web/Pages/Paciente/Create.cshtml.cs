using System.Text;
using ClassModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Agenda_Web.Pages.Paciente
{
    public class Create : PageModel
    {
        [BindProperty]
        public PacienteModel PacienteModel { get; set; } = new();

        public Create()
        {
            
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var httpClient = new HttpClient();
            var url = "http://localhost:5219/api/Paciente";
            var garconJson = JsonConvert.SerializeObject(PacienteModel);
            var content = new StringContent(garconJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Paciente/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}