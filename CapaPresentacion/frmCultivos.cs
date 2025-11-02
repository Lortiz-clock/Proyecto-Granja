using System;
using System.Windows.Forms;
using CapaLogica;
using System.Data;

namespace CapaPresentacion {
    public partial class frmCultivos:Form {
        private LNCultivos logicaCultivos = new LNCultivos();
        private bool EsNuevo = true;
        private int CodigoCultivoEditar = 0;

        public frmCultivos() {
            InitializeComponent();
        }

        private void frmCultivos_Load(object sender, EventArgs e) {
            LlenarComboBoxes();
            CargarCultivos();
            ConfigurarDGV();
            LimpiarCampos();
            lblFecha.Text = logicaCultivos.MtdFechaHoy().ToString("d");
        }

        // ----------------------------------------------------------------------
        // MÉTODOS DE INICIALIZACIÓN Y CONFIGURACIÓN
        // ----------------------------------------------------------------------

        private void LlenarComboBoxes() {
            try {
                cboGranja.DisplayMember = "Text";
                cboGranja.ValueMember = "Value";
                cboGranja.DataSource = logicaCultivos.MtdListaGranjas();
                cboGranja.SelectedIndex = -1;
            } catch(Exception ex) {
                MessageBox.Show("Error al cargar granjas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Llenar ComboBox de Estado (Manual)
            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new string[] { "Activa", "Inactiva", "Cosechado" });
            cboEstado.SelectedItem = "Activa";
        }

        private void CargarCultivos() {
            try {
                dgvDatos.DataSource = logicaCultivos.MtdConsultaCultivos();
                dgvDatos.AutoResizeColumns();
            } catch(Exception ex) {
                MessageBox.Show("Error al cargar los datos de cultivos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDGV() {
            if(dgvDatos.Columns.Contains("CodigoCultivo"))
                dgvDatos.Columns["CodigoCultivo"].Visible = false;
            if(dgvDatos.Columns.Contains("CodigoGranja"))
                dgvDatos.Columns["CodigoGranja"].Visible = false;
            if(dgvDatos.Columns.Contains("DireccionGranja"))
                dgvDatos.Columns["DireccionGranja"].HeaderText = "Granja";
        }

        private void LimpiarCampos() {
            EsNuevo = true;
            CodigoCultivoEditar = 0;

            // Limpiar TextBoxes
            txtTipoCultivo.Clear();
            txtCantidadCosecha.Clear();
            txtPrecio.Clear();
            txtUbicacion.Clear();
            txtObservacion.Clear();

            // Restablecer ComboBoxes y DatePickers
            cboGranja.SelectedIndex = -1;
            cboEstado.SelectedItem = "Activo";
            dtpFechaSiembra.Value = DateTime.Now;
            dtpFechaCosecha.Value = DateTime.Now;

            txtTipoCultivo.Focus();
        }

        // ----------------------------------------------------------------------
        // MÉTODOS DE EVENTO (BOTONES)
        // ----------------------------------------------------------------------

        private void btnGuardar_Click(object sender, EventArgs e) {
            // --- 1. VALIDACIONES COMUNES ---
            if(cboGranja.SelectedValue == null || string.IsNullOrWhiteSpace(txtTipoCultivo.Text) || string.IsNullOrWhiteSpace(txtCantidadCosecha.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text) || string.IsNullOrWhiteSpace(txtUbicacion.Text) || cboEstado.SelectedItem == null) {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!decimal.TryParse(txtCantidadCosecha.Text, out decimal cantidadCosecha) || !decimal.TryParse(txtPrecio.Text, out decimal precio)) {
                MessageBox.Show("Cantidad Cosecha y Precio deben ser números válidos.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 2. PREPARAR PARÁMETROS ---
            int codigoGranja = Convert.ToInt32(cboGranja.SelectedValue);
            string tipoCultivo = txtTipoCultivo.Text;
            DateTime fechaSiembra = dtpFechaSiembra.Value;
            DateTime fechaCosecha = dtpFechaCosecha.Value;
            string ubicacion = txtUbicacion.Text;
            string observacion = txtObservacion.Text;
            string estado = cboEstado.SelectedItem.ToString();

            string resultado = string.Empty;

            if(EsNuevo) {
                // Lógica de GUARDAR (INSERT)
                resultado = logicaCultivos.MtdAgregarCultivo(
                    codigoGranja, tipoCultivo, fechaSiembra, fechaCosecha, cantidadCosecha, precio, ubicacion, observacion, estado
                );
            } else {
                // Lógica de EDITAR (UPDATE)
                if(CodigoCultivoEditar == 0) {
                    MessageBox.Show("Error: ID de Cultivo no válido para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                resultado = logicaCultivos.MtdActualizarCultivo(
                    CodigoCultivoEditar, codigoGranja, tipoCultivo, fechaSiembra, fechaCosecha, cantidadCosecha, precio, ubicacion, observacion, estado
                );
            }

            // --- 3. MOSTRAR RESULTADO ---
            MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(resultado.StartsWith("Cultivo agregado") || resultado.StartsWith("Cultivo actualizado")) {
                LimpiarCampos();
                CargarCultivos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e) {
            if(dgvDatos.SelectedRows.Count > 0) {
                EsNuevo = false;
                DataGridViewRow row = dgvDatos.SelectedRows[0];

                // Almacenar ID y cargar campos
                CodigoCultivoEditar = Convert.ToInt32(row.Cells["CodigoCultivo"].Value);
                txtTipoCultivo.Text = row.Cells["TipoCultivo"].Value.ToString();
                txtCantidadCosecha.Text = row.Cells["CantidadCosecha"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtUbicacion.Text = row.Cells["Ubicacion"].Value.ToString();
                txtObservacion.Text = row.Cells["Observacion"].Value.ToString();

                // Cargar Fechas
                dtpFechaSiembra.Value = Convert.ToDateTime(row.Cells["FechaSiembra"].Value);
                dtpFechaCosecha.Value = Convert.ToDateTime(row.Cells["FechaCosecha"].Value);

                // Cargar ComboBoxes
                int codigoGranja = Convert.ToInt32(row.Cells["CodigoGranja"].Value);
                cboGranja.SelectedValue = codigoGranja;
                cboEstado.SelectedItem = row.Cells["Estado"].Value.ToString();

                txtTipoCultivo.Focus();
            } else {
                MessageBox.Show("Seleccione una fila para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            if(dgvDatos.SelectedRows.Count > 0) {
                int codigoCultivo = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["CodigoCultivo"].Value);
                string tipoCultivo = dgvDatos.SelectedRows[0].Cells["TipoCultivo"].Value.ToString();

                DialogResult confirmacion = MessageBox.Show($"¿Desea eliminar el cultivo: {tipoCultivo}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(confirmacion == DialogResult.Yes) {
                    string resultado = logicaCultivos.MtdEliminarCultivo(codigoCultivo);
                    MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCultivos();
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

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }
    }
}