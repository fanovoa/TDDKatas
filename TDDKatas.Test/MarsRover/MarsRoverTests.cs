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

    [Fact]
    public void Si_ingreso_un_movimiento_y_tres_giros_a_la_derecha_DEBE_avanzar_dos_movimientos_y_orientarse_al_oeste()
    {
        var posicionFinal = CalcularPosicion("MRRR");
        posicionFinal.Should().Be("0:1:W");
    }

    [Fact]
    public void Si_ingreso_un_movimento_y_cuatro_giros_a_la_derecha_DEBE_avanzar_un_movimiento_y_orientarse_al_norte()
    {
        var posicionFinal = CalcularPosicion("MRRRR");
        posicionFinal.Should().Be("0:1:N");
    }

    [Fact]
    public void Si_ingreso_un_movimiento_y_un_giro_a_la_izquierda_DEBE_avanzar_un_movimieto_y_orientarse_al_oeste()
    {
        var posicionFinal = CalcularPosicion("ML");
        posicionFinal.Should().Be("0:1:W");
    }

    [Fact]
    public void Si_ingreso_un_movimiento_giro_a_la_derecha_y_otro_movimiento_DEBE_orientarse_al_este_y_avanzar_en_x_como_en_y()
    {
        var posicionFinal = CalcularPosicion("MRM");
        posicionFinal.Should().Be("1:1:E");
    }

    [Fact]
    public void Si_ingreso_un_movimiento_giro_a_la_izquierda_y_otro_movimiento_DEBE_orientarse_al_oeste_y_disminuir_en_x_y_avanzar_en_y()
    {
        var posicionFinal = CalcularPosicion("MLM");
        posicionFinal.Should().Be("-1:1:W");
    }
    private string CalcularPosicion(string comandos)
    {
        int posicion_X = 0;
        int posicion_Y = 0;
        int orientacion_inicial = 0;
        char[] orientacion = ['N','E','S','W'];
        
        foreach (var comando in comandos.ToCharArray())
        {
            if (comando == 'M')
            {
                if (orientacion[orientacion_inicial] == 'E') posicion_X++;
                else posicion_Y++;
            }
            if (comando == 'R') orientacion_inicial++;
            if (comando == 'L') orientacion_inicial--;
            
            if(orientacion_inicial >3 ) orientacion_inicial = 0;
            if (orientacion_inicial <0 ) orientacion_inicial = 3;
            
        }
        
        return string.Concat(posicion_X,":", posicion_Y,":",orientacion[orientacion_inicial]);
        
    }
}