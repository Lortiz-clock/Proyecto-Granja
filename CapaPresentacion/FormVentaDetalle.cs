using CapaDatos;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormVentaDetalle : Form
    {
        CdDetalleVenta detalle = new CdDetalleVenta();
        public FormVentaDetalle()
        {
            InitializeComponent();
        }

        private void FormVentaDetalle_Load_1(object sender, EventArgs e)
        {
            lblFech4.Text = detalle.MtdFechaHoy().ToString("d");
            MtdCargarDatos();
        }
        public void MtdCargarDatos()
        {
            DataTable dtCargarDatos = detalle.MtdCargarDatos();
            dgvDetalleVenta.DataSource = dtCargarDatos;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodiVent.Text == "" || txtCodigoAnimal.Text == "" || txtCodigoCultivo.Text == "" || txtCodigoProducto.Text == "" || txtCantidad.Text == "" || txtPrecioUni.Text == "" || textTotal.Text == "" || txtDescu.Text == "" || txtImpd.Text == "" || txtTotVent.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    int CodigoDetalleVenta = int.Parse(txtCodigoRol.Text); //  este campo representa el ID
                    detalle.MtdEliminarDatos(CodigoDetalleVenta);
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


        private void dgvRoll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void txt_Click(object sender, EventArgs e)
        {

        }
        private void MtdLimpiarCampos()
        {
            txtCodigoRol.Text = "";
            txtCodiVent.Text = "";
            txtCodigoAnimal.Text = "";
            txtCodigoCultivo.Text = "";
            txtCodigoProducto.Text = "";
            txtCantidad.Text = "";
            txtPrecioUni.Text = "";
            textTotal.Text = "";
            txtDescu.Text = "";
            txtImpd.Text = "";
            txtTotVent.Text = "";
            cboxEstado.Text = "";
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
        private void dgvDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleVenta.CurrentRow != null)
            {
                DataGridViewRow fila = dgvDetalleVenta.CurrentRow;

                txtCodigoRol.Text = fila.Cells[0].Value.ToString();
                txtCodiVent.Text = fila.Cells[1].Value.ToString();
                txtCodigoAnimal.Text = fila.Cells[2].Value.ToString();
                txtCodigoCultivo.Text = fila.Cells[3].Value.ToString();
                txtCodigoProducto.Text = fila.Cells[4].Value.ToString();
                txtCantidad.Text = fila.Cells[5].Value.ToString();
                txtPrecioUni.Text = fila.Cells[6].Value.ToString();
                textTotal.Text = fila.Cells[7].Value.ToString();
                txtDescu.Text = fila.Cells[8].Value.ToString();
                txtImpd.Text = fila.Cells[9].Value.ToString();
                txtTotVent.Text = fila.Cells[10].Value.ToString();
                cboxEstado.Text = fila.Cells[11].Value.ToString();
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodiVent.Text == "" || txtCodigoAnimal.Text == "" || txtCodigoCultivo.Text == "" || txtCodigoProducto.Text == "" ||
                    txtCantidad.Text == "" || txtPrecioUni.Text == "" || textTotal.Text == "" || txtDescu.Text == "" ||
                    txtImpd.Text == "" || txtTotVent.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    int CodigoVenta = int.Parse(txtCodiVent.Text);
                    int CodigoAnimal = int.Parse(txtCodigoAnimal.Text);
                    int CodigoCultivo = int.Parse(txtCodigoCultivo.Text);
                    int CodigoProducto = int.Parse(txtCodigoProducto.Text);
                    int Cantidad = int.Parse(txtCantidad.Text);
                    decimal PrecioUnitario = decimal.Parse(txtPrecioUni.Text);
                    decimal Total = decimal.Parse(textTotal.Text);
                    decimal Descuento = decimal.Parse(txtDescu.Text);
                    decimal Impuesto = decimal.Parse(txtImpd.Text);
                    decimal TotalVenta = decimal.Parse(txtTotVent.Text);
                    string Estado = cboxEstado.Text;

                    detalle.MtdAgregarDatos(CodigoVenta, CodigoAnimal, CodigoCultivo, CodigoProducto, Cantidad, PrecioUnitario, Total, Descuento, Impuesto, TotalVenta, Estado);
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

        private void textTotal_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

            CalcularTotales();

        }

        private void txtPrecioUni_TextChanged(object sender, EventArgs e)
        {
            CalcularTotales();

        }

        private void CalcularTotales()
        {
            if (decimal.TryParse(txtCantidad.Text, out decimal cantidad) &&
                decimal.TryParse(txtPrecioUni.Text, out decimal precio))
            {
                var logica = new CapaLogica.Class1();

                decimal total = logica.CalcularTotal((int)cantidad, precio);
                decimal impuesto = logica.CalcularImpuesto(total);
                decimal totalVenta = logica.CalcularTotalVenta(total, impuesto);

                textTotal.Text = total.ToString("0.00");
                txtImpd.Text = impuesto.ToString("0.00");
                txtTotVent.Text = totalVenta.ToString("0.00");
                txtDescu.Text = "0.00";
            }
            else
            {
                textTotal.Text = "";
                txtTotVent.Text = "";
                txtDescu.Text = "";
            }

        }

        private void txtTotVent_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtImpd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodiVent.Text == "" || txtCodigoAnimal.Text == "" || txtCodigoCultivo.Text == "" || txtCodigoProducto.Text == "" ||
                    txtCantidad.Text == "" || txtPrecioUni.Text == "" || textTotal.Text == "" || txtDescu.Text == "" ||
                    txtImpd.Text == "" || txtTotVent.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    // La llave primaria NO se modifica, solo se usa para identificar el registro
                    int CodigoDetalleVenta = int.Parse(txtCodigoRol.Text); // ← ID que no debe cambiar
                    int CodigoVenta = int.Parse(txtCodiVent.Text);
                    int CodigoAnimal = int.Parse(txtCodigoAnimal.Text);
                    int CodigoCultivo = int.Parse(txtCodigoCultivo.Text);
                    int CodigoProducto = int.Parse(txtCodigoProducto.Text);
                    int Cantidad = int.Parse(txtCantidad.Text);
                    decimal PrecioUnitario = decimal.Parse(txtPrecioUni.Text);
                    decimal Total = decimal.Parse(textTotal.Text);
                    decimal Descuento = decimal.Parse(txtDescu.Text);
                    decimal Impuesto = decimal.Parse(txtImpd.Text);
                    decimal TotalVenta = decimal.Parse(txtTotVent.Text);
                    string Estado = cboxEstado.Text;

                    // Llamada al método UPDATE
                    detalle.MtdEditarDatos(
                        CodigoDetalleVenta,
                        CodigoVenta,
                        CodigoAnimal,
                        CodigoCultivo,
                        CodigoProducto,
                        Cantidad,
                        PrecioUnitario,
                        Total,
                        Descuento,
                        Impuesto,
                        TotalVenta,
                        Estado
                    );

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
