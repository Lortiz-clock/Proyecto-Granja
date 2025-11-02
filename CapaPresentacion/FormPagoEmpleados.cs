using CapaDatos;
using CapaLogica;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{

    public partial class FormPagoEmpleados : Form
    {
        CdPagoEmpleados pagoEmpleados = new CdPagoEmpleados();
        Class1 Class1 = new Class1();
        public FormPagoEmpleados()
        {
            InitializeComponent();
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void FormPagoEmpleados_Load(object sender, EventArgs e)
        {
            lblFecha.Text = pagoEmpleados.MtdFechaHoy().ToString("d");
            CargarComboEmpleados();
            MtdCargarPagos();
        }


        private void MtdLimpiarCampos()
        {
            txtCodigoPagoEmpleado.Clear();
            txtSalarioBase.Clear();
            txtHorasExtra.Clear();
            txtBonos.Clear();
            txtDescuentos.Clear();
            txtSalarioFinal.Clear();
            cboxEmpleado.SelectedIndex = -1;
            cboxEstado.SelectedIndex = -1;
            dtpFechaPago.Value = DateTime.Now;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void cboxEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxEmpleado.SelectedIndex != -1 && cboxEmpleado.SelectedValue != null)
            {

            }
        }


        private void CargarComboEmpleados()
        {
            CdPagoEmpleados pagoEmpleados = new CdPagoEmpleados();
            cboxEmpleado.DataSource = pagoEmpleados.MtdObtenerEmpleados();
            cboxEmpleado.DisplayMember = "NombreCompleto"; // ← columna concatenada
            cboxEmpleado.ValueMember = "CodigoEmpleado";   // ← lo que se recupera
            cboxEmpleado.SelectedIndex = -1;
        }

        private void txtCodigoEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void MtdCargarPagos()
        {
            CdPagoEmpleados pagoEmpleados = new CdPagoEmpleados();
            dgvPagos.DataSource = pagoEmpleados.MtdMostrarPagos();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                decimal salarioBase = decimal.Parse(txtSalarioBase.Text);
                decimal bonos = decimal.Parse(txtBonos.Text);
                decimal descuentos = decimal.Parse(txtDescuentos.Text);

                Class1 logica = new Class1();
                decimal salarioFinal = logica.CalcularSalarioFinal(salarioBase, bonos, descuentos);

                txtSalarioFinal.Text = salarioFinal.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular salario: " + ex.Message);
            }

        }

        private void dgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigoPagoEmpleado.Text = dgvPagos.CurrentRow.Cells[0].Value.ToString();
                cboxEmpleado.Text = dgvPagos.CurrentRow.Cells[1].Value.ToString();
                txtSalarioBase.Text = dgvPagos.CurrentRow.Cells[2].Value.ToString();
                txtHorasExtra.Text = dgvPagos.CurrentRow.Cells[3].Value.ToString();
                txtBonos.Text = dgvPagos.CurrentRow.Cells[4].Value.ToString();
                txtDescuentos.Text = dgvPagos.CurrentRow.Cells[5].Value.ToString();
                txtSalarioFinal.Text = dgvPagos.CurrentRow.Cells[6].Value.ToString();
                dtpFechaPago.Text = Convert.ToDateTime(dgvPagos.CurrentRow.Cells[7].Value).ToString("yyyy-MM-dd");
                cboxEstado.Text = dgvPagos.CurrentRow.Cells[8].Value.ToString();
            }

        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación básica
                if (cboxEmpleado.SelectedIndex == -1 || txtSalarioBase.Text == "" || txtHorasExtra.Text == "" ||
                    txtBonos.Text == "" || txtDescuentos.Text == "" || cboxEstado.Text == "")
                {
                    MessageBox.Show("Por favor completa todos los campos obligatorios.");
                    return;
                }

                // Conversión de valores
                int codigoEmpleado = Convert.ToInt32(cboxEmpleado.SelectedValue);
                decimal salarioBase = decimal.Parse(txtSalarioBase.Text);
                int horasExtra = int.Parse(txtHorasExtra.Text); // solo se guarda
                decimal bonos = decimal.Parse(txtBonos.Text);
                decimal descuentos = decimal.Parse(txtDescuentos.Text);
                string estado = cboxEstado.Text;
                DateTime fechaPago = dtpFechaPago.Value;

                // Cálculo del salario final (sin horas extra)
                decimal salarioFinal = salarioBase + bonos - descuentos;

                // Guardar en base de datos
                CdPagoEmpleados pagoEmpleados = new CdPagoEmpleados();
                pagoEmpleados.MtdAgregarDatos(codigoEmpleado, salarioBase, horasExtra, bonos, descuentos, salarioFinal, fechaPago, estado);

                MessageBox.Show("Pago registrado correctamente.");
                MtdLimpiarCampos();
                MtdCargarPagos(); // Refresca el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el pago: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación básica
                if (txtCodigoPagoEmpleado.Text == "" || cboxEmpleado.SelectedIndex == -1 ||
                    txtSalarioBase.Text == "" || txtHorasExtra.Text == "" ||
                    txtBonos.Text == "" || txtDescuentos.Text == "" || cboxEstado.Text == "")
                {
                    MessageBox.Show("Por favor selecciona un registro y completa todos los campos.");
                    return;
                }

                // Conversión de valores
                int codigoPagoEmpleado = int.Parse(txtCodigoPagoEmpleado.Text);
                int codigoEmpleado = Convert.ToInt32(cboxEmpleado.SelectedValue);
                decimal salarioBase = decimal.Parse(txtSalarioBase.Text);
                int horasExtra = int.Parse(txtHorasExtra.Text); // solo se guarda
                decimal bonos = decimal.Parse(txtBonos.Text);
                decimal descuentos = decimal.Parse(txtDescuentos.Text);
                string estado = cboxEstado.Text;
                DateTime fechaPago = dtpFechaPago.Value;

                // Cálculo del salario final (sin horas extra)
                decimal salarioFinal = salarioBase + bonos - descuentos;

                // Actualizar en base de datos
                CdPagoEmpleados pagoEmpleados = new CdPagoEmpleados();
                pagoEmpleados.MtdEditarDatos(codigoPagoEmpleado, codigoEmpleado, salarioBase, horasExtra, bonos, descuentos, salarioFinal, fechaPago, estado);

                MessageBox.Show("Pago actualizado correctamente.");
                MtdLimpiarCampos();
                MtdCargarPagos(); // Refresca el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el pago: " + ex.Message);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtCodigoPagoEmpleado.Text == "")
                {
                    MessageBox.Show("Por favor selecciona un registro para eliminar.");
                    return;
                }

                int codigoPagoEmpleado = int.Parse(txtCodigoPagoEmpleado.Text);

                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este pago?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    CdPagoEmpleados obj = new CdPagoEmpleados();
                    obj.MtdEliminarDatos(codigoPagoEmpleado);

                    MessageBox.Show("Pago eliminado correctamente.");
                    MtdLimpiarCampos();
                    MtdCargarPagos(); // Refresca el DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el pago: " + ex.Message);
            }

        }
    }
}


