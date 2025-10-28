using FluentAssertions;

namespace TDDKatas.Contrasena;

public class ContrasenaTests
{
    

    [Fact]
    public void Si_LaContrasenaContieneMenosDe8Caracteres_DEBE_RetornarFalse()
    {
        var contrasena = new Validador("123");
        var validar = contrasena.EsValida();
        validar.Should().Be(false);
    }

    [Fact]
    public void Si_LaContrasenaNoTieneMayusculas_DEBE_RetornarFalse()
    {
        var contrasena = new Validador("abcfgdfgdfs");
        var validar = contrasena.EsValida();
        validar.Should().Be(false);
    }

    [Fact]
    public void Si_LaContrasenaNoTieneMinusculas_DEBE_RetornarFalse()
    {
        var contrasena = new Validador("ABCDEFGRTWDS");
        var validar = contrasena.EsValida();
        validar.Should().Be(false);
    }

    [Fact]
    public void Si_LaContrasenaNoTieneNumeros_DEBE_RetornarFalse()
    {
        var contrasena = new Validador("ASDFVASDaed");
        var validar = contrasena.EsValida();
        validar.Should().Be(false);
    }

    [Fact]
    public void Si_LaContrasenaNoTieneGuiones_DEBE_RetornarFalse()
    {
        var contrasena = new Validador("ASDFVASD2aed");
        var validar = contrasena.EsValida();
        validar.Should().Be(false);
    }

    [Fact]
    public void Si_LaContrasenaEsValida_DEBE_RetornarTrue()
    {
        var contrasena = new Validador("Aa12_43qwea");
        var validar = contrasena.EsValida();
        validar.Should().Be(true);
    }

    [Fact]
    public void SiLaContrasenaContieneMenos16Caracteres_DEBE_RetornarFalse()
    {
        var contrasena = new Validador("Aa12_43qwea");
        var validar = contrasena.EsValida();
        validar.Should().Be(false);
    }

}