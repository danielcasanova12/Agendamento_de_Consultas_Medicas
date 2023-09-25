
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Agenda_Web.ApiUrl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda_Web.Pages.Medico
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;

        public CreateModel(IHttpClientFactory httpClientFactory, ApiUrls apiUrls)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiUrls = apiUrls;
            _httpClient.BaseAddress = new Uri(apiUrls.Medico);
        }

        [BindProperty]
        public ClassModels.MedicoModel Medico { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var apiUrl = _apiUrls.Medico;

            try
            {
                var json = JsonSerializer.Serialize(Medico);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Medico/Index"); // Redireciona para a p?gina de listagem de m?dicos ap?s a cria??o bem-sucedida
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (HttpRequestException)
            {
                return BadRequest("Erro ao se conectar ? API.");
            }
        }
    }
}