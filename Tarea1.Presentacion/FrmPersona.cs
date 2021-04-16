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

        private void Insertar()
        {
            try
            {
                var edad = 0;
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtTelefono.Text))
                {
                    this.MensajeError("Falta ingresar un dato, por favor revisar");
                } 
                if (int.TryParse(txtEdad.Text.Trim(), out edad)){
                    var Rpta = NPersona.Insertar(txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtTelefono.Text.Trim(), edad);
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se inserto el registro correctamente");
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
                else
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
