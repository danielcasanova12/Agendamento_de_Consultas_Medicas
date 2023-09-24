using System;
using System.Net.Http;
using System.Threading.Tasks;
using Agenda_Web.ApiUrl;
using ClassModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace Agenda_Web.Pages.Recepcionista
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;

        public ClassModels.DeleteModel(ApiUrls apiUrls,
                           IHttpClientFactory httpClientFactory)
        {
            _apiUrls = apiUrls;
            _httpClient = httpClientFactory.CreateClientNewStruct;
        }

        public ClassModels.RecepcionistaModel Recepcionista { get; private set; }

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

    internal struct NewStruct
    {
        public global::System.Object Item1;
        public global::System.Object Item2;

        public NewStruct(global::System.Object item1, global::System.Object item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public override global::System.Boolean Equals(global::System.Object obj)
        {
            return obj is NewStruct other &&
                   EqualityComparer<global::System.Object>.Default.Equals(Item1, other.Item1) &&
                   EqualityComparer<global::System.Object>.Default.Equals(Item2, other.Item2);
        }

        public override global::System.Int32 GetHashCode()
        {
            global::System.Int32 hashCode = -1030903623;
            hashCode = hashCode * -1521134295 + EqualityComparer<global::System.Object>.Default.GetHashCode(Item1);
            hashCode = hashCode * -1521134295 + EqualityComparer<global::System.Object>.Default.GetHashCode(Item2);
            return hashCode;
        }

        public void Deconstruct(out global::System.Object item1, out global::System.Object item2)
        {
            item1 = Item1;
            item2 = Item2;
        }

        public static implicit operator (global::System.Object, global::System.Object)(NewStruct value)
        {
            return (value.Item1, value.Item2);
        }

        public static implicit operator NewStruct((global::System.Object, global::System.Object) value)
        {
            return new NewStruct(value.Item1, value.Item2);
        }
    }
}
}
