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
            // Inje��o de depend�ncia do HttpClient atrav�s do IHttpClientFactory
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // URL da sua API
            var apiUrl = "https://localhost:7018/api/Medico";

            try
            {
                // Realize a solicita��o GET para a API
                var response = await _httpClient.GetAsync(apiUrl);

                // Verifique se a solicita��o foi bem-sucedida (c�digo 200)
                if (response.IsSuccessStatusCode)
                {
                    // Se a resposta for bem-sucedida, voc� pode processar os dados aqui
                    var content = await response.Content.ReadAsStringAsync();
                    // Fa�a algo com o conte�do retornado
                    return Content(content, "application/json");
                }
                else
                {
                    // Se a resposta n�o for bem-sucedida, retorne um erro ou trate-o de acordo com suas necessidades
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (HttpRequestException)
            {
                // Lida com erros de solicita��o HTTP
                return BadRequest("Erro ao se conectar � API.");
            }
        }
    }
}
