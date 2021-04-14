using System;
using System.Collections.Generic;
using System.Text;

namespace t1calidad
{
    public class BolosService
    {
        int contadorCaidas;
        int[] PinoCae = new int[21]; //Máximo tiros 
        
        

        public void Caida(int pinos)
        {
            PinoCae[contadorCaidas] = pinos;
            contadorCaidas++;
        }

       

        bool EsStrike(int IndiceFrame)
        {
            return PinoCae[IndiceFrame ] == 10;

        }

        bool EsSpare(int frameIndex)
        {
            return PinoCae[frameIndex] + PinoCae[frameIndex + 1] == 10;
        }
         
        int StrikeBonus(int frameIndex)
        {
            return PinoCae[frameIndex + 1] + PinoCae[frameIndex + 2];
            //return  PinoCae[frameIndex + 2];
        }

        int SpareBonus(int i)
        {
            return PinoCae[i + 2];
        }

        public int Puntaje()
        {
            int puntaje = 0;
            int i = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if(EsStrike(i))
                {
                    puntaje += 10 + StrikeBonus(i);
                    i += 1;
                }

            else if(EsSpare(i))
                {
                    puntaje += 10 + SpareBonus(i);
                    i += 2;
                }else
                {
                    puntaje += PinoCae[i] + PinoCae[i+1];
                    i += 2;
                }
                    
            }
            return puntaje;
        }
    }
}
