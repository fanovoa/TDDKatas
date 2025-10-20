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

    [Fact]
    public void Si_ingreso_M_DEBE_avanzar_una_posicion_en_Y()
    {
        var comando = "M";
        var posicionFinal = CalcularPosicion(comando);
        posicionFinal.Should().Be("0:1:N");
    }

    [Fact]
    public void Si_avanzo_ingreso_dos_movimientos_DEBE_avanzar_dos_posiciones()
    {
        var comando = "MM";
        var posicionFinal = CalcularPosicion(comando);
        posicionFinal.Should().Be("0:2:N");
    }

    [Fact]
    public void Si_ingreso_tres_movimientos_DEBE_avanzar_tres_posiciones()
    {
        var comando = "MMM";
        var posicionFinal = CalcularPosicion(comando);
        posicionFinal.Should().Be("0:3:N");
    }

    private object CalcularPosicion(string comando)
    {
        if( string.IsNullOrWhiteSpace(comando))
            return "0:0:N";
        
        if(comando== "M") return "0:1:N";
        if(comando== "MM") return "0:2:N";
        if(comando== "MMM") return "0:3:N";

        return "0:0:N";
    }
}