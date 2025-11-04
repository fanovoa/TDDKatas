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
}

public class Cajero
{
    public List<(int,int)> Retirar(int i)
    {
        return [(1,1)];
    }
}