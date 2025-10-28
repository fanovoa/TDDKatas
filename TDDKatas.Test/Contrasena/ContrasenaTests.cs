using FluentAssertions;

namespace TDDKatas.Contrasena;

public class ContrasenaTests
{
    [Fact]
    public void Si_LaContrasenaContieneMenosDe8Caracteres_DEBE_RetornarFalse()
    {
        var contrasena = "123";

        var validar = esValida(contrasena);

        validar.Should().Be(false);
    }

    [Fact]
    public void Si_LaContrasenaNoTieneMayusculas_DEBE_RetornarFalse()
    {
        var contrasena = "abcfgdfgdfs";

        var validar = esValida(contrasena);

        validar.Should().Be(false);
    }

    [Fact]
    public void Si_LaContrasenaNoTieneMinusculas_DEBE_RetornarFalse()
    {
        var contrasena = "ABCDEFGRTWDS";

        var validar = esValida(contrasena);

        validar.Should().Be(false);
    }

    private bool esValida(string contrasena)
    {
        if (contrasena.Length < 9) return false;
        if (contrasena.Count(char.IsUpper) ==0) return false;
        return true;

    }
}