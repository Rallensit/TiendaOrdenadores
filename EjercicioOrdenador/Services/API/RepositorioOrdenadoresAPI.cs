using System.Text;
using EjercicioOrdenador.Models;
using Newtonsoft.Json;

namespace EjercicioOrdenador.Services.API
{
    public class RepositorioOrdenadoresAPI : IRepositorioOrdenador
    {
        private readonly HttpClient _httpClient;
        private const string UrlBase = "https://webapiordenadorescarlosalvarez.azurewebsites.net/api/Componente";

        public RepositorioOrdenadoresAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyHttpClient");
        }

        public List<Ordenador> ListaOrdenadores()
        {
            var url = UrlBase;
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;
            var lista = JsonConvert.DeserializeObject<List<Ordenador>>(response);
            if (lista == null) return new();

            return lista;
        }

        public Ordenador? GetOrdenador(int id)
        {
            var url = UrlBase + $"/{id}";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Ordenador>(response);
        }

        public void AddOrdenador(Ordenador item)
        {
            var url = UrlBase;
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.PostAsync(url, content);
        }

        public void Update(int id, Ordenador element)
        {
            var url = UrlBase;
            var json = JsonConvert.SerializeObject(element);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine(content);
            _httpClient.PutAsync(url, content);
        }

        public void DeleteOrdenador(int id)
        {
            var url = UrlBase + $"/{id}";
            _httpClient.DeleteAsync(url);
        }
    }
}
