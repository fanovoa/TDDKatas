using FluentAssertions;

namespace TDDKatas.Contrasena;

public class ContrasenaTests
{
    [Fact]
    public void Si_LaContrasenaContieneMenosDe8Caracteres_DEBE_RetornarFalse()
    {
        var contrasena = "123";

        var validar = esValida();

        validar.Should().Be(false);
    }

    private object esValida()
    {
        return false;
    }
}