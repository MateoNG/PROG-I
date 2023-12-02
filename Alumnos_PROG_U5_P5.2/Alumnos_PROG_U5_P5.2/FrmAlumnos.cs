using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alumnos_PROG_U5_P5._2
{
    public partial class FrmAlumnos : Form
    {
        bool esNuevo;
        AccesoBD aBD;
        List<Alumno> lAlumnos;

        public FrmAlumnos()
        {
            InitializeComponent();
            aBD = new AccesoBD();
            lAlumnos = new List<Alumno>();
        }
        //Metodos
        private void chbxHijos_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxHijos.Checked)
            {
                txtCantidad.Enabled = true;
            } else
            {
                txtCantidad.Enabled = false;
            }
        }

        private void FrmAlumnos_Load(object sender, EventArgs e)
        {
            habilitar(false);
            cargarCombo("Tipo_doc", cboTipoDoc, "documento", "id_tipo_doc");
            cargarCombo("Carreras", cboCarrera, "carrera", "id_carrera");
            cargarLista();
        }

        private void cargarLista()
        {
            lAlumnos.Clear();
            lstAlumnos.Items.Clear();

            DataTable tabla = aBD.ConsultarBD("SELECT * FROM Alumnos");
            foreach (DataRow fila in tabla.Rows)
            {
                Alumno a = new Alumno();
                a.IdAlumno = Convert.ToInt32(fila[0]);
                a.Apellido = Convert.ToString(fila[1]);
                a.Nombre = Convert.ToString(fila[2]);
                a.FecNac = Convert.ToDateTime(fila[3]);
                a.Sexo = Convert.ToInt32(fila[4]);
                a.TipoDoc = Convert.ToInt32(fila[5]);
                a.Doc = Convert.ToInt32(fila[6]);
                a.Calle = Convert.ToString(fila[7]);
                a.Nro = Convert.ToInt32(fila[8]);
                a.Actividad = Convert.ToInt32(fila[9]);
                a.Casado = Convert.ToInt32(fila[10]);
                a.Hijos= Convert.ToInt32(fila[11]);
                a.CantidadHijos= Convert.ToInt32(fila[12]);
                a.Carrera=Convert.ToInt32(fila[13]);

                lAlumnos.Add(a);
                lstAlumnos.Items.Add(a.ToString());
            }
        }

        private void cargarCombo(string combo, ComboBox cbo, string col1, string col2)
        {
            DataTable tabla = aBD.ConsultarBD("SELECT * FROM " + combo + " ORDER BY 2");
            cbo.DataSource = tabla;
            cbo.DisplayMember = col1;
            cbo.ValueMember = col2;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.SelectedIndex = -1;
        }

        private void habilitar(bool v)
        {
            txtApellido.Enabled = v;
            txtNombre.Enabled = v;
            dtpFecNac.Enabled = v;
            rbtFemenino.Enabled = v;
            rbtMasculino.Enabled = v;
            cboTipoDoc.Enabled = v;
            txtDoc.Enabled = v;
            txtCalle.Enabled = v;
            txtNro.Enabled = v;
            chbxActividad.Enabled = v;
            chbxCasado.Enabled = v;
            chbxHijos.Enabled = v;
            txtCantidad.Enabled = v;
            cboCarrera.Enabled = v;
            btnEditar.Enabled = v;
            btnBorrar.Enabled = v;
            btnGrabar.Enabled = v;
            btnCancelar.Enabled = v;
            btnNuevo.Enabled = !v;
            btnSalir.Enabled = !v;
            lstAlumnos.Enabled = !v;
        }

        //boton salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Está seguro de Salir?", 
                "SALIR", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                Close();
            }
        }

        //boton nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            habilitar(true);
            btnBorrar.Enabled = false; 
            btnEditar.Enabled = false;
            txtCantidad.Enabled = false;

            limpiar();
            txtApellido.Focus();
        }

        private void limpiar()
        {
            txtApellido.Text=string.Empty;
            txtNombre.Text = string.Empty;
            dtpFecNac.Value = DateTime.Today;
            rbtFemenino.Checked = false;
            rbtMasculino.Checked = false;
            cboTipoDoc.SelectedIndex = -1;
            txtDoc.Text = string.Empty;
            txtCalle.Text = string.Empty;
            txtNro.Text = string.Empty;
            chbxActividad.Checked = false;
            chbxCasado.Checked = false; 
            chbxHijos.Checked = false;
            txtCantidad.Text = string.Empty;
            cboCarrera.SelectedIndex = -1;
        }
        //boton cancelar
        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar(false);
        }

        //boton grabar
        private void button3_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Alumno a = new Alumno();
                a.Apellido = Convert.ToString(txtApellido.Text);
                a.Nombre = Convert.ToString(txtNombre.Text);
                a.FecNac = Convert.ToDateTime(dtpFecNac.Value);

                if (rbtMasculino.Checked)
                {
                    a.Sexo = 1;
                }
                else
                {
                    a.Sexo = 2;
                }

                a.TipoDoc = Convert.ToInt32(cboTipoDoc.SelectedValue);
                a.Doc = Convert.ToInt32(txtDoc.Text);
                a.Calle = Convert.ToString(txtCalle.Text);
                a.Nro= Convert.ToInt32(txtNro.Text);

                if (chbxActividad.Checked)
                {
                    a.Actividad = 1;
                } else
                {
                    a.Actividad = 0;
                }

                if (chbxCasado.Checked)
                {
                    a.Casado = 1;
                }
                else
                {
                    a.Casado = 0;
                }

                if (chbxHijos.Checked)
                {
                    a.Hijos = 1;
                }
                else
                {
                    a.Hijos = 0;
                }

                if (txtCantidad.Text==string.Empty)
                {
                    a.CantidadHijos = 0;
                } else
                {
                    a.CantidadHijos = Convert.ToInt32(txtCantidad.Text);
                }

                a.Carrera = Convert.ToInt32(cboCarrera.SelectedValue);

                string sentenciaSQL = "";
                List<Parametro> lParametros = new List<Parametro>();
                
                if (esNuevo)
                {
                    if (!existe(a))
                    {
                         sentenciaSQL = "INSERT INTO Alumnos " +
                           "VALUES (@apellido, @nombre, @fecnac, @sexo, @tipodoc, @doc, " +
                           "@calle, @nro, @actividad, @casado, @hijos, @cantidad, @carrera)";

                    }
                    else
                    {
                        MessageBox.Show("El Alumno ya está registrado");
                    }
                }
                else
                {
                     sentenciaSQL = "UPDATE Alumnos SET nombre=@nombre, " +
                                       "apellido=@apellido, fecha_nacimiento=@fecnac, sexo=@sexo, " +
                                       "id_tipo_doc=@tipodoc, documento=@doc, calle=@calle, " +
                                       "nro_calle=@nro, actividad=@actividad, casado=@casado, " +
                                       "hijos=@hijos, cant_hijos=@cantidad, id_carrera=@carrera " +
                                       "WHERE documento=@doc";

                }

                lParametros.Clear();
                lParametros.Add(new Parametro("@apellido", a.Apellido));
                lParametros.Add(new Parametro("@nombre", a.Nombre));
                lParametros.Add(new Parametro("@fecnac", a.FecNac));
                lParametros.Add(new Parametro("@sexo", a.Sexo));
                lParametros.Add(new Parametro("@tipodoc", a.TipoDoc));
                lParametros.Add(new Parametro("@doc", a.Doc));
                lParametros.Add(new Parametro("@calle", a.Calle));
                lParametros.Add(new Parametro("@nro", a.Nro));
                lParametros.Add(new Parametro("@actividad", a.Actividad));
                lParametros.Add(new Parametro("@casado", a.Casado));
                lParametros.Add(new Parametro("@hijos", a.Hijos));
                lParametros.Add(new Parametro("@cantidad", a.CantidadHijos));
                lParametros.Add(new Parametro("@carrera", a.Carrera));

                if (aBD.ActualizarBD(sentenciaSQL, lParametros) > 0)
                {
                    MessageBox.Show("La Base de Datos se actualizó con éxito");

                } else
                {
                    MessageBox.Show("La Base de Datos NO se pudo actualizar");
                }

                cargarLista();
                habilitar(false);
            }
        }
        
        private bool existe(Alumno nuevo)
        {
            foreach (Alumno a in lAlumnos)
            {
                if (a.IdAlumno == nuevo.IdAlumno || a.Doc == nuevo.Doc)
                {
                    return true;
                }
            }
            return false;
        }

        private bool validarDatos()
        {
            if (txtApellido.Text==string.Empty)
            {
                MessageBox.Show("Ingrese un Apellido");
                txtApellido.Focus();
                return false;
            }

            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Nombre");
                txtNombre.Focus();
                return false;
            }

            if (DateTime.Today.Year - dtpFecNac.Value.Year < 17 || DateTime.Today.Year - dtpFecNac.Value.Year > 110)
            {
                MessageBox.Show("Ingrese una Fecha de Nacimiento válida");
                dtpFecNac.Focus();
                return false;
            }

            if (!rbtFemenino.Checked && !rbtMasculino.Checked)
            {
                MessageBox.Show("Seleccione un sexo");
                rbtMasculino.Focus();
                return false;
            }

            if (cboTipoDoc.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un Tipo de Documento");
                cboTipoDoc.Focus();
                return false;
            }

            if (txtDoc.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Nro de Documento");
                txtDoc.Focus();
                return false;
            }

            if (txtCalle.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una Calle");
                txtCalle.Focus();
                return false;
            }

            if (txtNro.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Nombre");
                txtNro.Focus();
                return false;
            }

            if(chbxHijos.Checked && txtCantidad.Text == string.Empty)
            {
                MessageBox.Show("Ingrese la Cantidad de Hijos");
                txtCantidad.Focus();
                return false;
            }

            if (cboCarrera.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una Carrera");
                cboCarrera.Focus();
                return false;
            }

            return true;
        }

        //boton editar
        private void button1_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            habilitar(true);
            btnEditar.Enabled = false;
            txtDoc.Enabled = false;
        }

        //boton borrar
        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Está seguro de Borrar a " + lAlumnos[lstAlumnos.SelectedIndex].ToString() + "?",
                "BORRAR", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning, 
                MessageBoxDefaultButton.Button2) 
                == DialogResult.Yes)
            {
                string sentenciaSQL = 
                       "DELETE Alumnos WHERE documento=" + lAlumnos[lstAlumnos.SelectedIndex].Doc;

                if (aBD.ActualizarBD(sentenciaSQL) > 0)
                {
                    MessageBox.Show("Se eliminó el Alumno");
                    cargarLista();
                } else
                {
                    MessageBox.Show("NO se pudo eliminar el Alumno");
                }

            }
        }

        private void lstAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCampos(lstAlumnos.SelectedIndex);
            btnEditar.Enabled = true;
            btnBorrar.Enabled = true;
            txtCantidad.Enabled = false;
        }

        private void cargarCampos(int pos)
        {
            txtApellido.Text = lAlumnos[pos].Apellido;
            txtNombre.Text = lAlumnos[pos].Nombre;
            dtpFecNac.Value = lAlumnos[pos].FecNac;

            if (lAlumnos[pos].Sexo == 1)
            {
                rbtMasculino.Checked = true;
            } else
            {
                rbtFemenino.Checked = true;
            }

            cboTipoDoc.SelectedValue = lAlumnos[pos].TipoDoc;
            txtDoc.Text = Convert.ToString(lAlumnos[pos].Doc);
            txtCalle.Text = Convert.ToString(lAlumnos[pos].Calle);
            txtNro.Text = Convert.ToString(lAlumnos[pos].Nro);

            if (lAlumnos[pos].Actividad == 1)
            {
                chbxActividad.Checked = true;
            } else
            {
                chbxActividad.Checked = false;
            }

            if (lAlumnos[pos].Casado == 1)
            {
                chbxCasado.Checked = true;
            }
            else
            {
                chbxCasado.Checked = false;
            }

            if (lAlumnos[pos].Hijos == 1)
            {
                chbxHijos.Checked = true;
            }
            else
            {
                chbxHijos.Checked = false;
            }

            if (chbxHijos.Checked == true)
            {
                txtCantidad.Text = Convert.ToString(lAlumnos[pos].CantidadHijos);
            } else
            {
                txtCantidad.Text = string.Empty;
            }

            cboCarrera.SelectedValue = lAlumnos[pos].Carrera;
        }
    }
}
