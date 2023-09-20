namespace Agenda_Web.ApiUrl
{
    public class ApiUrls
    {
        public string Medico { get; set; }
        public string Paciente { get; set; }
        // Adicione outras URLs da API conforme necessário

        public ApiUrls()
        {
            // O construtor padrão vazio é necessário para a injeção de dependência
        }

        public ApiUrls(string baseUrl)
        {
            Medico = $"{baseUrl}/api/Medico";
            Paciente = $"{baseUrl}/api/Paciente";
            // Inclua outras URLs da API aqui
        }
    }



}
