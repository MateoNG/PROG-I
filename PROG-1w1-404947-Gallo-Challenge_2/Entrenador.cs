using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_1w1_404947_Gallo_Challenge_2
{
    internal class Entrenador :Persona
    {
        //atributos
        private string cargo;
        private int añosAntiguedad;

        //propiedades

        public string pCargo
        {
            get {return cargo; }
            set {cargo=value; }
        }

        public int pAñosAntiguedad
        {
            get {return añosAntiguedad; }
            set {añosAntiguedad = value; }
        }

        //constructores

        public Entrenador() :base()
        {
            cargo = "S/D";
            añosAntiguedad = 0;
        }

        public Entrenador(string nombreCompleto, int clase, string grupoSanguineo, string cargo, int añosAntiguedad)
                    :base(nombreCompleto, clase, grupoSanguineo)
        {
            this.cargo = cargo;
            this.añosAntiguedad = añosAntiguedad;
        }

        //metodos
        public override string ToString()
        {
            return base.ToString() 
                + " | Cargo: " + cargo 
                + " | Años de antiguedad: "  + añosAntiguedad 
                + "\n";
        }

        public override int Valoracion()
        {
            int valoracion = 0;

            if(añosAntiguedad>=1 && añosAntiguedad<=5)
            {
                valoracion = 5;
            } else if(añosAntiguedad>5)
            {
                valoracion = añosAntiguedad;
            } 
           
            return valoracion;
        }

        public override string Posicion()
        {
            return "No tiene";
        }
    }
}
