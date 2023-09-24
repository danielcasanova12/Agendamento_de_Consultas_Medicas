using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Agenda_Web.Pages.Recepcionista
{
    public class EditarModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;

        public ClassModels.EditarModelNewStruct1
        {
            _apiUrls = apiUrls;
            _httpClient = httpClientFactory.CreateClientNewStruct;
        }

        [BindProperty]
        public RecepcionistaEditModel Recepcionista { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiUrl = _apiUrls.Recepcionista + $"/{id}";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Recepcionista = JsonConvert.DeserializeObject<RecepcionistaEditModel>(content);

                    if (Recepcionista == null)
                    {
                        return NotFound();
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
            var apiUrl = $"https://localhost:7018/api/Recepcionista/{id}"; 

            try
            {
                var json = JsonConvert.SerializeObject(Recepcionista);
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

    internal record struct NewStruct1(ApiUrls apiUrls, IHttpClientFactory httpClientFactory)
    {
        public static implicit operator (ApiUrls apiUrls, IHttpClientFactory httpClientFactory)(NewStruct1 value)
        {
            return (value.apiUrls, value.httpClientFactory);
        }

        public static implicit operator NewStruct1((ApiUrls apiUrls, IHttpClientFactory httpClientFactory) value)
        {
            return new NewStruct1(value.apiUrls, value.httpClientFactory);
        }
    }
}
}
