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
    
    [Theory]
    [InlineData("Amar da drama")]
    [InlineData("Ateo por Arabia, iba raro poeta.")]
    [InlineData("El bar es imán o zona miserable.")]
    [InlineData("Isaac no ronca así")]
    [InlineData("Allí, tieta Mercè, faci cafè, crema, te i til·la")]
    public void Si_ingreso_un_texto_palindromo_combinadoMayusculasMinusculas_con_espacios_debe_retornar_true(string texto)
    {
        //arrange
        var _palindromo =  new Palindromo(texto);
        
        //act
        var esPalindromo = _palindromo.ValidarSiEsLaPalabraEsPalindromo();
        
        //assert
        esPalindromo.Should().Be(true);
        
    }


    [Theory]
    [InlineData("!!!!!!!")]
    [InlineData("??//>>,,,")]
    [InlineData("@@@%*&-+")]
    public void Si_ingresa_solo_simbolos_debe_retornar_false(string texto)
    {
        //arrange
        var _palindromo =  new Palindromo(texto);
        
        //act
        var esPalindromo = _palindromo.ValidarSiEsLaPalabraEsPalindromo();
        
        //assert
        esPalindromo.Should().Be(false);
    }

    [Fact]
    public void Si_ingresa_null_debe_retornar_false()
    {
        //arrange
        var _palindromo =  new Palindromo(null);
        
        //act
        var esPalindromo = _palindromo.ValidarSiEsLaPalabraEsPalindromo();
        
        //assert
        esPalindromo.Should().Be(false);
    }
}