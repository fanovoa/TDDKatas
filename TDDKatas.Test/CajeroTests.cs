using FluentAssertions;

namespace TDDKatas;

public class CajeroTests
{
    [Fact]
    public void SiRetira1_Debe_Regresar1de1()
    {
        var cajero = new Cajero();
        var denominaciones = cajero.Retirar(1);
        denominaciones.Should().BeEquivalentTo((new List<(int, int)>{(1,1)}));
    }
    
    [Fact]
    public void SiRetira2_Debe_Regresar1de2()
    {
        var cajero = new Cajero();
        var denominaciones = cajero.Retirar(2);
        denominaciones.Should().BeEquivalentTo((new List<(int, int)>{(1, 2)}));
    }
    [Fact]
    public void SiRetira4_Debe_Regresar2de2()
    {
        var cajero = new Cajero();
        var denominaciones = cajero.Retirar(4);
        denominaciones.Should().BeEquivalentTo((new List<(int, int)>{(2, 2)}));
    }

    [Fact]
    public void SiRetira5_Debe_Regresar1de5()
    {
        var cajero = new Cajero();
        var denominaciones = cajero.Retirar(5);
        denominaciones.Should().BeEquivalentTo((new List<(int, int)>{(1, 5)}));
    }

    [Fact]
    public void SiRetira6_Debe_Regresar1de5y1de1()
    {
        var cajero = new Cajero();
        var denominaciones = cajero.Retirar(6);
        denominaciones.Should().BeEquivalentTo((new List<(int, int)>{(1, 5),(1,1)}));
    }

    [Fact]
    public void SiRetira10_Debe_Regresar1de10()
    {
        var cajero = new Cajero();
        var denominaciones = cajero.Retirar(10);
        denominaciones.Should().BeEquivalentTo((new List<(int, int)>{(1, 10)}));
    }

    [Fact]
    public void SiRetira20_Debe_Regresar1de20()
    {
        var cajero = new Cajero();
        var denominaciones = cajero.Retirar(12);
        denominaciones.Should().BeEquivalentTo((new List<(int, int)>{(1, 20)}));
    }
}