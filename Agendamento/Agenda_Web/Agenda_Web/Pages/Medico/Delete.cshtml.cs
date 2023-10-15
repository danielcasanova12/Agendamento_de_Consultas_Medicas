using Agenda_Web.ApiUrl;
using ClassModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Agenda_Web.Pages.Medico
{
    public class DeleteModel : PageModel
    {

        [BindProperty]
        public MedicoModel MedicoModel { get; set; } = new();
        public DeleteModel()
        {

        }

        public async Task<IActionResult> OnGetAsync(int? id) 
        {
            if (id == null) {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var url = $"http://localhost:5219/api/Medico/{id}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode) {
                return NotFound();
            }

            var content = await response.Content.ReadAsStringAsync();
            MedicoModel = JsonConvert.DeserializeObject<MedicoModel>(content)!;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var httpClient = new HttpClient();
            var url = $"http://localhost:5219/api/Medico/{id}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, url);
            var response = await httpClient.SendAsync(requestMessage);
            
            if (response.IsSuccessStatusCode) {
                return RedirectToPage("/Medico/Index");
            } else if (response.StatusCode == HttpStatusCode.NotFound) {
                return NotFound();
            } else {
                return Page();
            }
        }

    }
}
