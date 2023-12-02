using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_1w1_404947_Gallo_Challenge_2
{
    internal class Equipo
    {
        //atributos
        private string categoria;
        private Persona[] personas;
        private int siguiente;


        //propiedades
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        //constructor
        public Equipo(int total)
        {
            categoria = "S/D";
            personas = new Persona[total];
            siguiente = 0;
        }

        public Equipo(string categoria, int total)
        {
            this.categoria = categoria;
            personas = new Persona[total];
            siguiente = 0;
        }

        //metodos
        public void AgregarPersona(Persona persona)
        {
            if (siguiente < personas.Length)
            {
                personas[siguiente] = persona;
                siguiente++;
            }
        }

        //Completar:


        /// <summary>
        /// Permite retornar una cadena con el listado completo de todos los integrantes de un equipo, 
        /// tanto jugadores como entrenadores.
        /// </summary>

        public string ListarIntegrantes()
        {
            string integrantes = "";

            for (int i = 0; i<personas.Length; i++)
            {
                integrantes = integrantes + personas[i].ToString();
            }

            return integrantes;
        }


        /// <summary>
        /// Permite retornar un valor entero correspondiente a la cantidad de jugadores cuya posición y valoración  
        /// se reciben como parámetros
        /// </summary>
        /// <param name="posicion">Posición del jugador</param>
        /// <param name="valor">Indicador de valoración del jugador</param>
        /// <returns>Cantidad de jugadores de la posición recibida con una valoración igual o superior al segundo parámetro</returns>

        public int JugadoresConPosicionValorados(string posicion, int valor)
        {
            int aux = 0;

            for (int i = 0; i < personas.Length; i++)
            {
                if (personas[i].Posicion() == posicion && personas[i].Valoracion() == valor)
                {
                    aux++;
                }
            }

                return aux;
        }

    }
}
