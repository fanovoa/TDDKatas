namespace TDDKatas.Palindromos;

public class Palindromo
{
    private readonly string _texto;

    public Palindromo(string texto)
    {
        _texto = texto;   
    }
    
    public bool ValidarSiEsLaPalabraEsPalindromo()
    {
        if (EsNuloElTexto()) return false;
        var textoNormalizado = NormalizarTexto(_texto);
        return !ElTextoEstaVacio(textoNormalizado) && textoNormalizado.SequenceEqual(textoNormalizado.ToCharArray().Reverse());
    }

    private static bool ElTextoEstaVacio(string texto) => string.IsNullOrEmpty(texto);
    
    private string NormalizarTexto ( string texto)
    {
        var textoEnMinusculas = texto.ToLowerInvariant();
        var textoSinSimbolos = ContieneSimbolos(textoEnMinusculas)
            ? ReemplazaSimbolos(textoEnMinusculas)
            : textoEnMinusculas;

        var textoSinAcentos =
            ContieneAcentos(textoEnMinusculas) ? ReemplazaAcentos(textoSinSimbolos) : textoSinSimbolos;
        
        return textoSinAcentos;
    }
    private bool EsNuloElTexto() => string.IsNullOrWhiteSpace(_texto);



    private string ReemplazaAcentos(string texto)
    {
        return texto
            .Replace("á", "a")
            .Replace("é","e")
            .Replace("í","i")
            .Replace("ó","o")
            .Replace("ú","u")
            .Replace("Á","A")
            .Replace("É","E")
            .Replace("Í","I")
            .Replace("Ó","O")
            .Replace("Ú","U");
    }

    private bool ContieneAcentos(string texto) =>  texto.IndexOfAny("áéíóúÁÉÍÓÚ".ToCharArray())>=0;

    private string ReemplazaSimbolos(string texto)
    {
        var quitarSimbolos = texto
            .Where(char.IsLetterOrDigit)
            .ToArray();
        return new string(quitarSimbolos);
    }
    private bool ContieneSimbolos(string texto) => texto.Any(caracter => !char.IsLetterOrDigit(caracter));
}