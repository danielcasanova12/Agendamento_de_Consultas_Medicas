using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Agenda_Web.ApiUrl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda_Web.Pages.Especialidade
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;

        public CreateModel(IHttpClientFactory httpClientFactory, ApiUrls apiUrls)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiUrls = apiUrls;
            _httpClient.BaseAddress = new Uri(apiUrls.Especialidade); 
        }

        private EspecialidadeModel especialidade;

        public ClassModels.EspecialidadeModel GetEspecialidade()
        {
            return especialidade;
        }

        public void SetEspecialidade(EspecialidadeModel value)
        {
            especialidade = value;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var apiUrl = _apiUrls.Especialidade; 

            try
            {
                var json = JsonSerializer.Serialize(GetEspecialidade());
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Especialidade/Index"); // Redireciona para a página de listagem de especialidades após a criação bem-sucedida
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
