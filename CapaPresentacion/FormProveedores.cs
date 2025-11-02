using CapaDatos;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{


    public partial class Form1 : Form
    {

        CdProveedores Prove = new CdProveedores();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            lblFecha.Text = Prove.MtdFechaHoy().ToString("d");
            MtdCargarDatos();
            MtdLimpiarCampos();
        }
        private void MtdCargarDatos()
        {
            CdProveedores obj = new CdProveedores();
            dgvProveedores.DataSource = obj.MtdMostrarDatos();
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

        private void label17_Click(object sender, EventArgs e)
        {

        }
        private void MtdLimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            cboxEstado.SelectedIndex = -1; // Limpia la selección del ComboBox
        }
        private void txtCodigoEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dgvProveedores.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvProveedores.CurrentRow.Cells[1].Value.ToString();
            txtTelefono.Text = dgvProveedores.CurrentRow.Cells[2].Value.ToString();
            txtCorreo.Text = dgvProveedores.CurrentRow.Cells[3].Value.ToString();
            txtDireccion.Text = dgvProveedores.CurrentRow.Cells[4].Value.ToString();
            cboxEstado.Text = dgvProveedores.CurrentRow.Cells[5].Value.ToString();
        }
        private void btnGuard_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtDireccion.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    CdProveedores obj = new CdProveedores();
                    obj.MtdAgregarDatos(txtNombre.Text, txtTelefono.Text, txtCorreo.Text, txtDireccion.Text, cboxEstado.Text);
                    MensajeAccionEjecutada();
                    MtdLimpiarCampos();
                    MtdCargarDatos();
                }
            }
            catch (Exception)
            {
                MensajeTryCatch();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtDireccion.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    int codigo = int.Parse(txtCodigo.Text);
                    CdProveedores obj = new CdProveedores();
                    obj.MtdEditarDatos(codigo, txtNombre.Text, txtTelefono.Text, txtCorreo.Text, txtDireccion.Text, cboxEstado.Text);
                    MensajeAccionEjecutada();
                    MtdLimpiarCampos();
                    MtdCargarDatos();
                }
            }
            catch (Exception)
            {
                MensajeTryCatch();
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    int codigo = int.Parse(txtCodigo.Text);
                    CdProveedores obj = new CdProveedores();
                    obj.MtdEliminarDatos(codigo);
                    MensajeAccionEjecutada();
                    MtdLimpiarCampos();
                    MtdCargarDatos();
                }
            }
            catch (Exception)
            {
                MensajeTryCatch();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();

        }
    }
}
