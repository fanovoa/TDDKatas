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
    
    [Theory]
    [InlineData("an,a")]
    [InlineData("ana!")]
    [InlineData("*ana")]
    [InlineData("*a!?na")]
    public void Si_ingreso_una_palabra_palindroma_que_contenga_algunSimbolo_debe_retornar_true(string palabra)
    {
       var esPalindromo =ValidarSiEsLaPalabraEsPalindromo(palabra);
        esPalindromo.Should().Be(true);
    }
    
    private bool ValidarSiEsLaPalabraEsPalindromo(string palabra)
    {
        if (ContieneSimbolos(palabra))
            palabra = RemplazaSimbolos(palabra);
        
        var palabraAlReves = palabra.ToCharArray().Reverse();
        return palabra == new string(palabraAlReves.ToArray());
    }

    private static string RemplazaSimbolos(string palabra)
    {
        var quitarSimbolos = palabra
            .Where(char.IsLetterOrDigit)
            .ToArray();
        return  new string(quitarSimbolos);
    }

    private static bool ContieneSimbolos(string palabra)
    {
        return palabra.Any(caracter => char.IsLetterOrDigit(caracter));
       
    }
}