namespace TDDKatas.Contrasena;

public class Validador
{
    private string _contrasena;

    public Validador(string contrasena)
    {
        _contrasena = contrasena;
    }
    public bool esValida()
    {
        if (_contrasena.Length < 9) return false;
        if (_contrasena.Count(char.IsUpper) ==0) return false;
        return _contrasena.Count(char.IsLower) != 0;
    }
}