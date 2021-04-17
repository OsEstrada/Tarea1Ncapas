using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tarea1.Negocio;

namespace Tarea1.Presentacion
{
    public partial class FrmPersona : Form
    {
        public FrmPersona()
        {
            InitializeComponent();
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Personas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Personas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Limpiar()
        {
            txtApellido.Clear();
            txtEdad.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
        }

        //Carga los datos de la base de datos en el datagrid
        private void Listar()
        {
            try
            {
                dgvListadoPersonas.DataSource = NPersona.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Lee los datos de los textbox y los envia a la capa de Negocio para realizar la insercion en la base de datos
        private void Insertar()
        {
            try
            {
                var edad = 0;
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtTelefono.Text)) //Verifica si todos los campos excepto edad estan llenos
                {
                    this.MensajeError("Falta ingresar un dato, por favor revisar");
                } 
                if (int.TryParse(txtEdad.Text.Trim(), out edad)) //Revisa si edad almacena una cadena que puede interpretarse como un numero entero, de ser asi lo almacena en la variable edad
                {
                    var Rpta = NPersona.Insertar(txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtTelefono.Text.Trim(), edad);
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se inserto el registro correctamente");
                        this.Listar();
                        this.Limpiar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
                else //Si no es un numero entero, entonces se envia un mensaje de error
                {
                    this.MensajeError("La edad debe ser un dato númerico, por favor revisar"); 
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void FrmPersona_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.Insertar();
        }
    }
}
