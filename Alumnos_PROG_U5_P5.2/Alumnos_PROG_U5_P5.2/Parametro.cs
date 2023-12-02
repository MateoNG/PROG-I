using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos_PROG_U5_P5._2
{
    internal class Parametro
    {
        public Parametro(string nombre, object valor)
        {
            Nombre = nombre;
            Valor = valor;
        }

        public string Nombre { get; set; }

        public Object Valor { get; set; }


    }
}
