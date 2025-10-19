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
    public void Si_Ingresa_Un_Unico_Numero_DEBE_Retornar_El_MismoNumero()
    {
        var calculadora = new Calculadora("2");
        var resultado = calculadora.ValidarCadena();
        resultado.Should().Be("2");
    }

    [Fact]
    public void Si_Ingreso_Unicamente_Simbolos_Permitidos_Debe_Retornar_IngreseNumeroValido()
    {
        var calculadora = new Calculadora("+");
        var resultado = calculadora.ValidarCadena();
        resultado.Should().Be("Ingrese un número válido.");
    }
}

