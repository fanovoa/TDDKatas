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
    
}

public class Cajero
{
    public List<(int,int)> Retirar(int cantidad)
    {
        var dinero = new List<(int, int)>();
        
        if (cantidad == 4)
        {
            dinero.Add((2,2));
        }

        if (cantidad == 2)
        {
            dinero.Add((1,2));
        };

        if (cantidad == 1)
        {
            dinero.Add((1,1));
        }
        return dinero;
    }
}