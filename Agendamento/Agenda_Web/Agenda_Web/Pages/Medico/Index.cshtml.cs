using Agenda_Web.ApiUrl;
using ClassModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;

namespace Agenda_Web.Pages.Medico
{
    public class IndexModel : PageModel
    {
        public List<MedicoModel> Medicos { get; set; }
        public IndexModel()
        {
            
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var httpClient = new HttpClient();
            var url = "http://localhost:5219/api/Medico";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();

            Medicos = JsonConvert.DeserializeObject<List<MedicoModel>>(content)!;
            
            return Page();
        }

    }
}
