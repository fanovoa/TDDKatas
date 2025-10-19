using FluentAssertions;

namespace TDDKatas.Calculadora;

public class CalculadoraTest
{
    [Fact]
    public void Si_Ingreso_Vacio_DEBE_Retornar_IngreseNumeroValido()
    {
        var numero = "";
        var resultado = ValidarCadena(numero);
        resultado.Should().Be("Ingrese un número válido.");
    }

    [Fact]
    public void Si_Ingreso_la_letra_a_DEBE_Retornar_IngreseNumeroValido()
    {
        var numero = "a";
        var resultado = ValidarCadena(numero);
        resultado.Should().Be("Ingrese un número válido.");
    }

    [Fact]
    public void Si_Ingreso_contiene_tres_letras_DEBE_Retornar_IngreseNumeroValido()
    {
        var numero = "abc";
        var resultado = ValidarCadena(numero);
        resultado.Should().Be("Ingrese un número válido.");
    }

    [Fact]
    public void Si_Ingreso_contiene_letras_acentuadas_DEBE_Retornar_IngreseNumeroValido()
    {
        var numero = "áéíóú";
        var resultado = ValidarCadena(numero);
        resultado.Should().Be("Ingrese un número válido.");
    
    }

    [Fact]
    public void Si_Ingreso_contiene_letras_acentuadasMayusculas_DEBE_Retornar_IngreseNumeroValido()
    {
        var numero = "  ÁÉÍÓÚ";
        var resultado = ValidarCadena(numero);
        resultado.Should().Be("Ingrese un número válido.");
    }

    private string ValidarCadena(string numero)
    {
        numero = numero.ToLower();
        if (numero == "" || numero=="a" || numero.Contains("abc")) return "Ingrese un número válido.";
        if (numero.Contains("á") || numero.Contains('é') || numero.Contains('í') || numero.Contains('ó') ||
            numero.Contains('ú')) return "Ingrese un número válido.";
        
        return "número válido";
    }
}