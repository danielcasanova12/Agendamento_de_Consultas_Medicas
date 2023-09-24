using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Agenda_Web.ApiUrl; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Agenda_Web.Pages.Consulta
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;
        private ClassModels.ConsultaModel consulta;

        public CreateModel(IHttpClientFactory httpClientFactory, ApiUrls apiUrls)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiUrls = apiUrls;
            _httpClient.BaseAddress = new Uri(apiUrls.Consulta); 
        }

        [BindProperty]
        public ClassModels.ConsultaModel Consulta { get => consulta; set => consulta = value; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var apiUrl = _apiUrls.Consulta; 

            try
            {
                var json = JsonSerializer.Serialize(Consulta);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Consulta/Index"); 
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (HttpRequestException)
            {
                return BadRequest("Erro ao se conectar à API.");
            }
        }
    }
}
