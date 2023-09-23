using ClassModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Agenda_Web.Pages.Paciente
{
    public class Index : PageModel
    {
        public List<PacienteModel> Pacientes { get; set; }
        public Index()
        {
            
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var httpClient = new HttpClient();
            var url = "http://localhost:5219/api/Paciente";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();

            Pacientes = JsonConvert.DeserializeObject<List<PacienteModel>>(content)!;
            
            return Page();
        }
    }
}