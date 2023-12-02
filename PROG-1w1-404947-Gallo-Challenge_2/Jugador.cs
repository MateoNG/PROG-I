using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_1w1_404947_Gallo_Challenge_2
{
    internal class Jugador :Persona
    {
        //atributos
        private string posicion;
        private bool estaLesionado;
        private int faltas;

        //propiedades
        public int pFaltas
        {
            get { return faltas; }
            set { faltas = value; }
        }

        public bool pEstaLesionado
        {
            get { return estaLesionado; }
            set { estaLesionado = value; }
        }

        public string pPosicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        //constructor
        public Jugador() : base()
        {
            estaLesionado = false;
            faltas = 0;
            posicion = "Sin definir";
        }

        public Jugador(string nombreCompleto, int clase, string grupoSanguineo, string posicion, bool estaLesionado, int faltas) 
                 :base(nombreCompleto, clase, grupoSanguineo)
        {
            this.posicion = posicion;
            this.estaLesionado = estaLesionado;
            this.faltas = faltas;
        }

        //metodos

        public override string Posicion()
        {
            return posicion;
        }

        public override string ToString()
        {
            return base.ToString() 
                + " | Juega de: " + posicion 
                + " | Faltas (" + faltas + ")" 
                + " | Está lesionado?: " + estaLesionado
                + "\n";
        }

        public override int Valoracion()
        {
            int valoracion = 0;

            if (faltas == 0 && !estaLesionado)
            {
                valoracion = 10;
            } else
            {
                valoracion = 5;
            }
            
                return valoracion;
        }
    }
}
