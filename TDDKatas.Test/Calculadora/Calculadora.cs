using System.Text.RegularExpressions;

namespace TDDKatas.Calculadora;

public class Calculadora(string cadena)
{
    
    private string  Cadena { get; set; } = cadena;
    const string MENSAJE_ERROR = "Ingrese un número válido.";

    public string ValidarCadena()
    {
        
        if (Cadena == null) return MENSAJE_ERROR;
        
        ConvertirAMinusculas();
        if (EsVacioNulo() || ContieneLetras()) return MENSAJE_ERROR;
        if(ContieneCaracteresNoPermitidos()) return MENSAJE_ERROR;
        if( SoloContieneOperadores()) return MENSAJE_ERROR;

        return Cadena;
    }

    private bool SoloContieneOperadores()
    {
        QuitaOperadoresDuplicados();
        
        return Cadena== "+" || Cadena == "-" || Cadena == "*" || Cadena == "/" || Cadena=="*+-/"
            || Cadena=="+*-/" || Cadena=="-*+/";
    }
    
    private bool ContieneCaracteresNoPermitidos()
    {
        string[] operadores = {"+","-","*","/"};
        return Cadena.Any(caracter => !char.IsDigit(caracter) && !operadores.Contains(caracter.ToString()));
    }

    private void QuitaOperadoresDuplicados() => Cadena= Regex.Replace(Cadena, @"([+\-*/])\1+", "$1");
    private  string ConvertirAMinusculas() => Cadena= Cadena.ToLower();
    private bool ContieneLetras() => Cadena.Any(char.IsLetter);
    private bool EsVacioNulo() => string.IsNullOrEmpty(Cadena);
}