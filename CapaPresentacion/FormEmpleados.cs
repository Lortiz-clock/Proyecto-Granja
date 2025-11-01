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
    public partial class FormEmpleados : Form
    {
        CDEmpleados CdEmpleados = new CDEmpleados();
        public FormEmpleados()
        {
            InitializeComponent();
        }

        private void FormEmpleados_Load(object sender, EventArgs e)
        {
            lblFecha.Text = CdEmpleados.MtdFechaHoy().ToString("d");
            MtdCargarDatos();
        }

        public void MtdCargarDatos()
        {
            DataTable dtCargarDatos = CdEmpleados.MtdCargarDatos();
            dgvEmpleados.DataSource = dtCargarDatos;
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
            txtCodigoEmpleado.Text = "";
            txtCodigoGranja.Text = "";
            txtNombreEmpleado.Text = "";
            txtTel.Text = "";
            txtCorr.Text = "";
            txtCargo.Text = "";
            txtFechaIngreso.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cboxEstado.Text = "";
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtCodigoEmpleado.Text = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
            txtCodigoGranja.Text = dgvEmpleados.CurrentRow.Cells[1].Value.ToString();
            txtNombreEmpleado.Text = dgvEmpleados.CurrentRow.Cells[2].Value.ToString();
            txtTel.Text = dgvEmpleados.CurrentRow.Cells[3].Value.ToString();
            txtCorr.Text = dgvEmpleados.CurrentRow.Cells[4].Value.ToString();
            txtCargo.Text = dgvEmpleados.CurrentRow.Cells[5].Value.ToString();
            txtFechaIngreso.Text = Convert.ToDateTime(dgvEmpleados.CurrentRow.Cells[6].Value).ToString("yyyy-MM-dd");
            cboxEstado.Text = dgvEmpleados.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
            MensajeCamposVacios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigoEmpleado.Text == "" || txtCodigoGranja.Text == "" || txtNombreEmpleado.Text == "" || txtTel.Text == "" || txtCorr.Text == "" || txtCargo.Text == "" || txtFechaIngreso.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }

                else
                {
                    int CodigoEmpleado = Convert.ToInt32(txtCodigoEmpleado.Text);
                    CdEmpleados.MtdEliminarDatos(CodigoEmpleado);
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

        private void btnGuard_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreEmpleado.Text == "" || txtTel.Text == "" || txtCorr.Text == "" || txtCargo.Text == "" || txtFechaIngreso.Text == "" || cboxEsta.Text == "")
                {
                    MensajeCamposVacios();
                }

                else
                {
                    string Nombre = txtNombreEmpleado.Text;
                    string Telefono = txtTel.Text;
                    string Correo = txtCorr.Text;
                    string Cargo = txtCargo.Text;
                    DateTime FechaIngreso = DateTime.Parse(txtFechaIngreso.Text);
                    string Estado = cboxEsta.Text;
                    CdEmpleados.MtdAgregarDatos(Nombre, Telefono, Correo, Cargo, FechaIngreso, Estado);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreEmpleado.Text == "" || txtTel.Text == "" || txtCorr.Text == "" || txtCargo.Text == "" || txtFechaIngreso.Text == "" || cboxEsta.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    int CodigoEmpleado = int.Parse(txtCodigoEmpleado.Text);
                    string NombreEmpleado = txtNombreEmpleado.Text;
                    string Telefono = txtTel.Text;
                    string Correo = txtCorr.Text;
                    string Cargo = txtCargo.Text;
                    DateTime FechaIngreso = DateTime.Parse(txtFechaIngreso.Text);
                    string Estado = cboxEsta.Text;
                    CdEmpleados.MtdEditarDatos(CodigoEmpleado, NombreEmpleado, Telefono, Correo, Cargo, FechaIngreso, Estado);
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
