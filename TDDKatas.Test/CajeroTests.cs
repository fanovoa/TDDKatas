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
    
    
    [Theory]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(50)]
    [InlineData(100)]
    [InlineData(200)]
    public void SiRetiraCantidadExactaDeDenominacionConfigurada_Debe_Regresar1deEsaDenominacionConfigurada(int cantidad)
    {
        var cajero = new Cajero();
        
        
        var denominaciones = cajero.Retirar(cantidad);
        
        
        denominaciones.Should().BeEquivalentTo( new List<(int, int)> { (1, cantidad) });
    }
}