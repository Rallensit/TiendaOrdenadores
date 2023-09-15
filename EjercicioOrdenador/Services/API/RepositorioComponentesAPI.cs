using System.Text;
using EjercicioOrdenador.Models;
using Newtonsoft.Json;

namespace EjercicioOrdenador.Services.API
{
    public class RepositorioComponentesAPI : IRepositorioComponente
    {
        private readonly HttpClient _httpClient;

        public RepositorioComponentesAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyHttpClient");
        }

        public List<Componente> ListaComponentes()
        {
            var url = "http://localhost:5245/api/Componente";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;
            var lista = JsonConvert.DeserializeObject<List<Componente>>(response);
            if (lista == null) return new();

            return lista;
        }

        public Componente? GetComponente(int id)
        {
            var url = $"http://localhost:5245/api/Componente/{id}";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Componente>(response);
        }

        public void AddComponente(Componente item)
        {
            var url = "http://localhost:5245/api/Componente";
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.PostAsync(url, content);
        }

        public void Update(int id, Componente element)
        {
            var url = "http://localhost:5245/api/Componente";
            var json = JsonConvert.SerializeObject(element);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine(content);
            _httpClient.PutAsync(url, content);
        }

        public void DeleteComponente(int id)
        {
            var url = $"http://localhost:5245/api/Componente/{id}";
            _httpClient.DeleteAsync(url);
        }
    }
}
