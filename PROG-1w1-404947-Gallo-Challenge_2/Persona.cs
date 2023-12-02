using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_1w1_404947_Gallo_Challenge_2
{
    public abstract class Persona
    {
        //atributos
        private string nombreCompleto;
        private int clase;
        private string grupoSanguineo;

        //propiedades
        public string GrupoSanguineo
        {
            get { return grupoSanguineo; }
            set { grupoSanguineo = value; }
        }

        public int Clase
        {
            get { return clase; }
            set { clase = value; }
        }

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        //constructor
        public Persona()
        {
            clase = 2000;
            nombreCompleto = "S/N";
            grupoSanguineo = "0+";
        }

        public Persona(string nombreCompleto, int clase, string grupoSanguineo)
        {
            this.nombreCompleto = nombreCompleto;
            this.clase = clase;
            this.grupoSanguineo = grupoSanguineo;
        }


        //metodos
        public abstract int Valoracion();

        public abstract string Posicion();

        public override string ToString()
        {
            return " | Nombre Completo: " + nombreCompleto 
                 + " | Clase[" + clase + "]" 
                 + " | Grupo sanguíneo: " + grupoSanguineo
                 + "\n";
        }

    }
}
