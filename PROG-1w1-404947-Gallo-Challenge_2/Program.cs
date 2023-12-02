using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_1w1_404947_Gallo_Challenge_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //creacion Equipo
            Equipo Sacachispas;

            Sacachispas = new Equipo("6ta", 2);

            //creacion Jugador
            Jugador Jugador1 = new Jugador("Jorge Romagnoli", 63, "A+", "Mediocentro", false, 3);

            //creacion Entrenador
            Entrenador Entrenador1 = new Entrenador("Eduardo Pérez" , 256, "B-", "Preparador Físico", 7);

            //se agregan las personas al equipo

            Sacachispas.AgregarPersona(Jugador1);
            Sacachispas.AgregarPersona(Entrenador1);

            //ejecucuion de metodos del Equipo

            Console.WriteLine(Sacachispas.ListarIntegrantes());
            Console.WriteLine("Cantidad de Jugadores con Posicion \"Mediocentro\" y Valorados con \"5\": ");
            Console.WriteLine(Sacachispas.JugadoresConPosicionValorados("Mediocentro", 5));
            Console.ReadLine();
        }
    }
}
