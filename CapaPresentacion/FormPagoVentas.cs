using CapaDatos;
using CapaLogica;
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
    public partial class FormPagoVentas : Form
    {

        ClPagoVenta cl_PagoVenta = new ClPagoVenta();
        CDPagoVentas cd_PagoVentas = new CDPagoVentas();

        public FormPagoVentas()
        {
            InitializeComponent();
            lblFecha.Text = cd_PagoVentas.MtdFechaHoy().ToString("d");
            MtdConsultaPagoVentas();
            MtdMostrarListaVentas();
            MtdLimpiarCampos();

            if (string.IsNullOrEmpty(txtCodigoPagoVentas.Text))
            {
                txtMonto.Text = 0m.ToString("C2");
            }
            else
            {
                if (int.TryParse(txtMonto.Text, out int CodigoPagoVenta))
                {
                    decimal totalMonto = Convert.ToDecimal(cl_PagoVenta.MtdTotalPagoVenta(CodigoPagoVenta));
                    txtMonto.Text = totalMonto.ToString("C2");
                }
                else
                {
                    txtMonto.Text = 0m.ToString("C2");
                }
            }
        }

        private void MtdConsultaPagoVentas()
        {
            DataTable dtPagosVentas = cd_PagoVentas.MtdConsultaPagosVentas();
            dgvPagosVentasGranja.DataSource = dtPagosVentas;
        }

        private void MtdMostrarListaVentas()
        {
            var ListaVentas = cd_PagoVentas.MtdListaVentas();

            foreach (var Venta in ListaVentas)
            {
                cboxCodigoVenta.Items.Add(Venta);
            }

            cboxCodigoVenta.DisplayMember = "Text";
            cboxCodigoVenta.ValueMember = "Value";
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

        private void FormPagoVentas_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboxCodigoVenta.Text) || string.IsNullOrEmpty(txtMonto.Text) || string.IsNullOrEmpty(cboxTipoPago.Text) || string.IsNullOrEmpty(txtNumeroReferencia.Text) || string.IsNullOrEmpty(DtpFechaPago.Text) || string.IsNullOrEmpty(cboxEstado.Text))
            {
                MessageBox.Show("Favor ingresar todos los datos en pantalla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                try
                {
                    int CodigoVenta = int.Parse(cboxCodigoVenta.Text.Split('-')[0].Trim());
                    // Obtenemos el monto calculado para la venta
                    double Monto = 0;
                    if (string.IsNullOrEmpty(txtCodigoPagoVentas.Text))
                    {
                        Monto = 0;
                    }
                    else
                    {
                        Monto = cl_PagoVenta.MtdTotalPagoVenta(int.Parse(txtCodigoPagoVentas.Text));
                    }
                    string TipoPago = cboxTipoPago.Text;
                    string NumeroReferencia = txtNumeroReferencia.Text;
                    DateTime FechaPago = cd_PagoVentas.MtdFechaHoy();
                    string Estado = cboxEstado.Text;

                    cd_PagoVentas.MtdAgregarPagosVentas(CodigoVenta, Monto, TipoPago, NumeroReferencia, FechaPago, Estado);
                    MessageBox.Show("Pago de Venta agregada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultaPagoVentas();
                    MtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void MtdLimpiarCampos()
        {
            cboxCodigoVenta.Text = "";
            txtMonto.Text = "";
            cboxTipoPago.Text = "";
            txtNumeroReferencia.Text = "";
            cboxEstado.Text = "";
        }


    }
}
