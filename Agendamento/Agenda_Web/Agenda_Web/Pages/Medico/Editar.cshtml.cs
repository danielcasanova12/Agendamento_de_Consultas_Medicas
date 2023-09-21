using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Agenda_Web.Pages.Medico
{
    public class EditarModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EditarModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public ClassModels.MedicoModel Medico { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            // Use o HttpClient para buscar os dados do médico na API
            var httpClient = _httpClientFactory.CreateClient();
            var apiUrl = $"https://localhost:7018/api/Medico/{id}";

            try
            {
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Medico = JsonConvert.DeserializeObject<ClassModels.MedicoModel>(content);
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

        [HttpPut]
        public async Task<IActionResult> OnPutAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Use o HttpClient para enviar os dados atualizados para a API
            var httpClient = _httpClientFactory.CreateClient();
            var apiUrl = $"https://localhost:7018/api/Medico/{id}";

            try
            {
                var json = JsonConvert.SerializeObject(Medico);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(apiUrl, content);

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
                    // Adicione um log ou verificação de erro aqui para depuração
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                // Adicione um log ou verificação de erro aqui para depuração
                return BadRequest("Erro ao se conectar à API: " + ex.Message);
            }
        }

    }
}
