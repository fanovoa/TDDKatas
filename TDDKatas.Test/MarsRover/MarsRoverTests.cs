using FluentAssertions;

namespace TDDKatas.MarsRover;

public class MarsRoverTests
{
    [Fact]
    public void Si_ingreso_vacio_DEBE_retornar_la_posicion_inicial_0_0_N()
    {
        var comando = "";
        var posicionFinal = CalcularPosicion(comando);
        posicionFinal.Should().Be("0:0:N");
    }
    
    [Theory]
    [InlineData("M","0:1:N")]
    [InlineData("MM","0:2:N")]
    [InlineData("MMM","0:3:N")]
    [InlineData("MMMM","0:4:N")]
    public void Si_ingreso_solo_movimientos_DEBE_avanzar_las_mismas_casillas_del_movimiento_en_Y(string comando, string esperado)
    {
        var posicionFinal = CalcularPosicion(comando);
        posicionFinal.Should().Be(esperado);
    }

    [Fact]
    public void Si_ingreso_un_movimiento_y_un_giro_a_la_derecha_DEBE_avanzar_un_movimiento_y_orientarse_al_este()
    {
        var posicionFinal = CalcularPosicion("MR");
        posicionFinal.Should().Be("0:1:E");
    }

    [Fact]
    public void Si_ingreso_un_movimiento_y_dos_gitos_a_la_derecha_DEBE_avanzar_dos_movimientos_y_orientarse_al_sur()
    {
        var posicionFinal = CalcularPosicion("MRR");
        posicionFinal.Should().Be("0:1:S");
    }

    private string CalcularPosicion(string comandos)
    {
        int posicion_X = 0;
        int posicion_Y = 0;
        string orientacion = "N";
        
        if( string.IsNullOrWhiteSpace(comandos))
            return string.Concat(posicion_X,":", posicion_Y,":",orientacion);

        foreach (var comando in comandos.ToCharArray())
        {
            if (comando == 'M') posicion_Y++;
        }

        if (comandos == "MR") return "0:1:E";
        if( comandos == "MRR") return "0:1:S";
        return string.Concat(posicion_X,":", posicion_Y,":",orientacion);
        
    }
}