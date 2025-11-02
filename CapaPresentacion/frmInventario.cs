using System;
using System.Data;
using System.Windows.Forms;
using CapaDatos;
using CapaLogica;

namespace CapaPresentacion {
    public partial class frmInventario:Form {
        private LNInventario logicaInventario = new LNInventario();
        private bool EsNuevo = true;
        private int CodigoInventarioEditar = 0;

        public frmInventario() {
            InitializeComponent();
        }

        private void frmInventario_Load(object sender, EventArgs e) {
            LlenarComboBoxes();
            CargarInventario();
            ConfigurarDGV();
            LimpiarCampos();
            lblFecha.Text = logicaInventario.MtdFechaHoy().ToString("d");
        }



        // ----------------------------------------------------------------------
        // MÉTODOS DE INICIALIZACIÓN Y CONFIGURACIÓN
        // ----------------------------------------------------------------------

        private void LlenarComboBoxes() {
            try {
                // 1. Configuración de Insumo (FK)
                cboInsumo.DisplayMember = "Text";
                cboInsumo.ValueMember = "Value";
                cboInsumo.DataSource = logicaInventario.MtdListaInsumos();
                cboInsumo.SelectedIndex = -1;

                // 2. Configuración de Granja (NUEVA FK)
                cboGranja.DisplayMember = "Text";
                cboGranja.ValueMember = "Value";
                cboGranja.DataSource = logicaInventario.MtdListaGranjas();
                cboGranja.SelectedIndex = -1;
            } catch(Exception ex) {
                MessageBox.Show("Error al cargar ComboBoxes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Llenar ComboBox de Estado (Manual)
            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new string[] { "Disponible", "En Uso", "Agotado" });
            cboEstado.SelectedItem = "Disponible";
        }

        private void CargarInventario() {
            try {
                dgvDatos.DataSource = logicaInventario.MtdConsultaInventario();
                dgvDatos.AutoResizeColumns();
            } catch(Exception ex) {
                MessageBox.Show("Error al cargar los datos de inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDGV() {
            if(dgvDatos.Columns.Contains("CodigoInventario"))
                dgvDatos.Columns["CodigoInventario"].Visible = false;
            if(dgvDatos.Columns.Contains("CodigoInsumo"))
                dgvDatos.Columns["CodigoInsumo"].Visible = false;
            if(dgvDatos.Columns.Contains("CodigoGranja"))
                dgvDatos.Columns["CodigoGranja"].Visible = false;
            if(dgvDatos.Columns.Contains("NombreInsumo"))
                dgvDatos.Columns["NombreInsumo"].HeaderText = "Insumo";
            if(dgvDatos.Columns.Contains("DireccionGranja"))
                dgvDatos.Columns["DireccionGranja"].HeaderText = "Granja";
        }

        private void LimpiarCampos() {
            EsNuevo = true;
            CodigoInventarioEditar = 0;

            // Limpiar TextBoxes NUEVOS Y VIEJOS
            txtNombreProducto.Clear();
            txtTipo.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

            // Restablecer ComboBoxes y DatePickers
            cboInsumo.SelectedIndex = -1;
            cboGranja.SelectedIndex = -1;
            cboEstado.SelectedItem = "Disponible";
            dtpFechaVencimiento.Value = DateTime.Now;
            dtpFechaVencimiento.Value = DateTime.Now.AddMonths(1); // Valor por defecto

            txtNombreProducto.Focus();
        }

        // ----------------------------------------------------------------------
        // MÉTODOS DE EVENTO (BOTONES)
        // ----------------------------------------------------------------------

        private void btnGuardar_Click(object sender, EventArgs e) {
            // --- 1. VALIDACIONES COMUNES ---
            if(cboInsumo.SelectedValue == null || cboGranja.SelectedValue == null || string.IsNullOrWhiteSpace(txtNombreProducto.Text) || string.IsNullOrWhiteSpace(txtTipo.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text) || string.IsNullOrWhiteSpace(txtStock.Text) || cboEstado.SelectedItem == null) {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🚨 Conversión de tipos NUEVA
            if(!decimal.TryParse(txtPrecio.Text, out decimal precio)) {
                MessageBox.Show("El Precio debe ser un número válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!int.TryParse(txtStock.Text, out int stock)) {
                MessageBox.Show("El Stock debe ser un número entero válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 2. PREPARAR PARÁMETROS ---
            int codigoInsumo = Convert.ToInt32(cboInsumo.SelectedValue);
            int codigoGranja = Convert.ToInt32(cboGranja.SelectedValue);
            string nombreProducto = txtNombreProducto.Text;
            string tipo = txtTipo.Text;
            DateTime fechaIngreso = dtpFechaVencimiento.Value;
            DateTime fechaVencimiento = dtpFechaVencimiento.Value;
            string estado = cboEstado.SelectedItem.ToString();

            string resultado = string.Empty;

            if(EsNuevo) {
                // Lógica de GUARDAR (INSERT) - ¡NUEVOS PARÁMETROS!
                resultado = logicaInventario.MtdAgregarInventario(
                    codigoGranja, codigoInsumo, nombreProducto, tipo, precio, stock, fechaIngreso, fechaVencimiento, estado
                );
            } else {
                // Lógica de EDITAR (UPDATE) - ¡NUEVOS PARÁMETROS!
                if(CodigoInventarioEditar == 0) {
                    MessageBox.Show("Error: ID de Inventario no válido para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                resultado = logicaInventario.MtdActualizarInventario(
                    CodigoInventarioEditar, codigoGranja, codigoInsumo, nombreProducto, tipo, precio, stock, fechaIngreso, fechaVencimiento, estado
                );
            }

            // --- 3. MOSTRAR RESULTADO ---
            MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(resultado.Contains("agregado correctamente") || resultado.Contains("actualizado correctamente")) {
                LimpiarCampos();
                CargarInventario();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e) {
            if(dgvDatos.SelectedRows.Count > 0) {
                EsNuevo = false;
                DataGridViewRow row = dgvDatos.SelectedRows[0];

                // Almacenar ID y cargar campos
                CodigoInventarioEditar = Convert.ToInt32(row.Cells["CodigoInventario"].Value);

                txtNombreProducto.Text = row.Cells["NombreProducto"].Value.ToString();
                txtTipo.Text = row.Cells["Tipo"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtStock.Text = row.Cells["Stock"].Value.ToString();

                // Cargar Fechas
                dtpFechaVencimiento.Value = Convert.ToDateTime(row.Cells["FechaIngreso"].Value);
                dtpFechaVencimiento.Value = Convert.ToDateTime(row.Cells["FechaVencimiento"].Value);

                // Cargar ComboBoxes (2 FKs)
                int codigoInsumo = Convert.ToInt32(row.Cells["CodigoInsumo"].Value);
                cboInsumo.SelectedValue = codigoInsumo;

                int codigoGranja = Convert.ToInt32(row.Cells["CodigoGranja"].Value);
                cboGranja.SelectedValue = codigoGranja;

                cboEstado.SelectedItem = row.Cells["Estado"].Value.ToString();

                txtNombreProducto.Focus();
            } else {
                MessageBox.Show("Seleccione una fila para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            if(dgvDatos.SelectedRows.Count > 0) {
                int codigoInventario = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["CodigoInventario"].Value);

                DialogResult confirmacion = MessageBox.Show($"¿Desea eliminar el registro de inventario (ID: {codigoInventario})?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(confirmacion == DialogResult.Yes) {
                    string resultado = logicaInventario.MtdEliminarInventario(codigoInventario);
                    MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarInventario();
                }
            } else {
                MessageBox.Show("Seleccione la fila que desea eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            LimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void dtpFechaIngreso_ValueChanged(object sender, EventArgs e) {

        }
    }
}