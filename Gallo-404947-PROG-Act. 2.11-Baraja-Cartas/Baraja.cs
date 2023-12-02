using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gallo_404947_PROG_Act._2._11_Baraja_Cartas
{
    internal class Baraja
    {
        //atributos
        private Carta[] cartas;
        private int posSigCarta;
        private int numCartas = 40;

        //Propiedades
        public int pNumCartas
        {
            get { return numCartas; }
            set { numCartas = value; }
        }


        //constructor
        public Baraja()
        {
            this.cartas = new Carta[numCartas];
            this.posSigCarta = 0;
            CrearBaraja(); //Creamos la baraja
            Barajar(); // barajamos la baraja

        }

        private void CrearBaraja()
        {

            String[] palos = Carta.Palos;

            //Recorro los palos
            for (int i = 0; i < palos.Length; i++)
            {

                //Recorro los numeros
                for (int j = 0; j <= Carta.limiteCartaPalo ; j++)
                {
                    //Las posiciones del 8 y del 9 son el 7 y el 8 (empezamos en 8)
                    if (j != 7 || j != 8)
                    
                    {

                        cartas[i] = new Carta(j + 1 , palos[i]);

                    }
                }

            }

        }

        public void Barajar()
        {

            int posAleatoria = 0;
            Carta c;
            Random rnd = new Random();

            //Recorro las cartas
            for (int i = 0; i < cartas.Length; i++)
            {

                posAleatoria = rnd.Next(0, numCartas - 1);

                //intercambio
                c = cartas[i];
                cartas[i] = cartas[posAleatoria];
                cartas[posAleatoria] = c;

            }

            //La posición vuelve al inicio
            this.posSigCarta = 0;

        }

        public Carta SiguienteCarta()
        {
            Carta c = null;


            if (posSigCarta == numCartas)
            {
                Console.WriteLine("No hay mas cartas");
            }
            else
            {
                c = cartas[posSigCarta++];
            }

            return c;
        }

        public Carta[] DarCartas(int numDeCartas)
        {


            if (numDeCartas > numCartas)
            {
                Console.Write("No se puede dar mas cartas de las que hay");
            }
            else if (CartasDisponible() < numDeCartas)
            {
                Console.Write("No hay suficientes cartas que mostrar");
            }
            else
            {

                Carta[] cartasDar = new Carta[numDeCartas];

                //recorro el array que acabo de crear para rellenarlo
                for (int i = 0; i < cartasDar.Length; i++)
                {
                    cartasDar[i] = SiguienteCarta(); //uso el metodo anterior
                }

                //Lo devuelvo
                return cartasDar;

            }

            //solo en caso de error
            return null;

        }

        public int CartasDisponible()
        {
            return numCartas - posSigCarta;
        }

        /**
         * Muestro las cartas que ya han salido
         */
        public void CartasMonton()
        {

            if (CartasDisponible() == numCartas)
            {
                Console.WriteLine("No se ha sacado ninguna carta");
            }
            else
            {
                //Recorro desde 0 a la posSiguienteCarta
                for (int i = 0; i < posSigCarta; i++)
                {
                    Console.WriteLine(cartas[i]);
                }
            }

        }

        public void mostrarBaraja()
        {

            if (CartasDisponible() == 0)
            {
                Console.WriteLine("No hay cartas que mostrar");
            }
            else
            {
                for (int i = posSigCarta; i < cartas.Length; i++)
                {
                    Console.WriteLine(cartas[i]);
                }
            }


        }

        public override string ToString()
        {
            string aux = "Cartas de la baraja \n";
            for (int i = 0; i < 2; i++)
            {
                aux += cartas[i].ToString() + "\n";
            }
            return aux;
        }
    }
}
