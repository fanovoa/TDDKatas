using FluentAssertions;

namespace TDDKatas;

public class CajeroTests
{
   
    
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(20)]
    [InlineData(50)]
    [InlineData(100)]
    [InlineData(200)]
    [InlineData(500)]
    public void SiRetiraCantidadExactaDeDenominacionConfigurada_Debe_Regresar1deEsaDenominacionConfigurada(int cantidad)
    {
        var cajero = new Cajero();
        
        
        var denominaciones = cajero.Retirar(cantidad);
        
        
        denominaciones.Should().BeEquivalentTo( new List<(int, int)> { (1, cantidad) });
    }

    
    [Theory]
    [MemberData(nameof(CasosCombinados))]
    public void SiRetiraUnaDenominacionInexacta_Debe_RegresarlasDenominacionesEsperadas(int cantidad, List<(int,int)> combinacionEsperada)
    {
        var cajero = new Cajero();
        
        var denominaciones = cajero.Retirar(cantidad);
        
        denominaciones.Should().BeEquivalentTo( combinacionEsperada);
    }


    public static IEnumerable<object[]> CasosCombinados()
    {
        yield return [4, new List<(int,int)>{ (2,2)}];
        yield return [6, new List<(int,int)>{ (1,5), (1,1)}];
        yield return [432, new List<(int,int)>{ (2,200), (1,20),(1,10),(1,2)}];
    }
}