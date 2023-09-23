using System;
using System.Net.Http;
using System.Threading.Tasks;
using Agenda_Web.ApiUrl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Agenda_Web.Pages.Especialidade
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

        [BindProperty]
        public ClassModels.EspecialidadeModel Especialidade { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiUrl = _apiUrls.Especialidade + $"/{id}";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Especialidade = JsonConvert.DeserializeObject<ClassModels.EspecialidadeModel>(content);

                    if (Especialidade == null)
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
            var apiUrl = $"{_apiUrls.Especialidade}/{id}"; 

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
                return BadRequest("Erro ao se conectar à API: " + ex.Message);
            }
        }
    }
}
