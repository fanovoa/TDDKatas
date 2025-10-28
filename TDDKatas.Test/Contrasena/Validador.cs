namespace TDDKatas.Contrasena;

public class Validador
{
    private readonly string _contrasena;
    private readonly int _longitudMinima;
    private readonly int _longitudMayusculas;
    private readonly int _longitusMinusculas;
    private readonly int _longitudNumeros;
    private readonly int _longitudGuiones;

    public Validador(string contrasena)
    {
        _contrasena = contrasena;
        _longitudMinima = 9;
        _longitudMayusculas = 1;
        _longitusMinusculas = 1;
        _longitudNumeros = 1;
        _longitudGuiones = 1;
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
        return _contrasena.Count(caracter => caracter == '_') >=_longitudGuiones;
    }

    private bool ContieneMinusculas()
    {
        return _contrasena.Count(char.IsLower) >= _longitusMinusculas;
    }

    private bool ContieneNumeros()
    {
        return _contrasena.Count(char.IsDigit) >= _longitudNumeros;
    }

    private bool ContieneMayusculas()
    {
        return _contrasena.Count(char.IsUpper) >=_longitudMayusculas;
    }

    private bool ContieneCaracteresMinimos()
    {
   
        return _contrasena.Length >= _longitudMinima;
    }
}