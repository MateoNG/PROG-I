using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallo_404947_PROG_Act._2._11_Baraja_Cartas
{
    internal class program
    {
        static void Main(string[] args)
        {

            //Mensaje del estudiante
            Console.WriteLine("Este ejercicio no me salia ni de casualidad, asi que intente ayudarme con ChatGPT (No me ayudo)" + "\n" +
                              "entonces, busque la solucion en google, pero, en JavaScript, de esta manera tendria que 'traducir' los " + "\n" + 
                              "métodos y demás a c#, para que hacer esto tenga algo de gracia y no sea un ctrl v ctrl c. " + "\n" +
                              "Conclusión: estoy intendo justificar las  3 horas que estuve cambiando y probando esto que copie y pegue" + "\n");


            //Creamos la baraja
            Baraja b = new Baraja();

            //Mostramos las cartas disponibles (40)
            Console.WriteLine("Hay " + b.CartasDisponible() + " cartas disponibles");

            //Saco una carta
            b.SiguienteCarta();

            //Saco 5 cartas
            b.DarCartas(5);

            //Mostramos las cartas disponibles (34)
            Console.WriteLine("Hay " + b.CartasDisponible() + " cartas disponibles");

            Console.WriteLine("Cartas sacadas de momento");

            b.CartasMonton();


            //Barajamos de nuevo
            b.Barajar();

            //Saco 5 cartas
            Carta[] c = b.DarCartas(5);

            Console.WriteLine("Cartas sacadas despues de barajar ");
            for (int i = 0; i < c.Length; i++)
            {
                Console.WriteLine(c[i]);
            }

          

            Console.ReadLine();
        }
    }
}

     
   
   



    

    

