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
    public partial class FormEnvios : Form
    {

        CDEnvios cd_Envios = new CDEnvios();
        public FormEnvios()
        {
            InitializeComponent();
            lblFecha.Text = cd_Envios.MtdFechaHoy().ToString("d");
            MtdCargarDatos();
            MtdLimpiarCampos();
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoEnvio.Text = "";
            cboxCodigoVenta.Text = "";
            txtDireccionEnvio.Text = "";
            cboxTipoTransporte.Text = "";
            txtPlacaTransporte.Text = "";
            txtObservacion.Text = "";
            cboxEstado.Text = "";
        }

        public void MtdCargarDatos()
        {
            DataTable dtCargarDatos = cd_Envios.MtdCargarDatos();
            dgvEnviosGranja.DataSource = dtCargarDatos;
        }

        //Metodo para Mostrar Mensajes en Pantalla
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


        private void FormEnvios_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigoEnvio.Text == "" || cboxCodigoVenta.Text == "" || DtpFechaEnvio.Text == "" || txtDireccionEnvio.Text == "" || cboxTipoTransporte.Text == "" || txtPlacaTransporte.Text == "" || txtObservacion.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    int CodigoEnvio = int.Parse(txtCodigoEnvio.Text);
                    cd_Envios.MtdEliminarEnvios(CodigoEnvio);
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
                if (cboxCodigoVenta.Text == "" || DtpFechaEnvio.Text == "" || txtDireccionEnvio.Text == "" || cboxTipoTransporte.Text == "" || txtPlacaTransporte.Text == "" || txtObservacion.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    int CodigoEnvio = int.Parse(txtCodigoEnvio.Text);
                    int CodigoVenta = int.Parse(cboxCodigoVenta.Text);
                    DateTime FechaEnvio = cd_Envios.MtdFechaHoy();
                    string DireccionEnvio = txtDireccionEnvio.Text;
                    string TipoTransporte = cboxTipoTransporte.Text;
                    string PlacaTransporte = txtPlacaTransporte.Text;
                    string Observacion = txtObservacion.Text;
                    string Estado = cboxEstado.Text;
                    cd_Envios.MtdActualizarEnvio(CodigoEnvio, CodigoVenta, FechaEnvio, DireccionEnvio, TipoTransporte, PlacaTransporte, Observacion, Estado);
                    MensajeAccionEjecutada();
                    MtdLimpiarCampos();
                    MtdCargarDatos();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboxCodigoVenta.Text == "" || DtpFechaEnvio.Text == "" || txtDireccionEnvio.Text == "" || cboxTipoTransporte.Text == "" || txtPlacaTransporte.Text == "" || txtObservacion.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else

                {
                    int CodigoVenta = int.Parse(cboxCodigoVenta.Text);
                    DateTime FechaEnvio = cd_Envios.MtdFechaHoy();
                    string DireccionEnvio = txtDireccionEnvio.Text;
                    string TipoTransporte = cboxTipoTransporte.Text;
                    string PlacaTransporte = txtPlacaTransporte.Text;
                    string Observacion = txtObservacion.Text;
                    string Estado = cboxEstado.Text;
                    cd_Envios.MtdAgregarEnvio(CodigoVenta, FechaEnvio, DireccionEnvio, TipoTransporte, PlacaTransporte, Observacion, Estado);
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
            MensajeLimpiarCampos();
        }

        private void dgvEnviosGranja_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var FilaSeleccionada = dgvEnviosGranja.SelectedRows[0];
            if (FilaSeleccionada.Index == dgvEnviosGranja.Rows.Count - 1)
            {
                MessageBox.Show("Seleccione una fila con datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtCodigoEnvio.Text = dgvEnviosGranja.SelectedCells[0].Value.ToString();
                cboxCodigoVenta.Text = dgvEnviosGranja.SelectedCells[1].Value.ToString();
                DtpFechaEnvio.Text = dgvEnviosGranja.SelectedCells[2].Value.ToString();
                txtDireccionEnvio.Text = dgvEnviosGranja.SelectedCells[3].Value.ToString();
                cboxTipoTransporte.Text = dgvEnviosGranja.SelectedCells[4].Value.ToString();
                txtPlacaTransporte.Text = dgvEnviosGranja.SelectedCells[5].Value.ToString();
                txtObservacion.Text = dgvEnviosGranja.SelectedCells[6].Value.ToString();
                cboxEstado.Text = dgvEnviosGranja.SelectedCells[7].Value.ToString();

            }

        }
    }
}
