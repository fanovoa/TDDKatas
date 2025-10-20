using FluentAssertions;

namespace TDDKatas.MarsRover;

public class MarsRoverTests
{

    [Fact]
    public void Si_ingreso_vacio_DEBE_retornar_la_posicion_inicial_0_0_N()
    {
        //arrange
        var marsRover = new MarsRover();
        //act
        var posicionFinal = marsRover.CalcularPosicion("");
        //assert
        posicionFinal.Should().Be("0:0:N");
    }
    
    [Theory]
    [InlineData("M","0:1:N")]
    [InlineData("MM","0:2:N")]
    [InlineData("MMM","0:3:N")]
    [InlineData("MMMM","0:4:N")]
    public void Si_ingreso_solo_movimientos_DEBE_avanzar_las_mismas_casillas_del_movimiento_en_Y(string comando, string esperado)
    {
        //arrange
        var marsRover = new MarsRover();
        //act
        var posicionFinal = marsRover.CalcularPosicion(comando);
        //assert
        posicionFinal.Should().Be(esperado);
    }
    
    [Theory]
    [InlineData("MR","0:1:E")]
    [InlineData("MRR","0:1:S")]
    [InlineData("MRRR","0:1:W")]
    [InlineData("MRRRR","0:1:N")]
    public void Si_solo_avanza_una_posicion_y_gira_n_veces_a_la_derecha_DEBE_mantener_el_primer_movimento_y_solo_cambiar_su_orientacion(string comando, string posicionFinalEsperada)
    {
        
        //arrange
        var marsRover = new MarsRover();
        //act
        var posicionFinal = marsRover.CalcularPosicion(comando);
        //assert
        posicionFinal.Should().Be(posicionFinalEsperada);
    }
    [Fact]
    public void Si_ingreso_un_movimiento_y_un_giro_a_la_izquierda_DEBE_avanzar_un_movimieto_y_orientarse_al_oeste()
    {
        //arrange
        var marsRover = new MarsRover();
        //act
        var posicionFinal = marsRover.CalcularPosicion("ML");
        //assert
        posicionFinal.Should().Be("0:1:W");
    }

    [Fact]
    public void Si_ingreso_un_movimiento_giro_a_la_derecha_y_otro_movimiento_DEBE_orientarse_al_este_y_avanzar_en_x_como_en_y()
    {
        //arrange
        var marsRover = new MarsRover();
        //act
        var posicionFinal = marsRover.CalcularPosicion("MRM");
        //assert
        posicionFinal.Should().Be("1:1:E");
    }

    [Fact]
    public void Si_ingreso_un_movimiento_giro_a_la_izquierda_y_otro_movimiento_DEBE_orientarse_al_oeste_y_disminuir_en_x_y_avanzar_en_y()
    {
        //arrange
        var marsRover = new MarsRover();
        //act
        var posicionFinal = marsRover.CalcularPosicion("MLM");
        //assert
        posicionFinal.Should().Be("-1:1:W");
    }

    [Fact]
    public void Si_se_oriente_a_sur_y_avanza_n_posiciones_DEBE_disminuir_en_y_mantenerse_en_x()
    {
        //arrange
        var marsRover = new MarsRover();
        //act
        var posicionFinal = marsRover.CalcularPosicion("LLM");
        //assert
        posicionFinal.Should().Be("0:-1:S");
    }

    [Fact]
    public void  Si_supera_10_en_x_DEBE_volver_a_0()
    {
        //arrange
        var marsRover = new MarsRover();
        //act
        var posicionFinal = marsRover.CalcularPosicion("MMMMMMMMMMM");
        //assert
        posicionFinal.Should().Be("0:0:N");
    }

    [Fact]
    public void Si_supera_10_en_y_DEBE_volver_a_0()
    {
        //arrange
        var marsRover = new MarsRover();
        //act
        var posicionFinal = marsRover.CalcularPosicion("MRMMMMMMMMMMM");
        //assert
        posicionFinal.Should().Be("0:1:E");
    }
}