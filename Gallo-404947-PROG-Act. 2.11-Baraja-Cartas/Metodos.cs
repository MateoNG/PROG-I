using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallo_404947_PROG_Act._2._11_Baraja_Cartas
{
    internal class Metodos
    {
        public static int GeneraNumeroEnteroAleatorio(int minimo, int maximo)
        {
            Random rnd = new Random();
            int num = (int)(rnd.Next() * (minimo - (maximo + 1)) + (maximo + 1));
            return num;
        }

    }
}
