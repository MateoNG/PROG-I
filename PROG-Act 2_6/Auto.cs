using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_Act_2_6
{
    internal class Auto
    {
        //Atributos
        private double combustible;
        private double capacidadMax;
        private double kmXlitro;

        //Propiedades
        public double pCombustible
        {
            get { return combustible; }
            set { combustible = value; }
        }

        public double pCapacidadMax
        {
            get { return capacidadMax; }
            set {capacidadMax = value; }
        }

        public double pKmXlitro
        {
            get { return kmXlitro; }
            set { kmXlitro = value; }
        }

        //Constructores

        public Auto()
        {
            this.combustible = 0;
            this.capacidadMax = 0;
            this.kmXlitro = 0;

        }

        public Auto(double combustible, double capacidadMax, double kmXlitro)
        {
            this.combustible = combustible;
            this.capacidadMax = capacidadMax;
            this.kmXlitro = kmXlitro;
        }

        //toString
        public string toString()
        {
            string aux = "\nCombustible: " + combustible + " Litros. " + "\nCapacidad Max: " + capacidadMax + " Litros. " + "\nKm por Litro: " + kmXlitro + " Kms. "; 
            return aux;
        }

        //Métodos

        public string Conducir(double kms)
        {
            string aux = "";
            double aux2 = combustible * kmXlitro;
            double aux3 = 0;

            if (kms < aux2)
            {
                aux = "\nSe pueden recorrer " + kms + " kilómetros.";
                aux3 = kms / kmXlitro;
                combustible = combustible - aux3;
            } 
            else 
            {
                aux = "\nNo se pueden recorrer " + kms + " kilómetros por que no hay combustible suficiente.";
            }

            return aux;
        }

        public string CargarCombustible(double litros)
        {
            string aux = "";
            double aux2 = 0;
            if(litros < capacidadMax)
            {
                combustible = combustible + litros;
                aux = "\nSe cargaron " + litros + " litros al tanque.";
            }
            else
            {
                aux2 = litros - capacidadMax;
                aux = "\nSobran " + aux2 + " litros de combustible y se han devuelto.";
                combustible = (combustible + litros) - aux2;
            }

            return aux;

        }
    }
}
