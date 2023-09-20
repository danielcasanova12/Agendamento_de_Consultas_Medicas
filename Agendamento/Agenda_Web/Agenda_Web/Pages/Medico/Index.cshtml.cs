using System.Net.Http;
using System.Threading.Tasks;
using Agenda_Web.ApiUrl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda_Web.Pages.Consulta
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;

        public IndexModel(IHttpClientFactory httpClientFactory, ApiUrls apiUrls)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiUrls = apiUrls;
            _httpClient.BaseAddress = new Uri(apiUrls.Medico);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var apiUrl = _apiUrls.Medico;

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Content(content, "application/json");
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
