using Agenda_Web.ApiUrl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Agenda_Web.Pages.Medico
{
    public class DeleteModel : PageModel
    {

        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;

        public DeleteModel(ApiUrls apiUrls, IHttpClientFactory httpClientFactory)
        {
            _apiUrls = apiUrls;
            _httpClient = httpClientFactory.CreateClient();
        }

        public ClassModels.MedicoModel Medico { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiUrl = _apiUrls.Medico + $"/{id}";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Medico = JsonConvert.DeserializeObject<ClassModels.MedicoModel>(content);

                    if (Medico == null)
                    {
                        return NotFound();
                    }

                    // Imprimir os dados no console
                    Console.WriteLine($"Dados do M�dico: ID={Medico.IdMedico}, Nome={Medico.Nome}, Especialidade={Medico.Especialidade}");

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
                return BadRequest("Erro ao se conectar � API: " + ex.Message);
            }
        }


        public async Task<IActionResult> OnPostAsync(int id)
        {
            var apiUrl = $"{_apiUrls.Medico}/{id}"; // Construa a URL da API com o id

            try
            {
                var response = await _httpClient.DeleteAsync(apiUrl);

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
                return BadRequest("Erro ao se conectar � API: " + ex.Message);
            }
        }

    }
}