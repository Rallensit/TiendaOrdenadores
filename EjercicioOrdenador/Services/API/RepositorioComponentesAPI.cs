using System.Text;
using EjercicioOrdenador.Models;
using Newtonsoft.Json;

namespace EjercicioOrdenador.Services.API;

public class RepositorioComponentesApi : IRepositorioGenerico<Componente>
{
    private readonly HttpClient _httpClient;
    private const string UrlBase = "https://webapiordenadorescarlosalvarez.azurewebsites.net/api/Componente";

    public RepositorioComponentesApi(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("MyHttpClient");
    }

    public List<Componente> Listar()
    {
        var url = UrlBase;
        var callResponse = _httpClient.GetAsync(url).Result;
        var response = callResponse.Content.ReadAsStringAsync().Result;
        var lista = JsonConvert.DeserializeObject<List<Componente>>(response);
        if (lista == null) return new();

        return lista;
    }

    public Componente? Obtener(int id)
    {
        var url = UrlBase + $"/{id}";
        var callResponse = _httpClient.GetAsync(url).Result;
        var response = callResponse.Content.ReadAsStringAsync().Result;

        return JsonConvert.DeserializeObject<Componente>(response);
    }

    public void Anadir(Componente item)
    {
        var url = UrlBase;
        var json = JsonConvert.SerializeObject(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        _httpClient.PostAsync(url, content);
    }

    public void Actualizar(int id, Componente element)
    {
        var url = UrlBase;
        var json = JsonConvert.SerializeObject(element);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        Console.WriteLine(content);
        _httpClient.PutAsync(url, content);
    }

    public void Borrar(int id)
    {
        var url = UrlBase + $"/{id}";
        _httpClient.DeleteAsync(url);
    }
}