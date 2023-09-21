using Agenda_Web.ApiUrl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;

namespace Agenda_Web.Pages.Medico
{
    public class IndexModel : PageModel
    {
        public List<ClassModels.MedicoModel> Medicos { get; set; }
        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;
        public IndexModel(ApiUrls apiUrls, IHttpClientFactory httpClientFactory)
        {
            _apiUrls = apiUrls;
            _httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var apiUrl = _apiUrls.Medico;
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Medicos = JsonConvert.DeserializeObject<List<ClassModels.MedicoModel>>(content);
                    return Page();
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                // Registre ou manipule a exceção de acordo com suas necessidades.
                return BadRequest("Erro ao se conectar à API: " + ex.Message);
            }
        }

    }
}
