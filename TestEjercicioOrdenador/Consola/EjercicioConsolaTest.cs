using EjercicioPCConsola.Componentes.Clases;
using EjercicioPCConsola.TiendaPC;
using EjercicioPCConsola.Validators.Pc;
using EjercicioPCConsola.Validators.Pedidos;

namespace TestEjercicioOrdenador.Consola;

[TestClass]
public class EjercicioConsolaTest
{
    private Ordenador? _pcMaria;
    private Ordenador? _pcAndres;
    private OrdenadorB? _pcAndresCf;
    private OrdenadorB? _pcTiburcio;
    private DiscoDuro? _discoDuroTest;
    private Ram? _ramTest;
    private Procesador? _procesadorTest;
    readonly Pedido _pedidoA = new();
    readonly Pedido _pedidoB = new();
    readonly Factura _facturaA = new();
    readonly Factura _facturaB = new();
    readonly Factura _facturaC = new();
    AlmacenamientoSecundario _almacenamientoTiburcio = new();
    AlmacenamientoSecundario _almacenamientoAndresCf = new();
    readonly Almacen _almacen = new();


    AlmacenamientoSecundario _almacenamientoSecundarioPrueba = new();
    private OrdenadorB? _pcOrdenadorBPrueba;

    readonly IPcValidator _pcValidator = new PcValidator();
    readonly IPedidoValidator _pedidoValidator = new PedidoValidator();

    bool UseComponent(string serie)
    {
        return _almacen.Use(serie);
    }

    Ordenador GetOrdenador(DiscoDuro rom, Procesador proc, Ram ram)
    {
        return new Ordenador(rom, proc, ram);
    }

    OrdenadorB GetOrdenadorComplejo(DiscoDuro rom, Procesador proc, Ram ram, AlmacenamientoSecundario secRom)
    {
        return new OrdenadorB(rom, proc, ram, secRom);
    }

    static DiscoDuro GetDiscoDuro(string? serie, int calor, int mem, double precio)
    {
        return new DiscoDuro(serie, calor, mem, precio);
    }

    static Procesador GetProcesador(string? serie, int calor, int cores, double precio)
    {
        return new Procesador(serie, calor, cores, precio);
    }

    static Ram GetRam(string? serie, int calor, int mem, double precio)
    {
        return new Ram(serie, calor, mem, precio);
    }

    [TestInitialize]
    public void Init()
    {
        _almacen.Add("789-XCS", 1);
        _almacen.Add("789-XCD", 1);
        _almacen.Add("789-XCT", 2);
        _almacen.Add("9879FH", 2);
        _almacen.Add("9879FH-L", 1);
        _almacen.Add("9879FH-T", 1);
        _almacen.Add("789-XX", 1);
        _almacen.Add("789-XX-2", 2);
        _almacen.Add("789-XX-3", 1);
        _almacen.Add("797-X", 1);
        _almacen.Add("797-X2", 2);
        _almacen.Add("797-X3", 1);
        _almacen.Add("788-fg", 1);
        _almacen.Add("788-fg-2", 1);
        _almacen.Add("788-fg-3", 1);
        _almacen.Add("1789-XCS", 1);
        _almacen.Add("1789-XCD", 1);
        _almacen.Add("1789-XCT", 0);

        if (UseComponent("789-XX") && UseComponent("789-XCS") && UseComponent("9879FH"))
        {
            _pcMaria = GetOrdenador(GetDiscoDuro("789-XX", 10, 500000, 50), GetProcesador("789-XCS", 10, 9, 134), GetRam("9879FH", 10, 512, 100));
            _pedidoA.Add(_pcMaria);
        }
        if (UseComponent("789-XX-3") && UseComponent("797-X3") && UseComponent("9879FH-T"))
        {
            _pcAndres = GetOrdenador(GetDiscoDuro("789-XX-3", 39, 2000000, 128), GetProcesador("797-X3", 60, 34, 278), GetRam("9879FH-T", 24, 2000, 150));
            _pedidoA.Add(_pcAndres);
        }

        if (UseComponent("1789-XCS") && UseComponent("788-fg") && UseComponent("789-XX") && UseComponent("789-XCS") && UseComponent("9879FH"))
        {
            _almacenamientoTiburcio.Add(GetDiscoDuro("1789-XCS", 10, 9000000, 134));
            _almacenamientoTiburcio.Add(GetDiscoDuro("788-fg", 35, 250, 37));
            _pcTiburcio = GetOrdenadorComplejo(GetDiscoDuro("789-XX", 10, 500000, 50), GetProcesador("789-XCS", 10, 9, 134), GetRam("9879FH", 10, 512, 100), _almacenamientoTiburcio);
            _pedidoB.Add(_pcTiburcio);
        }

        if (UseComponent("789-XX-3") && UseComponent("788-fg") && UseComponent("797-X3") && UseComponent("9879FH-T"))
        {
            _almacenamientoAndresCf.Add(GetDiscoDuro("789-XX-3", 39, 2000000, 128));
            _pcAndresCf = GetOrdenadorComplejo(GetDiscoDuro("788-fg", 35, 250, 37), GetProcesador("797-X3", 60, 34, 278), GetRam("9879FH-T", 24, 2000, 150), _almacenamientoAndresCf);
            _pedidoB.Add(_pcAndresCf);
        }

        _discoDuroTest = GetDiscoDuro("a", 10, 10, 10);
        _ramTest = GetRam("a", 10, 10, 10);
        _procesadorTest = GetProcesador("a", 10, 8, 10);
        _almacenamientoSecundarioPrueba.Add(GetDiscoDuro("1789-XCS", 10, 9000000, 134));
        _almacenamientoSecundarioPrueba.Add(GetDiscoDuro("788-fg", 35, 250, 37));
        _pcOrdenadorBPrueba = GetOrdenadorComplejo(GetDiscoDuro("789-XX", 10, 500000, 50), GetProcesador("789-XCS", 10, 9, 134), GetRam("9879FH", 10, 512, 100), _almacenamientoSecundarioPrueba);

        _facturaA.Add(_pedidoA);

        _facturaB.Add(_pedidoB);

        _facturaC.Add(_pedidoA);
        _facturaC.Add(_pedidoB);
    }

    [TestMethod]
    public void TestComponents()
    {
        Assert.IsNotNull(_discoDuroTest);
        Assert.AreEqual(10, _discoDuroTest.Almacenamiento);
        Assert.IsNotNull(_ramTest);
        Assert.AreEqual(10, _ramTest.Almacenamiento);
        Assert.IsNotNull(_procesadorTest);
        Assert.AreEqual(8, _procesadorTest.Cores);
    }

    [TestMethod]
    public void TestAlmacenamientoSecundarioCount()
    {
        Assert.IsNotNull(_almacenamientoSecundarioPrueba);
        Assert.AreEqual(2, _almacenamientoSecundarioPrueba.Count());
    }

    [TestMethod]
    public void TestValidPedido()
    {
        Assert.IsNotNull(_pedidoA);
        Assert.IsTrue(_pedidoValidator.IsValid(_pedidoA));
        Assert.IsNotNull(_pedidoB);
        Assert.IsTrue(_pedidoValidator.IsValid(_pedidoB));
    }

    [TestMethod]
    public void TestPedidoNoCreado()
    {
        Assert.IsNotNull(_pedidoB);
        Assert.AreEqual(0, _pedidoB.Count());
    }

    [TestMethod]
    public void TestPedido()
    {
        Assert.IsNotNull(_pedidoA);
        Assert.AreEqual(840, _pedidoA.PrecioTotal, 0.1);
        Assert.AreEqual(153, _pedidoA.CalorTotal, 0.1);
        Assert.AreEqual(2502512, _pedidoA.EspacioTotal, 2000);
    }


    [TestMethod]
    public void TestValidPc()
    {
        Assert.IsNotNull(_pcMaria);
        Assert.IsTrue(_pcValidator.IsValid(_pcMaria));
        Assert.IsNotNull(_pcAndres);
        Assert.IsTrue(_pcValidator.IsValid(_pcAndres));
        Assert.IsNotNull(_pcOrdenadorBPrueba);
        Assert.IsTrue(_pcValidator.IsValid(_pcOrdenadorBPrueba));
    }

    [TestMethod]
    public void TestCalorPc()
    {
        Assert.IsNotNull(_pcMaria);
        Assert.AreEqual(30, _pcMaria.GetCalor());
        Assert.IsNotNull(_pcAndres);
        Assert.AreEqual(123, _pcAndres.GetCalor());
        Assert.IsNotNull(_pcOrdenadorBPrueba);
        Assert.AreEqual(75, _pcOrdenadorBPrueba.GetCalor());

    }

    [TestMethod]
    public void TestPrecioPc()
    {
        Assert.IsNotNull(_pcMaria);
        Assert.AreEqual(284, _pcMaria.GetPrecio());
        Assert.IsNotNull(_pcAndres);
        Assert.AreEqual(556, _pcAndres.GetPrecio());
        Assert.IsNotNull(_pcOrdenadorBPrueba);
        Assert.AreEqual(455, _pcOrdenadorBPrueba.GetPrecio());
    }

    [TestMethod]
    public void TestAlmacenamientoPc()
    {
        Assert.IsNotNull(_pcMaria);
        Assert.AreEqual(500512, _pcMaria.GetAlmacenamiento());
        Assert.IsNotNull(_pcAndres);
        Assert.AreEqual(2002000, _pcAndres.GetAlmacenamiento());
        Assert.IsNotNull(_pcOrdenadorBPrueba);
        Assert.AreEqual(9500762, _pcOrdenadorBPrueba.GetAlmacenamiento());

    }

    [TestMethod]
    public void TestPedidoActions()
    {
        Assert.IsNotNull(_pedidoA);
        _pedidoA.Delete(1);
        Assert.AreEqual(1, _pedidoA.Count());
        _pedidoA.Clear();
        Assert.AreEqual(0, _pedidoA.Count());
    }
}