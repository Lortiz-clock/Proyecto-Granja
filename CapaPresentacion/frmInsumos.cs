using System;
using System.Drawing;
using System.Windows.Forms;
using CapaLogica;
using System.Data;
using System.Collections.Generic;


namespace CapaPresentacion {
    public partial class frmInsumos:Form {
        private LNInsumos logicaInsumos = new LNInsumos();
        private bool EsNuevo = true;
        private int CodigoInsumoEditar = 0;

        public frmInsumos() {
            InitializeComponent();
        }

        private void frmInsumos_Load(object sender, EventArgs e) {
            LlenarComboBoxes();
            CargarInsumos();
            ConfigurarDGV();
            lblFecha.Text = logicaInsumos.MtdFechaHoy().ToString("d");
        }

        private void LlenarComboBoxes() {
            // 1. Llenar ComboBox de Proveedores (Usando List<dynamic> de la Capa Datos)
            try {
                cboProveedor.DisplayMember = "Text"; // Mostrar (Código - Nombre)
                cboProveedor.ValueMember = "Value"; // Valor real (CodigoProveedor)
                cboProveedor.DataSource = logicaInsumos.MtdListaProveedores();
                cboProveedor.SelectedIndex = -1;
            } catch(Exception ex) {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 2. Llenar ComboBox de Tipo Insumo
            cboTipoInsumo.Items.Clear();
            cboTipoInsumo.Items.AddRange(new string[] { "Fertilizante", "Semilla", "Pesticida", "Alimento", "Medicamento", "Otro" });
            cboTipoInsumo.SelectedIndex = -1;
            cboTipoInsumo.Text = string.Empty;

            // 3. Llenar ComboBox de Unidad Medida
            cboUnidadMedida.Items.Clear();
            cboUnidadMedida.Items.AddRange(new string[] { "Kg", "Lt", "Gramo", "Mililitro", "Unidad" });
            cboUnidadMedida.SelectedIndex = -1;
            cboUnidadMedida.Text = string.Empty;

            // 4. Llenar ComboBox de Estado
            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new string[] { "Activo", "Inactivo" });
            cboEstado.SelectedItem = "Activo";
        }

        private void CargarInsumos() {
            // Obtiene los datos de la Capa Lógica y los asigna al DataGridView
            try {
                dgvDatos.DataSource = logicaInsumos.MtdConsultaInsumos();
                // Ajustar el tamaño de las columnas
                dgvDatos.AutoResizeColumns();
            } catch(Exception ex) {
                MessageBox.Show("Error al cargar los datos de insumos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDGV() {
            // Ocultar la columna de la clave primaria (si existe) o la de llaves foráneas que no interesan
            if(dgvDatos.Columns.Contains("CodigoInsumo"))
                dgvDatos.Columns["CodigoInsumo"].Visible = false;

            if(dgvDatos.Columns.Contains("CodigoProveedor"))
                dgvDatos.Columns["CodigoProveedor"].Visible = false;

            // Renombrar la columna del proveedor para claridad, ya que el código lo tiene la FK
            if(dgvDatos.Columns.Contains("NombreProveedor"))
                dgvDatos.Columns["NombreProveedor"].HeaderText = "Proveedor";
        }

        private void LimpiarCampos() {
            // Restablecer el estado de la aplicación
            EsNuevo = true;

            // Limpiar TextBoxes
            txtNombreInsumo.Clear();
            txtCostoUnitario.Clear();
            txtPeso.Clear();
            txtObservacion.Clear();

            // Restablecer ComboBoxes
            cboProveedor.SelectedIndex = -1;
            cboTipoInsumo.SelectedIndex = -1;
            cboUnidadMedida.SelectedIndex = -1;
            cboEstado.SelectedItem = "Activo";

            // Enfocar al primer campo
            txtNombreInsumo.Focus();
        }

        // ----------------------------------------------------------------------
        // MÉTODOS DE EVENTO (BOTONES)
        // ----------------------------------------------------------------------

        private void btnGuardar_Click(object sender, EventArgs e) {
            if(cboProveedor.SelectedValue == null || string.IsNullOrWhiteSpace(txtNombreInsumo.Text) || cboTipoInsumo.SelectedItem == null || string.IsNullOrWhiteSpace(txtCostoUnitario.Text) || cboUnidadMedida.SelectedItem == null || cboEstado.SelectedItem == null) {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!decimal.TryParse(txtCostoUnitario.Text, out decimal costoUnitario) || !decimal.TryParse(txtPeso.Text, out decimal peso)) {
                MessageBox.Show("El Costo Unitario y el Peso deben ser números válidos.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int codigoProveedor = Convert.ToInt32(cboProveedor.SelectedValue);
            string nombreInsumo = txtNombreInsumo.Text;
            string tipoInsumo = cboTipoInsumo.SelectedItem.ToString();
            string unidadMedida = cboUnidadMedida.SelectedItem.ToString();
            string observacion = txtObservacion.Text;
            string estado = cboEstado.SelectedItem.ToString();

            string resultado = string.Empty;

            if(EsNuevo) {
                resultado = logicaInsumos.MtdAgregarInsumo(
                    codigoProveedor, nombreInsumo, tipoInsumo, costoUnitario, unidadMedida, peso, observacion, estado
                );
            } else {
                if(CodigoInsumoEditar == 0) {
                    MessageBox.Show("Error: No se ha seleccionado un registro válido para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                resultado = logicaInsumos.MtdActualizarInsumo(
                    CodigoInsumoEditar, codigoProveedor, nombreInsumo, tipoInsumo, costoUnitario, unidadMedida, peso, observacion, estado
                );
            }

            MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(resultado.Contains("agregado correctamente") || resultado.Contains("actualizado correctamente")) {
                LimpiarCampos();
                CargarInsumos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e) {
            if(dgvDatos.SelectedRows.Count > 0) {
                EsNuevo = false;

                DataGridViewRow row = dgvDatos.SelectedRows[0];

                CodigoInsumoEditar = Convert.ToInt32(row.Cells["CodigoInsumo"].Value);
                txtCodigoVenta.Text = CodigoInsumoEditar.ToString();
                txtNombreInsumo.Text = row.Cells["NombreInsumo"].Value.ToString();
                txtCostoUnitario.Text = row.Cells["CostoUnitario"].Value.ToString();
                txtPeso.Text = row.Cells["Peso"].Value.ToString();
                txtObservacion.Text = row.Cells["Observacion"].Value.ToString();

                int codigoProveedor = Convert.ToInt32(row.Cells["CodigoProveedor"].Value);
                cboProveedor.SelectedValue = codigoProveedor;

                cboTipoInsumo.SelectedItem = row.Cells["TipoInsumo"].Value.ToString();
                cboUnidadMedida.SelectedItem = row.Cells["UnidadMedida"].Value.ToString();
                cboEstado.SelectedItem = row.Cells["Estado"].Value.ToString();
            } else {
                MessageBox.Show("Seleccione una fila para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            if(dgvDatos.SelectedRows.Count > 0) {
                // 1. Obtener el CodigoInsumo de la fila seleccionada
                int codigoInsumo = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["CodigoInsumo"].Value);
                string nombreInsumo = dgvDatos.SelectedRows[0].Cells["NombreInsumo"].Value.ToString();

                // 2. Pedir confirmación
                DialogResult confirmacion = MessageBox.Show($"¿Está seguro de que desea eliminar el insumo: {nombreInsumo}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(confirmacion == DialogResult.Yes) {
                    // 3. Llamar a la Capa Lógica
                    string resultado = logicaInsumos.MtdEliminarInsumo(codigoInsumo);

                    // 4. Mostrar resultado y actualizar DGV
                    MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarInsumos();
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
    }
}