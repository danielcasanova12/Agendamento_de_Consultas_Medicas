using Agenda_Web.ApiUrl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Agenda_Web.Pages
{
    public class ConsultasModel : PageModel
    {
        public List<ClassModels.ConsultaModel> Consultas { get; set; }
        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;

        public ConsultasModel(ApiUrls apiUrls, IHttpClientFactory httpClientFactory)
        {
            _apiUrls = apiUrls;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var apiUrl = _apiUrls.Consulta; // Certifique-se de que você tem uma URL correta para listar as consultas
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Consultas = JsonConvert.DeserializeObject<List<ClassModels.ConsultaModel>>(content);
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
