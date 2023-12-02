using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallo_404947_PROG_Act._2._11_Baraja_Cartas
{
    internal class Carta
    {
        //Atributos

        private int numero;
        private string palo;

        //Atributos constantes
        public static String[] Palos={"Espada", "Oro", "Copa", "Basto"};
        public static int limiteCartaPalo = 12;


        //Propiedades

        public int pNumero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string pPalo
        {
            get { return palo; }
            set { palo = value; }
        }

        //Constructores

        public Carta()
        {
            this.numero = 0;
            this.palo = string.Empty;
        }

        public Carta(int n, string p)
        {
            this.numero = n;
            this.palo = p;
        }

        //ToString

        public override string ToString()
        {
            return "Carta: " + numero + " de " + palo + "\n";
        }

        
    }
}
