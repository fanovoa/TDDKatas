namespace TDDKatas.MarsRover;

public enum Orientacion
{
    N=0,
    E=1,
    S=2,
    W=3
}
public class MarsRover
{
    public int Posicion_X { get; private set; }
    public int Posicion_Y { get; private set; }
    public Orientacion Orientacion { get; private set; }

    private readonly int _width;
    private readonly int _height;

    public MarsRover()
    {
        Posicion_X = 0;
        Posicion_Y = 0;
        _width = 10;
        _height = 10;
        Orientacion = Orientacion.N;

    }
    public string CalcularPosicion(string comandos)
    {
        if (comandos.Any(comando => !"RML".Contains(comando))) return "COMANDO INVALIDO";
        foreach (var comando in comandos.ToCharArray())
        {
            switch (comando)
            {
                case 'M': Mover(); break;
                case 'R': GirarAlaDerecha(); break;
                case 'L': GirarAlaIzquierda(); break;
            }

            ReiniciaPosicion(Posicion_X > _width, Posicion_Y > _height);
        }
        
        return string.Concat(Posicion_X,":", Posicion_Y,":",Orientacion);
        
    }

    private void ReiniciaPosicion(bool reiniciaX, bool reiniciaY)
    {
        if (reiniciaX) Posicion_X = 0;
        if (reiniciaY) Posicion_Y = 0 ;
    }

    private void Mover()
    {
        switch (Orientacion)
        {
            case Orientacion.E: Posicion_X++; break;
            case Orientacion.W: Posicion_X--; break;
            case Orientacion.S: Posicion_Y--; break;
            case Orientacion.N: Posicion_Y++; break;
            default: throw new ArgumentOutOfRangeException();
        }
    }

    private void GirarAlaIzquierda() => Orientacion = (((int)Orientacion)+1) < 3 ?  Orientacion.W:(Orientacion)(((int)Orientacion)-1);
    private void GirarAlaDerecha()=> Orientacion = (((int)Orientacion)+1) > 3 ?  Orientacion.N:(Orientacion)(((int)Orientacion)+1);
    
}