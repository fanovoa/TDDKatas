using FluentAssertions;

namespace TDDKatas.Calculadora;

public class CalculadoraTest
{
    [Fact]
    public void Si_Ingreso_Vacio_DEBE_Retornar_IngreseNumeroValido()
    {
        var numero = "";
        var resultado = ValidarCadena();
        resultado.Should().Be("Ingrese un número válido.");
    }

    private object ValidarCadena()
    {
        throw new NotImplementedException();
    }
}