using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Agenda_Web.ApiUrl;
using ClassModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda_WebConsultas.Pages.Consultas
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;

        public CreateModel(IHttpClientFactory httpClientFactory, ApiUrls apiUrls)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiUrls = apiUrls;
        }

        [BindProperty]
        public ConsultaModel Consulta { get; set; }

        public List<MedicoModel> Medicos { get; set; }
        public List<PacienteModel> Pacientes { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                // Buscar médicos da API
                var medicosResponse = await _httpClient.GetAsync(_apiUrls.Medico);
                if (medicosResponse.IsSuccessStatusCode)
                {
                    var medicosContent = await medicosResponse.Content.ReadAsStringAsync();
                    Medicos = JsonSerializer.Deserialize<List<MedicoModel>>(medicosContent);
                }

                // Buscar pacientes da API
                var pacientesResponse = await _httpClient.GetAsync(_apiUrls.Paciente);
                if (pacientesResponse.IsSuccessStatusCode)
                {
                    var pacientesContent = await pacientesResponse.Content.ReadAsStringAsync();
                    Pacientes = JsonSerializer.Deserialize<List<PacienteModel>>(pacientesContent);
                }

                return Page();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao se conectar à API: " + ex.Message);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var apiUrl = _apiUrls.Consulta;

            try
            {
                var json = JsonSerializer.Serialize(Consulta);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Consultas/Index");
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
