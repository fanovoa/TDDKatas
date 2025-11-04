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
}

public class Cajero
{
    public List<(int,int)> Retirar(int i)
    {
        if (i == 2) return [(1, 2)];
        return [(1,1)];
    }
}