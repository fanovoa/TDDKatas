using System.Text.RegularExpressions;

namespace TDDKatas.Calculadora;

public class Calculadora
{
    
    const string MENSAJE_ERROR = "Ingrese un número válido.";
    private static readonly string[] OPERADORES = ["+", "-", "*", "/"];

    public string ValidarCadena(string expresion)
    {
        if (expresion == null) return MENSAJE_ERROR;
        
        expresion = ConvertirAMinusculas(expresion);
        expresion= QuitaOperadoresDuplicados(expresion);
        expresion = expresion.Replace(" ","");
        
        if (EsVacioNulo(expresion) || ContieneLetras(expresion)) return MENSAJE_ERROR;
        if(ContieneCaracteresNoPermitidos(expresion)) return MENSAJE_ERROR;
        if( SoloContieneOperadores(expresion)) return MENSAJE_ERROR;
        if(!EsUnaCombinacionValidaOperador(expresion)) return MENSAJE_ERROR;

        if (EsUnaSuma(expresion) )  return HacerSuma(expresion);
        if (EsUnaResta(expresion) && !expresion.Contains("/")) return HacerResta(expresion);
        if (EsUnaMultiplicacion(expresion)) return HacerMultiplicacion(expresion);
        if (EsUnaDivision(expresion)) return HacerDivision(expresion);
      
        return expresion;
    }

    private bool EsUnaDivision(string expresion)
    {
        return expresion.Contains("/");
    }

    private string HacerDivision(string expresion)
    {
        var cantidadNegativos = expresion.Count(c => c == '-');
        if (cantidadNegativos > 0)
        {
            expresion = expresion.Replace("-", "");
        }
        var numerosAOperar = ParticionarCadena(expresion,"/");
        if (numerosAOperar[1] == 0) return "0";
        var resultado= numerosAOperar[0]/numerosAOperar[1];
        return cantidadNegativos%2 ==0 ?  resultado.ToString() : string.Concat("-",resultado.ToString());
    }

    private string HacerMultiplicacion(string expresion)
    {
        var numerosOperar = ParticionarCadena(expresion,"*");
        var resultado= numerosOperar[0]*numerosOperar[1];
        return resultado.ToString();
    }
    private string HacerResta(string expresion)
    {
        var cantidadNegativos = expresion.Count(c => c == '-');
        if (cantidadNegativos % 2 == 0)
        {
            expresion = (string.Concat("", expresion.AsSpan(1))).Replace("-","+");
            return HacerSuma(expresion);
        }
        var numerosOperar = ParticionarCadena(expresion,"-");
        var resultado= numerosOperar[0]-numerosOperar[1];
        return resultado.ToString();
    }
    private string HacerSuma(string expresion)
    {
        var numerosOperar = ParticionarCadena(expresion,"+");
        var resultado= numerosOperar[0]+numerosOperar[1];
        return resultado.ToString();
    }
    private double[] ParticionarCadena(string expresion, string operador)
    {
        var cadenaParticionada = expresion.Split(operador);
        var sumando1 = double.Parse(cadenaParticionada[0] == "" ? "0": cadenaParticionada[0]);
        var sumando2 = double.Parse(cadenaParticionada[1]== "" ? "0": cadenaParticionada[1]);
        return [sumando1,sumando2];
    }
    
    private bool EsUnaMultiplicacion(string expresion) => expresion.Contains("*");
    private bool EsUnaSuma(string expresion) =>  expresion.Contains("+");
    private bool EsUnaResta(string expresion) => expresion.Contains("-");
    
    private bool EsUnaCombinacionValidaOperador(string expresion)
    
        {
            //Estructura regex
            //^ → inicio de la cadena
            // -? -> puede contener el signo negativo al inicio
            //\d+ → uno o más dígitos (número inicial)
            //([+\-*/]\d+)? → grupo opcional que puede tener:
            //? → indica que ese grupo puede estar o no presente
            //$ → fin de la cadena
            return Regex.IsMatch(expresion, @"^-?\d+([+\-*/]\d+)?$");
        }
    
    private bool SoloContieneOperadores(string expresion)
    {
        foreach (var operador in OPERADORES)
        {
            if (expresion == operador)
            {
                return true;
            };
            
        }
        return false;
    }
    
    private bool ContieneCaracteresNoPermitidos(string expresion)
    {
        return expresion.Any(caracter => !char.IsDigit(caracter) && !OPERADORES.Contains(caracter.ToString()));
    }
    private string QuitaOperadoresDuplicados(string expresion) =>  Regex.Replace(expresion, @"([+\-*/])\1+", "$1");
    private  string ConvertirAMinusculas(string expresion) => expresion.ToLower();
    private bool ContieneLetras(string expresion) => expresion.Any(char.IsLetter);
    private bool EsVacioNulo(string expresion) => string.IsNullOrEmpty(expresion);
}