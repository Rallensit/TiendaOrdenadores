using EjercicioOrdenador.Models;
using Microsoft.EntityFrameworkCore;

namespace EjercicioOrdenador.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this._modelBuilder = modelBuilder;
        }

        public void Seed()
        {

            _modelBuilder.Entity<Ordenador>().HasData(
                new Ordenador() { Id = 1, Description = "Ordenador Maria" },
                new Ordenador() { Id = 2, Description = "Ordenador Andres" }
            );

            _modelBuilder.Entity<Componente>().HasData(
                new Componente() { Id = 1, Serie = "789-XCS", Description = "Procesador Intel i7", Calor = 10, Precio = 134, Cores = 9, Megas = 0, Tipo = EnumTipoComponente.Procesador, OrdenadorId = 1 },
                new Componente() { Id = 2, Serie = "789-XCD", Description = "Procesador Intel i7", Calor = 12, Precio = 138, Cores = 10, Megas = 0, Tipo = EnumTipoComponente.Procesador },
                new Componente() { Id = 3, Serie = "789-XCT", Description = "Procesador Intel i7", Calor = 22, Precio = 138, Cores = 11, Megas = 0, Tipo = EnumTipoComponente.Procesador },
                new Componente() { Id = 4, Serie = "879FH", Description = "Banco de Memoria SDRAM", Calor = 10, Precio = 100, Cores = 0, Megas = 512, Tipo = EnumTipoComponente.Ram, OrdenadorId = 1 },
                new Componente() { Id = 5, Serie = "879FH-L", Description = "Banco de Memoria SDRAM", Calor = 15, Precio = 125, Cores = 0, Megas = 1024, Tipo = EnumTipoComponente.Ram },
                new Componente() { Id = 6, Serie = "879FH-T", Description = "Banco de Memoria SDRAM", Calor = 24, Precio = 150, Cores = 0, Megas = 2048, Tipo = EnumTipoComponente.Ram, OrdenadorId = 2 },
                new Componente() { Id = 7, Serie = "789-XX", Description = "DiscoDuro SanDisk", Calor = 10, Precio = 50, Cores = 0, Megas = 512000, Tipo = EnumTipoComponente.Rom, OrdenadorId = 1 },
                new Componente() { Id = 8, Serie = "789-XX-2", Description = "DiscoDuro SanDisk", Calor = 29, Precio = 90, Cores = 0, Megas = 1024000, Tipo = EnumTipoComponente.Rom },
                new Componente() { Id = 9, Serie = "789-XX-3", Description = "DiscoDuro SanDisk", Calor = 39, Precio = 128, Cores = 0, Megas = 2048000, Tipo = EnumTipoComponente.Rom, OrdenadorId = 2 },
                new Componente() { Id = 10, Serie = "797-X", Description = "Procesador Ryzen AMD", Calor = 30, Precio = 78, Cores = 10, Megas = 0, Tipo = EnumTipoComponente.Procesador },
                new Componente() { Id = 11, Serie = "797-X2", Description = "Procesador Ryzen AMD", Calor = 30, Precio = 178, Cores = 29, Megas = 0, Tipo = EnumTipoComponente.Procesador },
                new Componente() { Id = 12, Serie = "797-X3", Description = "Procesador Ryzen AMD", Calor = 60, Precio = 278, Cores = 34, Megas = 0, Tipo = EnumTipoComponente.Procesador, OrdenadorId = 2 },
                new Componente() { Id = 13, Serie = "788-fg", Description = "Disco Mecánico Patatin", Calor = 35, Precio = 37, Cores = 0, Megas = 250, Tipo = EnumTipoComponente.Rom },
                new Componente() { Id = 14, Serie = "788-fg-2", Description = "Disco Mecánico Patatin", Calor = 35, Precio = 67, Cores = 0, Megas = 250, Tipo = EnumTipoComponente.Rom },
                new Componente() { Id = 15, Serie = "788-fg-3", Description = "Disco Mecánico Patatin", Calor = 35, Precio = 97, Cores = 0, Megas = 250, Tipo = EnumTipoComponente.Rom },
                new Componente() { Id = 16, Serie = "1789-XCS", Description = "Disco Externo Sam", Calor = 10, Precio = 134, Cores = 0, Megas = 9216000, Tipo = EnumTipoComponente.Rom },
                new Componente() { Id = 17, Serie = "1789-XCD", Description = "Disco Externo Sam", Calor = 12, Precio = 138, Cores = 0, Megas = 10240000, Tipo = EnumTipoComponente.Rom },
                new Componente() { Id = 18, Serie = "1789-XCT", Description = "Disco Externo Sam", Calor = 22, Precio = 140, Cores = 0, Megas = 11264000, Tipo = EnumTipoComponente.Rom }
            );
        }

    }
}