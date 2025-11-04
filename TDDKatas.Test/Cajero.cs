namespace TDDKatas;

public class Cajero
{
    private static List<(int,string)> _Denominaciones = [
        (50,"billete"),
        (20,"billete"),
        (10,"billete"),
        (5,"billete"), 
        (2,"moneda"), 
        (1,"moneda")
    ];

    public List<(int,int)> Retirar(int cantidad)
    {
        var dinero = new List<(int, int)>();


        foreach (var denominacion in _Denominaciones)
        {
            var cantidadDeDinero = cantidad / denominacion.Item1;
            if (cantidadDeDinero >0 )
            {
                dinero.Add((cantidadDeDinero,denominacion.Item1));
                cantidad -= ( cantidadDeDinero * denominacion.Item1);
            }
            
        }
        
        return dinero;
    }
}