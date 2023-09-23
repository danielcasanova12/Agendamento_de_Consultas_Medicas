using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace Agenda_Web.Pages.Recepcionista
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

        public RecepcionistaModel Recepcionista { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiUrl = $"{_apiUrls.Recepcionista}/{id}";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Recepcionista = JsonConvert.DeserializeObject<RecepcionistaModel>(content);

                    if (Recepcionista == null)
                    {
                        return NotFound();
                    }

                    // Imprimir os dados no console
                    Console.WriteLine($"Dados do Recepcionista: ID={Recepcionista.IdRecepcionista}, Nome={Recepcionista.Nome}, Sobrenome={Recepcionista.Sobrenome}");

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
            var apiUrl = $"{_apiUrls.Recepcionista}/{id}"; 

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
