using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_Act_2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Auto N1
            Auto a1;
            a1 = new Auto();

            a1.pCapacidadMax = 54;
            a1.pKmXlitro = 11;
            a1.pCombustible = 10;

            Console.WriteLine("\nAuto 1");
            Console.Write(a1.CargarCombustible(44));
            Console.Write(a1.Conducir(110));
            Console.Write(a1.toString());

            // Auto N2
            Auto a2;
            a2 = new Auto();

            a2.pCapacidadMax = 120;
            a2.pKmXlitro = 6;
            a2.pCombustible = 12;

            Console.WriteLine("\n");
            Console.WriteLine("\nAuto 2");
            Console.Write(a2.CargarCombustible(110));
            Console.Write(a2.Conducir(918));
            Console.Write(a2.toString());
            Console.ReadLine();


        }
    }
}