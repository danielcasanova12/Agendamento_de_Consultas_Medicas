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
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

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
                    var content = await medicosResponse.Content.ReadAsStringAsync();
                    Medicos = JsonConvert.DeserializeObject<List<MedicoModel>>(content);
                }

                // Buscar pacientes da API
                var pacientesResponse = await _httpClient.GetAsync(_apiUrls.Paciente);
                if (pacientesResponse.IsSuccessStatusCode)
                {

                    var pacientesContent = await pacientesResponse.Content.ReadAsStringAsync();
                    Pacientes = JsonConvert.DeserializeObject<List<PacienteModel>>(pacientesContent);
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
            var apiUrl = "https://localhost:7018/api/Consulta";
            try
            {
                // Ajuste os valores da Consulta conforme necessário
                ConsultaModel consulta = new ConsultaModel
                {
                    ConsultaMedica = new ConsultaMedicaModel
                    {
                        Medico = new MedicoModel { IdMedico = 11 }, // Exemplo de ID de médico
                        Paciente = new PacienteModel { IdPaciente = 12 }, // Exemplo de ID de paciente
                        DataHora = DateTime.Now, // Data e hora atual (ou qualquer outra data desejada)
                        Tipo = 0, // Tipo da consulta
                        Observacoes = "Observações da consulta" // Opcional
                    }
                };

                // Serialize o objeto Consulta para JSON
                var json = System.Text.Json.JsonSerializer.Serialize(consulta);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Consulta/Index");
                }
                else
                {
                    Console.WriteLine(content);
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (HttpRequestException)
            {
                return BadRequest("Erro ao se conectar à API.");
            }
        }

    }

    public class ConsultaModel
    {
        public ConsultaMedicaModel ConsultaMedica { get; set; }
    }

    public class ConsultaMedicaModel
    {
        public MedicoModel Medico { get; set; }
        public PacienteModel Paciente { get; set; }
        public DateTime DataHora { get; set; }
        public int Tipo { get; set; }
        public string Observacoes { get; set; }
    }
}
