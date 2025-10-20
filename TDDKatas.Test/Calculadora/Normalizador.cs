using System.Text.RegularExpressions;

namespace TDDKatas.Calculadora;

public static class Normalizador
{
    private static readonly Regex _operadoresDuplicados = new(@"([+\-*/])\1+", RegexOptions.Compiled);

    public static string NormalizarTexto(string? texto)
    {
        if (string.IsNullOrEmpty(texto)) return "";
        texto = texto.ToLower();
        texto = texto.Replace(" ", "");
        texto = _operadoresDuplicados.Replace(texto, "$1");
        return texto;
    }
}