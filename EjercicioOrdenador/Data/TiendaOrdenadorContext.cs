using EjercicioOrdenador.Models;
using Microsoft.EntityFrameworkCore;

namespace EjercicioOrdenador.Data
{
	public class TiendaOrdenadorContext : DbContext
	{
		public TiendaOrdenadorContext(DbContextOptions<TiendaOrdenadorContext> options) : base(options)
		{
		}

		public DbSet<Componente>? Componentes { get; set; }
		public DbSet<Ordenador>? Ordenadores { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			new DbInitializer(modelBuilder).Seed();
		}
	}


}
