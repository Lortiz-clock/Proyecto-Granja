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
    public partial class FormProductos : Form
    {

        CLProductos cl_Productos = new CLProductos();
        CDProductos cd_Productos = new CDProductos();

        public FormProductos()
        {

            InitializeComponent();

            MtdCargarDatos();

            lblFecha.Text = cl_Productos.MtdFecha();

            // Seleccionar el primer tipo para que se rellene el combobox de nombres al abrir
            if (cboxTipoProducto.Items.Count > 0)
                cboxTipoProducto.SelectedIndex = 0;
        }

        private void cboxTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        public void MtdCargarDatos()
        {
            DataTable dtCargarDatos = cd_Productos.MtdConsultaProductos();
            dgvSistemaProductos.DataSource = dtCargarDatos;
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



        private void MtdLimpiarCampos()
        {
            cboxCodigoGranja.Text = "";
            cboxTipoProducto.Text = "";
            cboxNombreProducto.Text = "";
            txtDescripcionProducto.Text = "";
            cboxEstado.Text = "";
        }

        private void cboxNombreProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el tipo seleccionado
            string tipo = cboxNombreProducto.SelectedItem as string;
            cboxTipoProducto.Items.Clear();

            if (string.IsNullOrWhiteSpace(tipo))
                return;

            // Pedir la lista a la capa lógica
            var nombres = cl_Productos.GetNombresPorTipo(tipo);

            if (nombres != null && nombres.Count > 0)
            {
                cboxTipoProducto.Items.AddRange(nombres.ToArray());
                cboxTipoProducto.SelectedIndex = 0;
            }
            else
            {
                cboxTipoProducto.Items.Add("Otros");
                cboxTipoProducto.SelectedIndex = 0;
            }

            // Rellenar descripción en el TextBox txtDescripcionProducto
            // Asegúrate de tener un TextBox llamado txtDescripcionProducto en el diseñador
            if (!string.IsNullOrWhiteSpace(tipo))
            {
                var descripciones = cl_Productos.GetdescripcionPorTipo(tipo);

                if (descripciones != null && descripciones.Count > 0)
                {
                    // Mostrar todas las descripciones separadas por coma
                    txtDescripcionProducto.Text = string.Join(", ", descripciones);
                }
                else
                {
                    txtDescripcionProducto.Text = string.Empty;
                }
            }
            else
            {
                txtDescripcionProducto.Text = string.Empty;
            }

        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigoProducto.Text == "" || cboxCodigoGranja.Text == "" || cboxTipoProducto.Text == "" || cboxNombreProducto.Text == "" || txtDescripcionProducto.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else

                {

                    int CodigoGranja = int.Parse(cboxCodigoGranja.Text.Split('-')[0].Trim());
                    string TipoProducto = cboxTipoProducto.Text;
                    string NombreProducto = cboxNombreProducto.Text;
                    string DescripcionProducto = txtDescripcionProducto.Text;
                    string Estado = cboxEstado.Text;
                    cd_Productos.MtdAgregarProductos(CodigoGranja, TipoProducto, NombreProducto, DescripcionProducto, Estado);
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

        private void dgvSistemaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


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

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtCodigoProducto.Text == "" || cboxCodigoGranja.Text == "" || cboxTipoProducto.Text == "" || cboxNombreProducto.Text == "" || txtDescripcionProducto.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    int CodigoProducto = int.Parse(txtCodigoProducto.Text);
                    cd_Productos.MtdEliminarProducto(CodigoProducto);
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
                if (txtCodigoProducto.Text == "" || cboxCodigoGranja.Text == "" || cboxTipoProducto.Text == "" || cboxNombreProducto.Text == "" || txtDescripcionProducto.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else

                {
                    int CodigoProducto = int.Parse(txtCodigoProducto.Text.Split('-')[0].Trim());
                    int CodigoGranja = int.Parse(cboxCodigoGranja.Text.Split('-')[0].Trim());
                    string TipoProducto = cboxTipoProducto.Text;
                    string NombreProducto = cboxNombreProducto.Text;
                    string DescripcionProducto = txtDescripcionProducto.Text;
                    string Estado = cboxEstado.Text;
                    cd_Productos.MtdActualizarProductos(CodigoProducto, CodigoGranja, TipoProducto, NombreProducto, DescripcionProducto, Estado);
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

        private void dgvSistemaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var FilaSeleccionada = dgvSistemaProductos.SelectedRows[0];
            if (FilaSeleccionada.Index == dgvSistemaProductos.Rows.Count - 1)
            {
                MessageBox.Show("Seleccione una fila con datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtCodigoProducto.Text = dgvSistemaProductos.SelectedCells[0].Value.ToString();
                cboxCodigoGranja.Text = dgvSistemaProductos.SelectedCells[1].Value.ToString();
                cboxTipoProducto.Text = dgvSistemaProductos.SelectedCells[2].Value.ToString();
                cboxNombreProducto.Text = dgvSistemaProductos.SelectedCells[3].Value.ToString();
                txtDescripcionProducto.Text = dgvSistemaProductos.SelectedCells[4].Value.ToString();
                cboxEstado.Text = dgvSistemaProductos.SelectedCells[5].Value.ToString();

            }

        }
    }
}
