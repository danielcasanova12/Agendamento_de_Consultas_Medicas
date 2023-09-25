namespace Agenda_Web.ApiUrl
{
    public class ApiUrls
    {
        public string Medico { get; set; }
        public string Paciente { get; set; }
        public string Consulta { get; set; }
        public string Especialidade { get; set; }
        public string Recepcionista { get; set; }
        

        public ApiUrls()
        {
            //
        }

        public ApiUrls(string baseUrl)
        {
            Medico = $"{baseUrl}/api/Medico";
            Paciente = $"{baseUrl}/api/Paciente";
            Consulta = $"{baseUrl}/api/Consulta";
            Especialidade = $"{baseUrl}/api/Especialidade";
            Recepcionista = $"{baseUrl}/api/Recepcionista";
        }
    }



}
