using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Agenda_Web.ApiUrl;
using ClassModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Agenda_Web.Pages.Paciente
{
    public class Delete : PageModel
    {
        [BindProperty]
        public PacienteModel PacienteModel { get; set; } = new();
        public Delete()
        {

        }

        public async Task<IActionResult> OnGetAsync(int? id) 
        {
            if (id == null) {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var url = $"http://localhost:5219/api/Paciente/{id}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode) {
                return NotFound();
            }

            var content = await response.Content.ReadAsStringAsync();
            PacienteModel = JsonConvert.DeserializeObject<PacienteModel>(content)!;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var httpClient = new HttpClient();
            var url = $"http://localhost:5219/api/Paciente/{id}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, url);
            var response = await httpClient.SendAsync(requestMessage);
            
            if (response.IsSuccessStatusCode) {
                return RedirectToPage("/Paciente/Index");
            } else if (response.StatusCode == HttpStatusCode.NotFound) {
                return NotFound();
            } else {
                return Page();
            }
        }
    }
}