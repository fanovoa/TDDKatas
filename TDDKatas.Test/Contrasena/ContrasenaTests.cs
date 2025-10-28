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

    private bool esValida(string contrasena)
    {
        if (contrasena.Length < 9) return false;

        return true;
    }
}