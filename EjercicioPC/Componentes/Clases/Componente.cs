using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjercicioPC.Componentes.Interfaces;

namespace EjercicioPC.Componentes.Clases
{
	public class Componente : ICalor, IPriceable, ISeriable
	{
		public int Calor { get; set; }
		public double Precio { get; set; }
		public string Serie { get; set; }
	}
}
