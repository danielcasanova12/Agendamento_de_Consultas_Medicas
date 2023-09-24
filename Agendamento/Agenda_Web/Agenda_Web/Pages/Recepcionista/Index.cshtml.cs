using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Agenda_Web.Pages.Recepcionista
{
    public class Index : PageModel
    {
        public List<RecepcionistaModel> Recepcionistas { get; set; }
        public Index()
        {
            
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var httpClient = new HttpClient();
            var url = "http://localhost:5219/api/Recepcionista";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();

            Recepcionistas = JsonConvert.DeserializeObject<List<RecepcionistaModel>>(content)!;
            
            return Page();
        }
    }
}