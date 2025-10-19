using FluentAssertions;

namespace TDDKatas.Calculadora;

public class CalculadoraTest
{

    [Fact]
    public void Si_Ingreso_Vacio_DEBE_Retornar_IngreseNumeroValido()
    {
        var calculadora = new Calculadora("");
        var resultado = calculadora.ValidarCadena();
        resultado.Should().Be("Ingrese un número válido.");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Si_Ingreso_Vacio_Nulo_DEBE_Retornar_IngreseNumeroValido(string cadena)
    {
        var calculadora = new Calculadora(cadena);
        var resultado = calculadora.ValidarCadena();
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
        var calculadora = new Calculadora(cadena);
        var resultado = calculadora.ValidarCadena();
        resultado.Should().Be("Ingrese un número válido.");
    }
    
    [Theory]
    [InlineData("!")]
    [InlineData("@")]
    [InlineData("??")]
    public void Si_Cadena_Contiene_Simbolos_No_Operables_DEBE_Retornar_IngreseNumeroValido(string cadena)
    {
        var calculadora = new Calculadora(cadena);
        var resultado = calculadora.ValidarCadena();
        resultado.Should().Be("Ingrese un número válido.");
    }
    
    [Fact]
    public void Si_Ingreso_Unicamente_Simbolos_Permitidos_Debe_Retornar_IngreseNumeroValido()
    {
        var calculadora = new Calculadora("+");
        var resultado = calculadora.ValidarCadena();
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
        var calculadora = new Calculadora(cadena);
        var resultado = calculadora.ValidarCadena();
        resultado.Should().Be("Ingrese un número válido.");

    }
    
    [Theory]
    [InlineData("2","2")]
    [InlineData("-2","-2")]
    [InlineData("100","100")]
    public void Si_Ingreso_solo_un_numero_DEBE_Retornar_El_MismoNumero(string cadena, string esperado)
    {
        var calculadora = new Calculadora(cadena);
        var resultado = calculadora.ValidarCadena();
        resultado.Should().Be(esperado);
    }

    [Fact]
    public void Si_ingreso_5_mas_3_DEBE_Retornar_8()
    {
        var calculadora = new Calculadora("5+3");
        var resultado = calculadora.ValidarCadena();
        resultado.Should().Be("8");
    }

    [Fact]
    public void  Si_ingreso_10_mas_11_DEBE_Retornar_21()
    {
        var calculadora = new Calculadora("10+11");
        var resultado = calculadora.ValidarCadena();
        resultado.Should().Be("21");
    }
    
    
    [Fact]
    public void  Si_ingreso_11_mas_10_DEBE_Retornar_21()
    {
        var calculadora = new Calculadora("11+10");
        var resultado = calculadora.ValidarCadena();
        resultado.Should().Be("21");
    }
    
}

