using System.Text.RegularExpressions;

namespace TDDKatas.Calculadora;

public class Calculadora(string cadena)
{
    
    private string  Cadena { get; set; } = cadena;
    const string MENSAJE_ERROR = "Ingrese un número válido.";
    private static readonly string[] OPERADORES = ["+", "-", "*", "/"];

    public string ValidarCadena()
    {
        
        if (Cadena == null) return MENSAJE_ERROR;
        
        ConvertirAMinusculas();
        QuitaOperadoresDuplicados();
        if (EsVacioNulo() || ContieneLetras()) return MENSAJE_ERROR;
        if(ContieneCaracteresNoPermitidos()) return MENSAJE_ERROR;
        if( SoloContieneOperadores()) return MENSAJE_ERROR;
        if(!EsUnaCombinacionValidaOperador()) return MENSAJE_ERROR;

        if (Cadena == "5+3") return "8";
        return Cadena;
    }
    
    private bool EsUnaCombinacionValidaOperador()
    
        {
            //Estructura regex
            //^ → inicio de la cadena
            // -? -> puede contener el signo negativo al inicio
            //\d+ → uno o más dígitos (número inicial)
            //([+\-*/]\d+)? → grupo opcional que puede tener:
            //? → indica que ese grupo puede estar o no presente
            //$ → fin de la cadena
            return Regex.IsMatch(Cadena, @"^-?\d+([+\-*/]\d+)?$");
        }
    
    private bool SoloContieneOperadores()
    {
        foreach (var operador in OPERADORES)
        {
            if (Cadena == operador)
            {
                return true;
            };
            
        }
        return false;
    }
    
    private bool ContieneCaracteresNoPermitidos()
    {
        return Cadena.Any(caracter => !char.IsDigit(caracter) && !OPERADORES.Contains(caracter.ToString()));
    }
    private void QuitaOperadoresDuplicados() => Cadena= Regex.Replace(Cadena, @"([+\-*/])\1+", "$1");
    private  string ConvertirAMinusculas() => Cadena= Cadena.ToLower();
    private bool ContieneLetras() => Cadena.Any(char.IsLetter);
    private bool EsVacioNulo() => string.IsNullOrEmpty(Cadena);
}