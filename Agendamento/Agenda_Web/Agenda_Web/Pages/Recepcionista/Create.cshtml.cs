using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ClassModels;

namespace Agenda_Web.Pages.Recepcionista
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        //[BindProperty]
        //public ClassModels.RecepcionistaModel RecepcionistaModel { get; set; }

        public CreateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [BindProperty]
        public RecepcionistaModel Recepcionista { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var apiUrl = "http://localhost:5219/api/Recepcionista"; 
                var recepcionistaJson = JsonConvert.SerializeObject(Recepcionista);
                var content = new StringContent(recepcionistaJson, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Recepcionista/Index"); 
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao criar o recepcionista. Verifique os dados e tente novamente.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao processar a solicitação: " + ex.Message);
                return Page();
            }
        }
    }
}
