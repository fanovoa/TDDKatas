namespace TDDKatas.MarsRover;

public class MarsRover
{
    public string CalcularPosicion(string comandos)
    {
        int posicion_X = 0;
        int posicion_Y = 0;
        int orientacion_inicial = 0;
        char[] orientacion = ['N','E','S','W'];
        
        foreach (var comando in comandos.ToCharArray())
        {
            if (comando == 'M')
            {
                switch (orientacion[orientacion_inicial])
                {
                    case 'E':
                        posicion_X++;
                        break;
                    case 'W':
                        posicion_X--;
                        break;
                    case 'S':
                        posicion_Y--;
                        break;
                    default:
                        posicion_Y++;
                        break;
                }
            }
            if (comando == 'R') orientacion_inicial++;
            if (comando == 'L') orientacion_inicial--;
            
            if(orientacion_inicial >3 ) orientacion_inicial = 0;
            if (orientacion_inicial <0 ) orientacion_inicial = 3;
            
        }
        
        return string.Concat(posicion_X,":", posicion_Y,":",orientacion[orientacion_inicial]);
        
    }
}