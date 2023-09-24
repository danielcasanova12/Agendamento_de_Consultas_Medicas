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
    public class EditarModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;

        public EditarModel(ApiUrls apiUrls, IHttpClientFactory httpClientFactory)
        {
            _apiUrls = apiUrls;
            _httpClient = httpClientFactory.CreateClient();
        }

        [BindProperty]
        public ConsultaModel Consulta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiUrl = $"{_apiUrls.Consulta}/{id}";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Consulta = JsonConvert.DeserializeObject<ConsultaModel>(content);

                    if (Consulta == null)
                    {
                        return NotFound();
                    }

                    return Page();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao se conectar à API: " + ex.Message);
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var apiUrl = $"{_apiUrls.Consulta}/{id}"; 

            try
            {
                var json = JsonSerializer.Serialize(Consulta);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index"); 
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao se conectar à API: " + ex.Message);
            }
        }
    }
}
