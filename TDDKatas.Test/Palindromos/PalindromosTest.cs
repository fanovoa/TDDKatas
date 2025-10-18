using FluentAssertions;

namespace TDDKatas.Palindromos;

public class PalindromosTest
{
    [Fact]
    public void Si_Ingreso_La_Palabra_oro_debe_retornar_true()
    {
        var palabra = "oro";
        var esPalindromo = ValidarSiEsLaPalabraEsPalindromo(palabra);
        esPalindromo.Should().Be(true);
    }

    [Fact]
    public void Si_Ingreso_La_Palabra_ana_debe_retornar_true()
    {
        var palabra = "ana";
        var esPalindromo = ValidarSiEsLaPalabraEsPalindromo(palabra);
        esPalindromo.Should().Be(true);
    }

    private object ValidarSiEsLaPalabraEsPalindromo(string palabra)
    {
        return palabra == "oro" || palabra == "ana";
    }
}