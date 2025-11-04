namespace TDDKatas;


public class Cajero
{
    private static List<(int Valor, string Tipo)> _Denominaciones = [
        (500,"billete"),
        (200,"billete"),
        (100,"billete"),
        (50,"billete"),
        (20,"billete"),
        (10,"billete"),
        (5,"billete"), 
        (2,"moneda"), 
        (1,"moneda")
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