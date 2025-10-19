using FluentAssertions;
using Xunit.Sdk;

namespace TDDKatas.Palindromos;

public class PalindromosTest
{
    [Theory]
    [InlineData("oro")]
    [InlineData("ana")]
    [InlineData("radar")]
    public void Si_ingreso_una_palabra_palindromo_en_minuscula_debe_retornar_true(string palabra)
    {
        var esPalindromo = ValidarSiEsLaPalabraEsPalindromo(palabra);
        esPalindromo.Should().Be(true);
    }

    [Fact]
    public void Si_ingreso_una_palabra_conSignoAdmiracion_debe_retornar_true()
    {
        var esPalindromo =ValidarSiEsLaPalabraEsPalindromo("ana!");
        esPalindromo.Should().Be(true);
    }
    
    private bool ValidarSiEsLaPalabraEsPalindromo(string palabra)
    {
        var palabraAlReves = palabra.ToCharArray().Reverse();
        return palabra == new string(palabraAlReves.ToArray());
    }
}