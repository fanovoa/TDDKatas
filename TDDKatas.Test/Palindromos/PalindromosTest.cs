using FluentAssertions;
namespace TDDKatas.Palindromos;

public class PalindromosTest
{
    [Theory]
    [InlineData("oro")]
    [InlineData("ana")]
    [InlineData("radar")]
    public void Si_ingreso_una_palabra_palindromo_en_minuscula_debe_retornar_true(string palabra)
    {
        //arrange
        var _palindromo =  new Palindromo(palabra);
        
        //act
        var esPalindromo = _palindromo.ValidarSiEsLaPalabraEsPalindromo();
        
        //assert
        esPalindromo.Should().Be(true);
    }
    
    [Theory]
    [InlineData("an,a")]
    [InlineData("ana!")]
    [InlineData("*ana")]
    [InlineData("*a!?na")]
    public void Si_ingreso_una_palabra_palindroma_que_contenga_algunSimbolo_debe_retornar_true(string palabra)
    {
        //arrange
        var _palindromo =  new Palindromo(palabra);
        
        //act
        var esPalindromo = _palindromo.ValidarSiEsLaPalabraEsPalindromo();
        
        //assert
        esPalindromo.Should().Be(true);
    }


    [Theory]
    [InlineData("ána")]
    [InlineData("rádar")]
    [InlineData("rotór")]
    public void Si_ingreso_una_palabra_palindroma_con_tilde_debe_retornar_true(string palabra)
    {
        //arrange
        var _palindromo =  new Palindromo(palabra);
        
        //act
        var esPalindromo = _palindromo.ValidarSiEsLaPalabraEsPalindromo();
        
        //assert
        esPalindromo.Should().Be(true);
    }
}