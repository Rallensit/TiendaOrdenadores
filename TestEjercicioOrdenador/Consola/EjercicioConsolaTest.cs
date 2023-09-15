using EjercicioPC.Componentes.Clases;
using EjercicioPC.TiendaPC;
using EjercicioPC.Validators.Pc;
using EjercicioPC.Validators.Pedidos;

namespace TestEjercicioOrdenador.Consola
{
    [TestClass]
    public class EjercicioConsolaTest
    {
        private Ordenador? pcMaria;
        private Ordenador? pcAndres;
        private OrdenadorB? pcAndresCf;
        private OrdenadorB? pcTiburcio;
        private DiscoDuro? discoDuroTest;
        private Ram? ramTest;
        private Procesador? procesadorTest;
        readonly Pedido pedidoA = new();
        readonly Pedido pedidoB = new();
        readonly Factura facturaA = new();
        readonly Factura facturaB = new();
        readonly Factura facturaC = new();
        AlmacenamientoSecundario almacenamientoTiburcio = new();
        AlmacenamientoSecundario almacenamientoAndresCf = new();
        readonly Almacen almacen = new();


        AlmacenamientoSecundario almacenamientoSecundarioPrueba = new();
        private OrdenadorB? pcOrdenadorBPrueba;

        readonly IPcValidator pcValidator = new PcValidator();
        readonly IPedidoValidator pedidoValidator = new PedidoValidator();

        bool UseComponent(string serie)
        {
            return almacen.Use(serie);
        }

        Ordenador GetOrdenador(DiscoDuro rom, Procesador proc, Ram ram)
        {
            return new Ordenador(rom, proc, ram);
        }

        OrdenadorB GetOrdenadorComplejo(DiscoDuro rom, Procesador proc, Ram ram, AlmacenamientoSecundario secRom)
        {
            return new OrdenadorB(rom, proc, ram, secRom);
        }

        static DiscoDuro GetDiscoDuro(string serie, int calor, int mem, double precio)
        {
            return new DiscoDuro(serie, calor, mem, precio);
        }

        static Procesador GetProcesador(string serie, int calor, int cores, double precio)
        {
            return new Procesador(serie, calor, cores, precio);
        }

        static Ram GetRam(string serie, int calor, int mem, double precio)
        {
            return new Ram(serie, calor, mem, precio);
        }

        [TestInitialize]
        public void Init()
        {
            almacen.Add("789-XCS", 1);
            almacen.Add("789-XCD", 1);
            almacen.Add("789-XCT", 2);
            almacen.Add("9879FH", 2);
            almacen.Add("9879FH-L", 1);
            almacen.Add("9879FH-T", 1);
            almacen.Add("789-XX", 1);
            almacen.Add("789-XX-2", 2);
            almacen.Add("789-XX-3", 1);
            almacen.Add("797-X", 1);
            almacen.Add("797-X2", 2);
            almacen.Add("797-X3", 1);
            almacen.Add("788-fg", 1);
            almacen.Add("788-fg-2", 1);
            almacen.Add("788-fg-3", 1);
            almacen.Add("1789-XCS", 1);
            almacen.Add("1789-XCD", 1);
            almacen.Add("1789-XCT", 0);

            if (UseComponent("789-XX") && UseComponent("789-XCS") && UseComponent("9879FH"))
            {
                pcMaria = GetOrdenador(GetDiscoDuro("789-XX", 10, 500000, 50), GetProcesador("789-XCS", 10, 9, 134), GetRam("9879FH", 10, 512, 100));
                pedidoA.Add(pcMaria);
            }
            if (UseComponent("789-XX-3") && UseComponent("797-X3") && UseComponent("9879FH-T"))
            {
                pcAndres = GetOrdenador(GetDiscoDuro("789-XX-3", 39, 2000000, 128), GetProcesador("797-X3", 60, 34, 278), GetRam("9879FH-T", 24, 2000, 150));
                pedidoA.Add(pcAndres);
            }

            if (UseComponent("1789-XCS") && UseComponent("788-fg") && UseComponent("789-XX") && UseComponent("789-XCS") && UseComponent("9879FH"))
            {
                almacenamientoTiburcio.Add(GetDiscoDuro("1789-XCS", 10, 9000000, 134));
                almacenamientoTiburcio.Add(GetDiscoDuro("788-fg", 35, 250, 37));
                pcTiburcio = GetOrdenadorComplejo(GetDiscoDuro("789-XX", 10, 500000, 50), GetProcesador("789-XCS", 10, 9, 134), GetRam("9879FH", 10, 512, 100), almacenamientoTiburcio);
                pedidoB.Add(pcTiburcio);
            }

            if (UseComponent("789-XX-3") && UseComponent("788-fg") && UseComponent("797-X3") && UseComponent("9879FH-T"))
            {
                almacenamientoAndresCf.Add(GetDiscoDuro("789-XX-3", 39, 2000000, 128));
                pcAndresCf = GetOrdenadorComplejo(GetDiscoDuro("788-fg", 35, 250, 37), GetProcesador("797-X3", 60, 34, 278), GetRam("9879FH-T", 24, 2000, 150), almacenamientoAndresCf);
                pedidoB.Add(pcAndresCf);
            }

            discoDuroTest = GetDiscoDuro("a", 10, 10, 10);
            ramTest = GetRam("a", 10, 10, 10);
            procesadorTest = GetProcesador("a", 10, 8, 10);
            almacenamientoSecundarioPrueba.Add(GetDiscoDuro("1789-XCS", 10, 9000000, 134));
            almacenamientoSecundarioPrueba.Add(GetDiscoDuro("788-fg", 35, 250, 37));
            pcOrdenadorBPrueba = GetOrdenadorComplejo(GetDiscoDuro("789-XX", 10, 500000, 50), GetProcesador("789-XCS", 10, 9, 134), GetRam("9879FH", 10, 512, 100), almacenamientoSecundarioPrueba);

            facturaA.Add(pedidoA);

            facturaB.Add(pedidoB);

            facturaC.Add(pedidoA);
            facturaC.Add(pedidoB);
        }

        [TestMethod]
        public void TestComponents()
        {
            Assert.IsNotNull(discoDuroTest);
            Assert.AreEqual(10, discoDuroTest.Almacenamiento);
            Assert.IsNotNull(ramTest);
            Assert.AreEqual(10, ramTest.Almacenamiento);
            Assert.IsNotNull(procesadorTest);
            Assert.AreEqual(8, procesadorTest.Cores);
        }

        [TestMethod]
        public void TestAlmacenamientoSecundarioCount()
        {
            Assert.IsNotNull(almacenamientoSecundarioPrueba);
            Assert.AreEqual(2, almacenamientoSecundarioPrueba.Count());
        }

        [TestMethod]
        public void TestValidPedido()
        {
            Assert.IsNotNull(pedidoA);
            Assert.IsTrue(pedidoValidator.IsValid(pedidoA));
            Assert.IsNotNull(pedidoB);
            Assert.IsTrue(pedidoValidator.IsValid(pedidoB));
        }

        [TestMethod]
        public void TestPedidoNoCreado()
        {
            Assert.IsNotNull(pedidoB);
            Assert.AreEqual(0, pedidoB.Count());
        }

        [TestMethod]
        public void TestPedido()
        {
            Assert.IsNotNull(pedidoA);
            Assert.AreEqual(840, pedidoA.PrecioTotal, 0.1);
            Assert.AreEqual(153, pedidoA.CalorTotal, 0.1);
            Assert.AreEqual(2502512, pedidoA.EspacioTotal, 2000);
        }


        [TestMethod]
        public void TestValidPc()
        {
            Assert.IsNotNull(pcMaria);
            Assert.IsTrue(pcValidator.IsValid(pcMaria));
            Assert.IsNotNull(pcAndres);
            Assert.IsTrue(pcValidator.IsValid(pcAndres));
            Assert.IsNotNull(pcOrdenadorBPrueba);
            Assert.IsTrue(pcValidator.IsValid(pcOrdenadorBPrueba));
        }

        [TestMethod]
        public void TestCalorPc()
        {
            Assert.IsNotNull(pcMaria);
            Assert.AreEqual(30, pcMaria.GetCalor());
            Assert.IsNotNull(pcAndres);
            Assert.AreEqual(123, pcAndres.GetCalor());
            Assert.IsNotNull(pcOrdenadorBPrueba);
            Assert.AreEqual(75, pcOrdenadorBPrueba.GetCalor());

        }

        [TestMethod]
        public void TestPrecioPc()
        {
            Assert.IsNotNull(pcMaria);
            Assert.AreEqual(284, pcMaria.GetPrecio());
            Assert.IsNotNull(pcAndres);
            Assert.AreEqual(556, pcAndres.GetPrecio());
            Assert.IsNotNull(pcOrdenadorBPrueba);
            Assert.AreEqual(455, pcOrdenadorBPrueba.GetPrecio());
        }

        [TestMethod]
        public void TestAlmacenamientoPc()
        {
            Assert.IsNotNull(pcMaria);
            Assert.AreEqual(500512, pcMaria.GetAlmacenamiento());
            Assert.IsNotNull(pcAndres);
            Assert.AreEqual(2002000, pcAndres.GetAlmacenamiento());
            Assert.IsNotNull(pcOrdenadorBPrueba);
            Assert.AreEqual(9500762, pcOrdenadorBPrueba.GetAlmacenamiento());

        }

        [TestMethod]
        public void TestPedidoActions()
        {
            Assert.IsNotNull(pedidoA);
            pedidoA.Delete(1);
            Assert.AreEqual(1, pedidoA.Count());
            pedidoA.Clear();
            Assert.AreEqual(0, pedidoA.Count());
        }
    }
}
