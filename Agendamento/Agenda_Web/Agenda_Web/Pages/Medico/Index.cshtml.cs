using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda_Web.Pages.Consulta
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            // Injeção de dependência do HttpClient através do IHttpClientFactory
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // URL da sua API
            var apiUrl = "https://localhost:7018/api/Medico";

            try
            {
                // Realize a solicitação GET para a API
                var response = await _httpClient.GetAsync(apiUrl);

                // Verifique se a solicitação foi bem-sucedida (código 200)
                if (response.IsSuccessStatusCode)
                {
                    // Se a resposta for bem-sucedida, você pode processar os dados aqui
                    var content = await response.Content.ReadAsStringAsync();
                    // Faça algo com o conteúdo retornado
                    return Content(content, "application/json");
                }
                else
                {
                    // Se a resposta não for bem-sucedida, retorne um erro ou trate-o de acordo com suas necessidades
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (HttpRequestException)
            {
                // Lida com erros de solicitação HTTP
                return BadRequest("Erro ao se conectar à API.");
            }
        }
    }
}
