using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos_PROG_U5_P5._2
{
    internal class Alumno
    {
        public Alumno(int idAlumno, string apellido, string nombre, DateTime fecNac, int sexo, int tipoDoc, Int32 doc, string calle, int nro, int actividad, int casado, int hijos, int cantidadHijos, int carrera)
        {
            IdAlumno = idAlumno;
            Apellido = apellido;
            Nombre = nombre;
            FecNac = fecNac;
            Sexo = sexo;
            TipoDoc = tipoDoc;
            Doc = doc;
            Calle = calle;
            Nro = nro;
            Actividad = actividad;
            Casado = casado;
            Hijos = hijos;
            CantidadHijos = cantidadHijos;
            Carrera = carrera;
        }

        public Alumno()
            {
            IdAlumno = 0;
            Apellido = string.Empty;
            Nombre = string.Empty;
            FecNac = DateTime.Today;
            Sexo = 0;
            TipoDoc = 0;
            Doc = 0;
            Calle = string.Empty;
            Nro = 0;
            Actividad = 0;
            Casado = 0;
            Hijos = 0;
            CantidadHijos = 0;
            Carrera = 0;
        }

        public int IdAlumno { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FecNac { get; set; }
        public int Sexo { get; set; }
        public int TipoDoc { get; set; }
        public Int32 Doc { get; set; }
        public string Calle { get; set; }
        public int Nro { get; set; }
        public int Actividad { get; set; }
        public int Casado { get; set; }
        public int Hijos { get; set; }
        public int CantidadHijos { get; set; }
        public int Carrera { get; set; }

        public override string ToString()
        {
            return Apellido + ", " + Nombre;
        }
    }
}
