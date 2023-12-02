using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos_PROG_U5_P5._2
{
    internal class AccesoBD
    {
        //DESKTOP-TGCA48H\SQLEXPRESS02

        string cadenaConexion;
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;

        public AccesoBD()
        { 
            cadenaConexion = @"Data Source=DESKTOP-TGCA48H\SQLEXPRESS02;Initial Catalog=Escuela_PROG_U5_P5.2;Integrated Security=True";
            conexion = new SqlConnection(cadenaConexion);
            
        }

        private void Conectar()
        {
            conexion.Open();
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }
        private void Desconectar()
        {
            conexion.Close();
        }

        public DataTable ConsultarBD(string consultaSQL)
        {
            DataTable tabla = new DataTable();

            Conectar();

            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());

            Desconectar();

            return tabla;
        }

        public int ActualizarBD(string consultaSQL, List<Parametro> lParametros)
        {
            int filasAfectadas = 0;
            Conectar();
            comando.CommandText = consultaSQL;

            foreach (Parametro p in lParametros)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }

            filasAfectadas = comando.ExecuteNonQuery();
            Desconectar();
            return filasAfectadas;
        }

        public int ActualizarBD(string consultaSQL)
        {
            int filasAfectadas = 0;
            Conectar();
            comando.CommandText = consultaSQL;
            filasAfectadas = comando.ExecuteNonQuery();
            Desconectar();
            return filasAfectadas;
        }

        //metodos extra (no son necesarios)
        public void LeerTabla(string nombreTabla) //metodo que carga un datareader
        {
            Conectar();
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            lector = comando.ExecuteReader();
        }

        public DataTable ConsultarTabla(string nombreTabla) //metodo que devuelve datatable de una tabla
        {
            DataTable tabla = new DataTable();
            Conectar();
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            tabla.Load(comando.ExecuteReader());
            Desconectar();
            return tabla;
        }

        public DataTable ConsultarBD2(string consultaSQL)    //metodo que devuelve datatable de cualquier consulta
        {
            DataTable tabla = new DataTable();
            Conectar();
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            Desconectar();
            return tabla;
        }
    }
}
