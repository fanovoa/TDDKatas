namespace TDDKatas.Palindromos;

public class Palindromo(string palabra)
{
    private string Palabra { get; set; } = palabra;

    public bool ValidarSiEsLaPalabraEsPalindromo()
    {
        Palabra = Palabra.ToLower();
        if (ContieneSimbolos()) ReemplazaSimbolos();
        if (ContieneAcentos())
        {
            ReemplazaAcentos();
        }
        
        var palabraAlReves = Palabra.ToCharArray().Reverse();
        return Palabra == new string(palabraAlReves.ToArray());
    }

    private void ReemplazaAcentos()
    {
        Palabra = Palabra.Replace("á", "a").Replace("é","e").Replace("í","i").Replace("ó","o").Replace("ú","u");
    }

    private bool ContieneAcentos() =>  Palabra.IndexOfAny("áéíóú".ToCharArray())>=0;

    private void ReemplazaSimbolos()
    {
        var quitarSimbolos = Palabra
            .Where(char.IsLetterOrDigit)
            .ToArray();
        Palabra = new string(quitarSimbolos);
    }
    private bool ContieneSimbolos() => Palabra.Any(caracter => char.IsLetterOrDigit(caracter));
}