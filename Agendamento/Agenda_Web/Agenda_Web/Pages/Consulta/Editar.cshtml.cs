using System;
using System.Net.Http;
using System.Threading.Tasks;
using Agenda_Web.ApiUrl;
using ClassModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Agenda_Web.Pages.Consultas
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
        public List<MedicoModel> Medicos { get; set; }
        public List<PacienteModel> Pacientes { get; set; }
        [BindProperty]
        public ClassModels.ConsultaModel Consulta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiUrl = _apiUrls.Consulta + $"/{id}";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Consulta = JsonConvert.DeserializeObject<ClassModels.ConsultaModel>(content);

                    if (Consulta == null)
                    {
                        return NotFound();
                    }

                    // Buscar a lista de médicos da API e atribuir a Medicos
                    var medicosResponse = await _httpClient.GetAsync(_apiUrls.Medico);
                    if (medicosResponse.IsSuccessStatusCode)
                    {
                        var medicosContent = await medicosResponse.Content.ReadAsStringAsync();
                        Medicos = JsonConvert.DeserializeObject<List<ClassModels.MedicoModel>>(medicosContent);
                    }
                    var pacientesResponse = await _httpClient.GetAsync(_apiUrls.Paciente);
                    if (pacientesResponse.IsSuccessStatusCode)
                    {
                        var pacientesContent = await pacientesResponse.Content.ReadAsStringAsync();
                        Pacientes = JsonConvert.DeserializeObject<List<ClassModels.PacienteModel>>(pacientesContent);
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
            var apiUrl = _apiUrls.Consulta + $"/{id}";

            try
            {
                var json = JsonConvert.SerializeObject(Consulta);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

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
