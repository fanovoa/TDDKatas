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

    private string ValidarCadena(string numero)
    {
        if (numero == "") return "Ingrese un número válido.";
        return "número válido";
    }
}