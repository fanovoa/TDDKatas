using FluentAssertions;

namespace TDDKatas.Calculadora;

public class CalculadoraTest
{
    [Fact]
    public void Si_Ingreso_Vacio_DEBE_Retornar_IngreseNumeroValido()
    {
        var cadena = "";
        var resultado = ValidarCadena(cadena);
        resultado.Should().Be("Ingrese un número válido.");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Si_Ingreso_Vacio_Nulo_DEBE_Retornar_IngreseNumeroValido(string cadena)
    {
        var resultado = ValidarCadena(cadena);
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
        var resultado = ValidarCadena(cadena);
        resultado.Should().Be("Ingrese un número válido.");
    }
    
    [Theory]
    [InlineData("!")]
    [InlineData("@")]
    [InlineData("??")]
    public void Si_Cadena_Contiene_Simbolos_No_Operables_DEBE_Retornar_IngreseNumeroValido(string cadena)
    {
        var resultado = ValidarCadena(cadena);
        resultado.Should().Be("Ingrese un número válido.");
    }

    private string ValidarCadena(string? numero)
    {
      
        
        const string MENSAJE_ERROR = "Ingrese un número válido.";
        if (numero == null) return MENSAJE_ERROR;
        
        numero = ConvertirAMinusculas(numero);
        if (EsVacioNulo(numero) || ContieneLetras(numero)) return MENSAJE_ERROR;
        if(ContieneSimbolosNoPermitidos(numero)) return MENSAJE_ERROR;

        return "número válido";
    }

    private bool ContieneSimbolosNoPermitidos(string numero)
    {
        string[] operadores = {"+","-","*","/"};
        return  operadores.Any( operador => !numero.Contains(operador));
    }

    private  string ConvertirAMinusculas(string numero) => numero.ToLower();

    private bool ContieneLetras(string numero) => numero.Any(char.IsLetter);

    private bool EsVacioNulo(string numero) => string.IsNullOrEmpty(numero);
}

