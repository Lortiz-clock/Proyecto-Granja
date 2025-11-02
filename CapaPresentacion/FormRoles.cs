using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormRoles : Form
    {
        CDRoles CdRoles = new CDRoles();
        public FormRoles()
        {
            InitializeComponent();
        }

       

        public void MtdCargarDatos()
        {
            DataTable dtCargarDatos = CdRoles.MtdCargarDatos();
            dgvRoll.DataSource = dtCargarDatos;
        }

        public void MensajeLimpiarCampos()
        {
            MessageBox.Show("La captura de datos ha sido cancelada. No se ha guardado ninguna información", "CANCELAR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public void MensajeTryCatch()
        {
            MessageBox.Show("Verificar que el tipo de datos ingresados son del tipo solicitado, vuelva a ingresar los datos", "TRY CATCH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void MensajeCamposVacios()
        {
            MessageBox.Show("Acción no ejecutada, campos vacios, revisar que niguna casilla este vacia", "CAMPOS VACIOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public void MensajeAccionEjecutada()
        {
            MessageBox.Show("Acción ejecutada, información actualizada en la Base de Datos", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MtdLimpiarCampos()
        {
            txtCodigoRol.Text = "";
            txtNombreRol.Text = "";
            cboxEstation.Text = "";
        }

        private void dgvRoll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoRol.Text = dgvRoll.CurrentRow.Cells[0].Value.ToString();
            txtNombreRol.Text = dgvRoll.CurrentRow.Cells[1].Value.ToString();
            cboxEstation.Text = dgvRoll.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
            MensajeLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigoRol.Text == "" || txtNombreRol.Text == "" || cboxEstation.Text == "")
                {
                    MensajeCamposVacios();
                }

                else
                {
                    int CodigoRol = int.Parse(txtCodigoRol.Text);
                    CdRoles.MtdEliminarDatos(CodigoRol);
                    MtdLimpiarCampos();
                    MtdCargarDatos();
                    MensajeAccionEjecutada();
                }
            }
            catch (Exception)
            {

                MtdLimpiarCampos();
                MtdCargarDatos();
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreRol.Text == "" || cboxEstation.Text == "")
                {
                    MensajeCamposVacios();
                }

                else
                {
                    string NombreRol = txtNombreRol.Text;
                    string Estado = cboxEstation.Text;
                    CdRoles.MtdAgregarDatos(NombreRol, Estado);
                    MensajeAccionEjecutada();
                    MtdLimpiarCampos();
                    MtdCargarDatos();
                }
            }
            catch (Exception)
            {

                MtdLimpiarCampos();
                MensajeTryCatch();
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigoRol.Text == "" || txtNombreRol.Text == "" || cboxEstation.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    int CodigoRol = int.Parse(txtCodigoRol.Text);
                    string NombreRol = txtNombreRol.Text;
                    string Estado = cboxEstation.Text;
                    CdRoles.MtdEditarDatos(CodigoRol, NombreRol, Estado);
                    MtdLimpiarCampos();
                    MtdCargarDatos();
                    MensajeAccionEjecutada();
                }

            }
            catch (Exception)
            {

                MtdLimpiarCampos();
                MensajeTryCatch();
            }
        }

        private void FormRoles_Load(object sender, EventArgs e)
        {
            MtdCargarDatos();
            lblFecha.Text = CdRoles.MtdFechaHoy().ToString("d");
        }
    }
}
