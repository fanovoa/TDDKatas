using FluentAssertions;

namespace TDDKatas.Calculadora;

public class CalculadoraTest
{

    [Fact]
    public void Si_Ingreso_Vacio_DEBE_Retornar_IngreseNumeroValido()
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.ValidarCadena("");
        resultado.Should().Be("Ingrese un número válido.");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Si_Ingreso_Vacio_Nulo_DEBE_Retornar_IngreseNumeroValido(string cadena)
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.ValidarCadena(cadena);
        resultado.Should().Be("Ingrese un número válido.");
    }
    
    [Theory]
    [InlineData("a")]
    [InlineData("abc")]
    [InlineData("áéíóú")]
    [InlineData("ÁÉÍÓÚ")]
    [InlineData("camión")]
    public void Si_CadenaACalcular_Contiene_Letras_DEBE_Retornar_IngreseNumeroValido(string cadena)
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.ValidarCadena(cadena);
        resultado.Should().Be("Ingrese un número válido.");
    }
    
    [Theory]
    [InlineData("!")]
    [InlineData("@")]
    [InlineData("??")]
    public void Si_Cadena_Contiene_Simbolos_No_Operables_DEBE_Retornar_IngreseNumeroValido(string cadena)
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.ValidarCadena(cadena);
        resultado.Should().Be("Ingrese un número válido.");
    }
    
    [Fact]
    public void Si_Ingreso_Unicamente_Simbolos_Permitidos_Debe_Retornar_IngreseNumeroValido()
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.ValidarCadena("+");
        resultado.Should().Be("Ingrese un número válido.");
    }

    [Theory]
    [InlineData("+++")]
    [InlineData("///")]
    [InlineData("---")]
    [InlineData("*+-/")]
    [InlineData("+*-/")]
    [InlineData("-*+/")]
    [InlineData("-----")]
    public void Si_no_es_una_combinacion_valida_de_operadores_DEBE_Retornar_IngreseNumeroValido(string cadena)
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.ValidarCadena(cadena);
        resultado.Should().Be("Ingrese un número válido.");

    }
    
    [Theory]
    [InlineData("2","2")]
    [InlineData("-2","-2")]
    [InlineData("100","100")]
    public void Si_Ingreso_solo_un_numero_DEBE_Retornar_El_MismoNumero(string cadena, string esperado)
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.ValidarCadena(cadena);
        resultado.Should().Be(esperado);
    }

 
    [Theory]
    [InlineData("5+3","8")]
    [InlineData("10+11","21")]
    [InlineData("11+10","21")]
    [InlineData("-2+5","3")]
    public void Si_es_una_suma_DEBE_returnar_su_resultado(string cadena, string esperado)
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.ValidarCadena(cadena);
        resultado.Should().Be(esperado);
    }

    [Theory]
    [InlineData("5 + 3", "8")]
    public void Si_es_una_suma_que_contiene_espacios_DEBE_retornar_su_resultado(string cadena, string esperado)
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.ValidarCadena(cadena);
        resultado.Should().Be(esperado);
    }

    [Theory]
    [InlineData("5-3", "2")]
    [InlineData("2-3", "-1")]
    [InlineData("2 - 3", "-1")]
    public void Si_es_una_resta_DEBE_retornar_su_resultado(string cadena, string esperado)
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.ValidarCadena(cadena);
        resultado.Should().Be(esperado);
    }

    [Theory]
    [InlineData("2*2", "4")]
    [InlineData("10*10", "100")]
    [InlineData("100*0", "0")]
    [InlineData("5*5", "25")]
    [InlineData("5 * 5 ", "25")]
    public void Si_es_una_multiplicacion_DEBE_retornar_su_resultado(string cadena, string esperado)
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.ValidarCadena(cadena);
        resultado.Should().Be(esperado);
    }

    [Fact]
    public void Si_es_una_division_por_un_numero_diferente_a_cero_DEBE_retornar_su_resultado()
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.ValidarCadena("2/2");
        resultado.Should().Be("1");
    } 
}

