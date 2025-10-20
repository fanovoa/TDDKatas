using System.Text.RegularExpressions;

namespace TDDKatas.Calculadora;

public static class ValidadorOperacion
{
    private static readonly Regex _binaria = new(
        @"^-?\d+([+\-*/]\-?\d+)?$",
        RegexOptions.Compiled);

    public static bool EsUnaOperacionValida(string operacion) => _binaria.IsMatch(operacion);
}