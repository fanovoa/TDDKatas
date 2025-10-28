namespace TDDKatas.Contrasena;

public class Validador
{
    private string _contrasena;

    public Validador(string contrasena)
    {
        _contrasena = contrasena;
    }
    public bool EsValida()
    {
        return    ContieneCaracteresMinimos()
               && ContieneMayusculas()
               && ContieneNumeros()
               && ContieneMinusculas()
               && ContieneGuion();
    }

    private bool ContieneGuion()
    {
        return _contrasena.Contains('_');
    }

    private bool ContieneMinusculas()
    {
        return _contrasena.Count(char.IsLower) == 0;
    }

    private bool ContieneNumeros()
    {
        return _contrasena.Count(char.IsDigit) == 0;
    }

    private bool ContieneMayusculas()
    {
        return _contrasena.Count(char.IsUpper) >0;
    }

    private bool ContieneCaracteresMinimos()
    {
        return _contrasena.Length > 9;
    }
}