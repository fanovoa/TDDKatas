namespace TDDKatas;

public readonly record struct Dinero(int Valor, TipoDinero Tipo);

public enum TipoDinero {Billete, Moneda}

public class Cajero
{
    private static List<Dinero> _Denominaciones = [
        new(500,TipoDinero.Billete),
        new(200,TipoDinero.Billete),
        new(100,TipoDinero.Billete),
        new(50,TipoDinero.Billete),
        new(20,TipoDinero.Billete),
        new(10,TipoDinero.Billete),
        new(5,TipoDinero.Billete), 
        new(2,TipoDinero.Moneda), 
        new(1,TipoDinero.Moneda)
    ];

    public IReadOnlyList<(int Cantidad,int Denominacion)> Retirar(int cantidad)
    {
        return CalcularDenominaciones(cantidad).AsReadOnly();
    }

    private static List<(int, int)> CalcularDenominaciones(int cantidad)
    {
        var dinero = new List<(int, int)>();
        
        foreach (var (valor,_) in _Denominaciones)
        {
            var cantidadDeDinero = cantidad / valor;
            if (cantidadDeDinero <= 0) continue;
            dinero.Add((cantidadDeDinero,valor));
            cantidad -= ( cantidadDeDinero * valor);

        }
        
        return dinero;
    }
}