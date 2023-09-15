using WebApiOrdenadores.Models;

namespace EjercicioOrdenador.Services;

public class FakeRepositorioComponentesAPI : IRepositorioComponente
{
    private readonly List<Componente>? _componentes = new();

    public FakeRepositorioComponentesAPI()
    {
        if (_componentes != null)
        {
            _componentes.Add(new Componente() { Id = 1, Serie = "789-XCS", Description = "Procesador Intel i7", Calor = 10, Precio = 134, Cores = 9, Megas = 0, Tipo = EnumTipoComponente.Procesador });
            _componentes.Add(new Componente() { Id = 2, Serie = "789-XCD", Description = "Procesador Intel i7", Calor = 12, Precio = 138, Cores = 10, Megas = 0, Tipo = EnumTipoComponente.Procesador });
            _componentes.Add(new Componente() { Id = 3, Serie = "789-XCT", Description = "Procesador Intel i7", Calor = 22, Precio = 138, Cores = 11, Megas = 0, Tipo = EnumTipoComponente.Procesador });
            _componentes.Add(new Componente() { Id = 4, Serie = "879FH", Description = "Banco de Memoria SDRAM", Calor = 10, Precio = 100, Cores = 0, Megas = 512, Tipo = EnumTipoComponente.Ram });
            _componentes.Add(new Componente() { Id = 5, Serie = "879FH-L", Description = "Banco de Memoria SDRAM", Calor = 15, Precio = 125, Cores = 0, Megas = 1024, Tipo = EnumTipoComponente.Ram });
            _componentes.Add(new Componente() { Id = 6, Serie = "879FH-T", Description = "Banco de Memoria SDRAM", Calor = 24, Precio = 150, Cores = 0, Megas = 2048, Tipo = EnumTipoComponente.Ram });
            _componentes.Add(new Componente() { Id = 7, Serie = "789-XX", Description = "DiscoDuro SanDisk", Calor = 10, Precio = 50, Cores = 0, Megas = 512000, Tipo = EnumTipoComponente.Rom });
            _componentes.Add(new Componente() { Id = 8, Serie = "789-XX-2", Description = "DiscoDuro SanDisk", Calor = 29, Precio = 90, Cores = 0, Megas = 1024000, Tipo = EnumTipoComponente.Rom });
            _componentes.Add(new Componente() { Id = 9, Serie = "789-XX-3", Description = "DiscoDuro SanDisk", Calor = 39, Precio = 128, Cores = 0, Megas = 2048000, Tipo = EnumTipoComponente.Rom });
            _componentes.Add(new Componente() { Id = 10, Serie = "797-X", Description = "Procesador Ryzen AMD", Calor = 30, Precio = 78, Cores = 10, Megas = 0, Tipo = EnumTipoComponente.Procesador });
            _componentes.Add(new Componente() { Id = 11, Serie = "797-X2", Description = "Procesador Ryzen AMD", Calor = 30, Precio = 178, Cores = 29, Megas = 0, Tipo = EnumTipoComponente.Procesador });
            _componentes.Add(new Componente() { Id = 12, Serie = "797-X3", Description = "Procesador Ryzen AMD", Calor = 60, Precio = 278, Cores = 34, Megas = 0, Tipo = EnumTipoComponente.Procesador });
            _componentes.Add(new Componente() { Id = 13, Serie = "788-fg", Description = "Disco Mecánico Patatin", Calor = 35, Precio = 37, Cores = 0, Megas = 250, Tipo = EnumTipoComponente.Rom });
            _componentes.Add(new Componente() { Id = 14, Serie = "788-fg-2", Description = "Disco Mecánico Patatin", Calor = 35, Precio = 67, Cores = 0, Megas = 250, Tipo = EnumTipoComponente.Rom });
            _componentes.Add(new Componente() { Id = 15, Serie = "788-fg-3", Description = "Disco Mecánico Patatin", Calor = 35, Precio = 97, Cores = 0, Megas = 250, Tipo = EnumTipoComponente.Rom });
            _componentes.Add(new Componente() { Id = 16, Serie = "1789-XCS", Description = "Disco Externo Sam", Calor = 10, Precio = 134, Cores = 0, Megas = 9216000, Tipo = EnumTipoComponente.Rom });
            _componentes.Add(new Componente() { Id = 17, Serie = "1789-XCD", Description = "Disco Externo Sam", Calor = 12, Precio = 138, Cores = 0, Megas = 10240000, Tipo = EnumTipoComponente.Rom });
            _componentes.Add(new Componente() { Id = 18, Serie = "1789-XCT", Description = "Disco Externo Sam", Calor = 22, Precio = 140, Cores = 0, Megas = 11264000, Tipo = EnumTipoComponente.Rom });
        }
    }
    public void AddComponente(Componente? componente)
    {
        if (_componentes != null)
        {
            var ultimoNumero = _componentes.Count + 1;
            if (componente != null) componente.Id = ultimoNumero;
        }

        if (_componentes != null && componente != null) _componentes.Add(componente);
    }

    public void DeleteComponente(int id)
    {
        if (_componentes != null)
        {
            var comp = _componentes.Find(x => x.Id == id);
            if (comp != null)
            {
                _componentes.RemoveAt(id);
            }
        }
    }

    public void Update(int id, Componente componente)
    {
        if (_componentes != null)
        {
            var componenteEditar = _componentes.First(x => x.Id == id);
            componenteEditar.Id = componente.Id;
            componenteEditar.Serie = componente.Serie;
            componenteEditar.Description = componente.Description;
            componenteEditar.Calor = componente.Calor;
            componenteEditar.Precio = componente.Precio;
            componenteEditar.Cores = componente.Cores;
            componenteEditar.Megas = componente.Megas;
            componenteEditar.Tipo = componente.Tipo;
            componenteEditar.OrdenadorId = componente.OrdenadorId;
        }
    }

    public Componente? GetComponente(int id)
    {
        if (_componentes != null) return _componentes.First(c => c.Id == id);
        return null;
    }

    public List<Componente>? ListaComponentes()
    {
        return _componentes;
    }


}