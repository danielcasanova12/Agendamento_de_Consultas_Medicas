using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Agenda_Web.ApiUrl;
using ClassModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Agenda_Web.Pages.Especialidade
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        //[BindProperty]
        //public ClassModels.RecepcionistaModel RecepcionistaModel { get; set; }

        public CreateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [BindProperty]
        public EspecialidadeModel Especialidade { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var apiUrl = "http://localhost:5219/api/Especialidade"; 
                var especialidadeJson = JsonConvert.SerializeObject(Especialidade);
                var content = new StringContent(especialidadeJson, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Especialidade/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao criar o recepcionista. Verifique os dados e tente novamente.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao processar a solicitação: " + ex.Message);
                return Page();
            }
        }

        // private readonly HttpClient _httpClient;
        // private readonly ApiUrls _apiUrls;

        // public CreateModel(IHttpClientFactory httpClientFactory, ApiUrls apiUrls)
        // {
        //     _httpClient = httpClientFactory.CreateClient();
        //     _apiUrls = apiUrls;
        //     _httpClient.BaseAddress = new Uri(apiUrls.Especialidade); 
        // }

        // [BindProperty]
        // public EspecialidadeModel Especialidade { get; set; }

        // private EspecialidadeModel especialidade;

        // public ClassModels.EspecialidadeModel GetEspecialidade()
        // {
        //     return especialidade;
        // }

        // public void SetEspecialidade(EspecialidadeModel value)
        // {
        //     especialidade = value;
        // }

        // public void OnGet()
        // {
        // }

        // public async Task<IActionResult> OnPostAsync()
        // {
        //     var apiUrl = _apiUrls.Especialidade; 

        //     try
        //     {
        //         var json = JsonSerializer.Serialize(GetEspecialidade());
        //         var content = new StringContent(json, Encoding.UTF8, "application/json");

        //         var response = await _httpClient.PostAsync(apiUrl, content);

        //         if (response.IsSuccessStatusCode)
        //         {
        //             return RedirectToPage("/Especialidade/Index"); // Redireciona para a página de listagem de especialidades após a criação bem-sucedida
        //         }
        //         else
        //         {
        //             return StatusCode((int)response.StatusCode);
        //         }
        //     }
        //     catch (HttpRequestException)
        //     {
        //         return BadRequest("Erro ao se conectar à API.");
        //     }
        // }
    }
}
