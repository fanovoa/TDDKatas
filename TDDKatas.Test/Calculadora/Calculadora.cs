using System.Text.RegularExpressions;

namespace TDDKatas.Calculadora;

public class Calculadora
{
    
    const string MensajeEror = "Ingrese un número válido.";

    public string ValidarCadena(string? expresion)
    {

        expresion = Normalizador.NormalizarTexto(expresion);
        if (string.IsNullOrEmpty(expresion)) return MensajeEror;
        
        if(!ValidadorOperacion.EsUnaOperacionValida(expresion)) return MensajeEror;
        if (EsUnaSuma(expresion) )  return HacerSuma(expresion);
        if (EsUnaResta(expresion) ) return HacerResta(expresion);
        if (EsUnaMultiplicacion(expresion)) return HacerMultiplicacion(expresion);
        return EsUnaDivision(expresion) ? HacerDivision(expresion) : expresion;
    }
    
    private string HacerDivision(string expresion)
    {
        var tieneSignosNegativosPares=TieneSignosNegativosPares(expresion);
        if (ContieneSignosNegativos(expresion))
        {
            expresion = expresion.Replace("-", "");
        }
        var numerosAOperar = ParticionarCadena(expresion,"/");
        if (numerosAOperar[1] == 0) return "0";
        var resultado= numerosAOperar[0]/numerosAOperar[1];
        return   tieneSignosNegativosPares?  resultado.ToString() : string.Concat("-",resultado.ToString());
    }
    private string HacerMultiplicacion(string expresion)
    {
        var tieneSignosNegativosPares = TieneSignosNegativosPares(expresion);

        if (ContieneSignosNegativos(expresion))
        {
            expresion = expresion.Replace("-", "");
        }
        var numerosOperar = ParticionarCadena(expresion,"*");
        var resultado= numerosOperar[0]*numerosOperar[1];
        return tieneSignosNegativosPares ?  resultado.ToString() : string.Concat("-",resultado.ToString());

    }
    
    private string HacerResta(string expresion)
    {
        if (TieneSignosNegativosPares(expresion))
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
    private bool EsUnaDivision(string expresion) => expresion.Contains("/");
    private bool EsUnaMultiplicacion(string expresion) => expresion.Contains("*");
    private bool EsUnaSuma(string expresion) =>  expresion.Contains("+");
    private bool EsUnaResta(string expresion) => expresion.Contains("-") && !expresion.Contains("/") && !expresion.Contains("*");
    
    private static bool TieneSignosNegativosPares(string expresion) => expresion.Count(c => c == '-')%2 ==0;
    private static bool ContieneSignosNegativos(string expresion) => expresion.Count(c => c == '-') > 0;

}