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

    [Fact]
    public void Si_ingreso_una_palabra_conComa_debe_retornar_true()
    {
        var esPalindromo =ValidarSiEsLaPalabraEsPalindromo("an,a");
        esPalindromo.Should().Be(true);
    }

    [Fact]
    public void Si_ingreso_una_palabra_conAsterisco_debe_retornar_true()
    {
        var esPalindromo =ValidarSiEsLaPalabraEsPalindromo("*ana");
        esPalindromo.Should().Be(true);
    }
    
    private bool ValidarSiEsLaPalabraEsPalindromo(string palabra)
    {
        if (palabra.Contains("!") || palabra.Contains(",") || palabra.Contains("*"))
            palabra = palabra.Replace("!", "").Replace(",", "").Replace("*","");
        var palabraAlReves = palabra.ToCharArray().Reverse();
        return palabra == new string(palabraAlReves.ToArray());
    }
}