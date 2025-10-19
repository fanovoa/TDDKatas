namespace TDDKatas.Palindromos;

public class Palindromo(string texto)
{
    private string Texto { get; set; } = texto;

    public bool ValidarSiEsLaPalabraEsPalindromo()
    {
        if (string.IsNullOrEmpty(Texto)) return false;
        ConvertirAMinusculas();
        if (ContieneSimbolos()) ReemplazaSimbolos();
        if (ContieneAcentos()) ReemplazaAcentos();
        if(EsVacioNulo()) return false;
        
        var palabraAlReves = Texto.ToCharArray().Reverse();
        return Texto == new string(palabraAlReves.ToArray());
    }

    private bool EsVacioNulo() => string.IsNullOrEmpty(Texto);

    private void ConvertirAMinusculas()
    {
        Texto = Texto.ToLower();
    }

    private void ReemplazaAcentos()
    {
        Texto = Texto.Replace("á", "a").Replace("é","e").Replace("í","i").Replace("ó","o").Replace("ú","u");
    }

    private bool ContieneAcentos() =>  Texto.IndexOfAny("áéíóú".ToCharArray())>=0;

    private void ReemplazaSimbolos()
    {
        var quitarSimbolos = Texto
            .Where(char.IsLetterOrDigit)
            .ToArray();
        Texto = new string(quitarSimbolos);
    }
    private bool ContieneSimbolos() => Texto.Any(caracter => !char.IsLetterOrDigit(caracter));
}