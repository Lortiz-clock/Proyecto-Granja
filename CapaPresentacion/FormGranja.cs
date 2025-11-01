using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class FormGranja : Form
    {
        CDGranja CdGranja = new CDGranja();
        public FormGranja()
        {
            InitializeComponent();
        }

        private void FormGranja_Load(object sender, EventArgs e)
        {

            lblFecha.Text = CdGranja.MtdFechaHoy().ToString("d");
            MtdLimpiarCampos();
            MtdCargarDatos();
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoGranja.Text = "";
            txtDireccionGranja.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtCodigoPostal.Text = "";
            cboxEstado.Text = "";
        }

        public void MtdCargarDatos()
        {
            DataTable dtCargarDatos = CdGranja.MtdCargarDatos();
            dgvGranja.DataSource = dtCargarDatos;
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

        private void dgvGranja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoGranja.Text = dgvGranja.SelectedCells[0].Value.ToString();
            txtDireccionGranja.Text = dgvGranja.SelectedCells[1].Value.ToString();
            txtTelefono.Text = dgvGranja.SelectedCells[2].Value.ToString();
            txtCorreo.Text = dgvGranja.SelectedCells[3].Value.ToString();
            txtCodigoPostal.Text = dgvGranja.SelectedCells[4].Value.ToString();
            cboxEstado.Text = dgvGranja.SelectedCells[5].Value.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
            MensajeCamposVacios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDireccionGranja.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtCodigoPostal.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }

                else
                {
                    int CodigoGranja = int.Parse(txtCodigoGranja.Text);
                    CdGranja.MtdEliminarDatos(CodigoGranja);
                    MensajeAccionEjecutada();
                    MtdLimpiarCampos();
                    MtdCargarDatos();
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
                if (txtDireccionGranja.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtCodigoPostal.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }

                else
                {
                    string Direccion = txtDireccionGranja.Text;
                    string Telefono = txtTelefono.Text;
                    string Correo = txtCorreo.Text;
                    string CodigoPostal = txtCodigoPostal.Text;
                    string Estado = cboxEstado.Text;
                    CdGranja.MtdAgregarDatos(Direccion, Telefono, Correo, int.Parse(CodigoPostal), Estado);
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
                if (txtDireccionGranja.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtCodigoPostal.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    int CodigoGranja = int.Parse(txtCodigoGranja.Text);
                    string Direccion = txtDireccionGranja.Text;
                    string Telefono = txtTelefono.Text;
                    string Correo = txtCorreo.Text;
                    string CodigoPostal = txtCodigoPostal.Text;
                    string Estado = cboxEstado.Text;
                    CdGranja.MtdEditarDatos(CodigoGranja, Direccion, Telefono, Correo, int.Parse(CodigoPostal), Estado);
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

    }

}
