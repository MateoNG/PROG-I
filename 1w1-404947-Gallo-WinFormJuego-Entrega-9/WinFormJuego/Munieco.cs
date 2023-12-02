using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormPersonas
{
    public class Munieco
    {
        //atributos de instancias: de objetos Munieco
        private string nombre;
		private int energia;
        private int id;
        private static int contador = 0; // variable de CLASE y va a ser compartida por todos los objetos
                                        // de la clase 
		public int Energia
		{
			get { return energia;  }
			set { energia = value; }
		}

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Munieco()
        {
            this.nombre = string.Empty;
            energia = 100;
            contador++;
            id = -1;
        }

        public Munieco(string nombre)
		{
            this.nombre = nombre;
            energia = 100;
            contador++;
            id = -1;
        }  

        public static int Contador()
        {
            return contador;
        }

        public void Jugar(int t)
        {
            energia -= t;
        }

        public void Comer()
        {
        
            energia += 3;
            
        }

        public static void Disminuir()
        {
            if (contador <= 0)
            {
                contador = 0;
            }
            else if (contador > 0)
            {
                contador--;
            }
        }

        public override string ToString()
        {
            return nombre + "[" + energia + "]";
        }
    }
}
