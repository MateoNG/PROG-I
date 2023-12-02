using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WinFormPersonas
{
    public partial class FrmJuego : Form
    {

        bool esNuevo = false;
        const int tamanio = 100;
        Munieco[] oMuniecos = new Munieco[tamanio]; // arreglo estático de tamanio de Muniecos 
        int ultimo = 0;

        SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-TGCA48H\SQLEXPRESS02;Initial Catalog=PROG_Entrega_9;Integrated Security=True");

        SqlCommand comando;
        SqlDataReader lector;

        public FrmJuego()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;

            if (String.IsNullOrEmpty(nombre) == false)
            //if (!String.IsNullOrEmpty(txtNombre.Text))
            {
                Munieco m = new Munieco(nombre);

                // insert con sentencia SQL
                string strInsert = "INSERT INTO Muniecos (Nombre, Energia) " +
                                   "VALUES ('" + m.Nombre + "', " + m.Energia + ")";

                conexion.Open();
                comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = strInsert;
                comando.ExecuteNonQuery();
                conexion.Close();

                //lstMuñecos.Items.Add(oMunieco);
                txtNombre.Text = String.Empty; //Esto deja la caja en blanco nuevamente para una próx entrada
                txtNombre.Focus(); //Esto deja el curso sobre el componente
                CargarLista();
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre para el muñeco!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmJuego_Load(object sender, EventArgs e)
        {
            // lstMuñecos.Items.Clear(); esto es un obviedad porque cuando se carga a memoria ya esta vacío
            CargarLista();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Salir de la ventana", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (Munieco.Contador() < 1)
            {
                MessageBox.Show("Debe haber ingresado un muñeco para poder borrar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Munieco.Contador() >= 1)
            {
                if (lstMuñecos.SelectedIndex != -1)
                {
                    if (MessageBox.Show("Está seguro de eliminar a " + oMuniecos[lstMuñecos.SelectedIndex].ToString(), 
                        "BORRANDO", 
                        MessageBoxButtons.OKCancel, 
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        Munieco.Disminuir();

                        string strDelete = "DELETE FROM Muniecos WHERE Id = " + oMuniecos[lstMuñecos.SelectedIndex].Id;

                        conexion.Open();
                        comando = new SqlCommand();
                        comando.Connection = conexion;
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = strDelete;
                        comando.ExecuteNonQuery();
                        conexion.Close();
                        CargarLista();

                    }
                }
                else
                {
                    MessageBox.Show("Debe haber seleccionado un muñeco para poder borrar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            if (Munieco.Contador() < 1)
            {
                MessageBox.Show("Debe haber ingresado un muñeco para poder jugar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Munieco.Contador() >= 1)
            {
                Munieco m = GetItemText(lstMuñecos.SelectedIndex);
                if (m != null) {
                    int segundosJugar = 0;
                    string stringJugar = Interaction.InputBox("Ingrese la cantidad de segundos para jugar:", "Jugar", "2", -1, -1);
                    int.TryParse(stringJugar, out segundosJugar);
                    if (m.Energia < segundosJugar)
                    {
                        MessageBox.Show("La cantidad de segundos es mayor a la energia!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        m.Jugar(segundosJugar);
                        lstMuñecos.Items[lstMuñecos.SelectedIndex] = m;

                        string strUpdate = "UPDATE Muniecos " +
                                       "SET Energia = " + m.Energia +
                                       "WHERE Id = " + m.Id;

                        conexion.Open();
                        comando = new SqlCommand();
                        comando.Connection = conexion;
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = strUpdate;
                        comando.ExecuteNonQuery();
                        conexion.Close();

                        CargarLista();
                        lstMuñecos.Focus();
                    }
                }
            }
        }

        private Munieco GetItemText(int i)
        {
            Munieco auxMunieco = null;
            if (lstMuñecos.SelectedIndex==-1)
            {
                MessageBox.Show("Debe seleccionar un muñeco!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                auxMunieco = lstMuñecos.Items[i] as Munieco;
            }
            return auxMunieco;
        }

        private void btnComer_Click(object sender, EventArgs e)
        {
            if (Munieco.Contador() < 1)
            {
                MessageBox.Show("Debe haber ingresado un muñeco para poder jugar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Munieco.Contador() >= 1)
            {
                Munieco m = GetItemText(lstMuñecos.SelectedIndex);
                if (m != null)
                {
                    m.Comer();
                    lstMuñecos.Items[lstMuñecos.SelectedIndex] = m;


                    string strUpdate = "UPDATE Muniecos " +
                                       "SET Energia = " + m.Energia + 
                                       "WHERE Id = " + m.Id;

                    conexion.Open();
                    comando = new SqlCommand();
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = strUpdate;
                    comando.ExecuteNonQuery();
                    conexion.Close();

                    CargarLista();
                }
            }
        }
        private void CargarLista()
        {
            conexion.Open();
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Muniecos";

            lector = comando.ExecuteReader();
            ultimo = 0;
            while (lector.Read())
            {
                Munieco m = new Munieco();
                if (!lector.IsDBNull(0))    //para validar que la columna de la BD contiene datos
                    m.Id = Convert.ToInt32(lector["Id"]);
                if (!lector.IsDBNull(1))    //para validar que la columna de la BD contiene datos
                    m.Nombre = lector["Nombre"].ToString();
                if (!lector.IsDBNull(2))
                    m.Energia = Convert.ToInt32(lector[2]);
                

                oMuniecos[ultimo] = m;
                ultimo++;
            }
            conexion.Close();

            lstMuñecos.Items.Clear();
            for (int i = 0; i < ultimo; i++)
            {
                lstMuñecos.Items.Add(oMuniecos[i]);
            }
            lstMuñecos.SelectedIndex = -1;
        }
    }
}
