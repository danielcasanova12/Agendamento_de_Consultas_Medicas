using ClassModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Agenda_Web.Pages.Especialidade
{
    public class Index : PageModel
    {
        public List<EspecialidadeModel> Especialidades { get; set; }
        public Index()
        {
            
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var httpClient = new HttpClient();
            var url = "http://localhost:5219/api/Especialidade";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();

            Especialidades = JsonConvert.DeserializeObject<List<EspecialidadeModel>>(content)!;
            
            return Page();
        }
    }
}