using System.Text;
using EjercicioOrdenador.Models;
using Newtonsoft.Json;

namespace EjercicioOrdenador.Services.API;

public class RepositorioOrdenadoresApi : IRepositorioGenerico<Ordenador>
{
    private readonly HttpClient _httpClient;
    private const string UrlBase = "https://webapiordenadorescarlosalvarez.azurewebsites.net/api/Componente";

    public RepositorioOrdenadoresApi(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("MyHttpClient");
    }

    public List<Ordenador> Listar()
    {
        var url = UrlBase;
        var callResponse = _httpClient.GetAsync(url).Result;
        var response = callResponse.Content.ReadAsStringAsync().Result;
        var lista = JsonConvert.DeserializeObject<List<Ordenador>>(response);
        if (lista == null) return new();

        return lista;
    }

    public Ordenador? Obtener(int id)
    {
        var url = UrlBase + $"/{id}";
        var callResponse = _httpClient.GetAsync(url).Result;
        var response = callResponse.Content.ReadAsStringAsync().Result;

        return JsonConvert.DeserializeObject<Ordenador>(response);
    }

    public void Anadir(Ordenador item)
    {
        var url = UrlBase;
        var json = JsonConvert.SerializeObject(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        _httpClient.PostAsync(url, content);
    }

    public void Actualizar(int id, Ordenador element)
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