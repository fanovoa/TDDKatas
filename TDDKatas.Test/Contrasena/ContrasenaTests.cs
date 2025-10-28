using FluentAssertions;

namespace TDDKatas.Contrasena;

public class ContrasenaTests
{
    

    [Fact]
    public void Si_LaContrasenaContieneMenosDe8Caracteres_DEBE_RetornarFalse()
    {
        var contrasena = new Validador("123");
        var validar = contrasena.esValida();
        validar.Should().Be(false);
    }

    [Fact]
    public void Si_LaContrasenaNoTieneMayusculas_DEBE_RetornarFalse()
    {
        var contrasena = new Validador("abcfgdfgdfs");
        var validar = contrasena.esValida();
        validar.Should().Be(false);
    }

    [Fact]
    public void Si_LaContrasenaNoTieneMinusculas_DEBE_RetornarFalse()
    {
        var contrasena = new Validador("ABCDEFGRTWDS");
        var validar = contrasena.esValida();
        validar.Should().Be(false);
    }
}