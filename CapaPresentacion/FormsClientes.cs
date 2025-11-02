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
    public partial class FormsClientes : Form
    {
        CDClientes cd_Clientes = new CDClientes();
        public FormsClientes()
        {
            InitializeComponent();
            lblFecha.Text = cd_Clientes.MtdFechaHoy().ToString("d");
            MtdMostrarListaClientes();
            MtdCargarDatos();
            MtdLimpiarCampos();
        }


        private void MtdLimpiarCampos()
        {
            txtCodigoCliente.Text = "";
            CboxNombreCliente.Text = "";
            cboxTipoCliente.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            cboxEstado.Text = "";
        }
        public void MtdCargarDatos()
        {
            DataTable dtCargarDatos = cd_Clientes.MtdCargarDatos();
            dgvClientesGranja.DataSource = dtCargarDatos;
        }

        private void MtdMostrarListaClientes()
        {
            var ListaClientes = cd_Clientes.MtdListaClientes();

            foreach (var Cliente in ListaClientes)
            {
                CboxNombreCliente.Items.Add(Cliente);
            }

            CboxNombreCliente.DisplayMember = "Text";
            CboxNombreCliente.ValueMember = "Value";
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


        private void FormsClientes_Load(object sender, EventArgs e)
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
                if (txtCodigoCliente.Text == "" || CboxNombreCliente.Text == "" || cboxTipoCliente.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtDireccion.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    int CodigoCliente = int.Parse(txtCodigoCliente.Text);
                    cd_Clientes.MtdEliminarDatos(CodigoCliente);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CboxNombreCliente.Text == "" || cboxTipoCliente.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtDireccion.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else

                {
                    string NombreCliente = CboxNombreCliente.Text;
                    string TipoCliente = cboxTipoCliente.Text;
                    string Telefono = txtTelefono.Text;
                    string Correo = txtCorreo.Text;
                    string Direccion = txtDireccion.Text;
                    string Estado = cboxEstado.Text;
                    cd_Clientes.MtdAgregarDatos(NombreCliente, TipoCliente, Telefono, Correo, Direccion, Estado);
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
                if (CboxNombreCliente.Text == "" || cboxTipoCliente.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtDireccion.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else

                {
                    int CodigoCliente = int.Parse(txtCodigoCliente.Text);
                    string NombreCliente = CboxNombreCliente.Text;
                    string TipoCliente = cboxTipoCliente.Text;
                    string Telefono = txtTelefono.Text;
                    string Correo = txtCorreo.Text;
                    string Direccion = txtDireccion.Text;
                    string Estado = cboxEstado.Text;
                    cd_Clientes.MtdEditarDatos(CodigoCliente, NombreCliente, TipoCliente, Telefono, Correo, Direccion, Estado);
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

        private void dgvClientesGranja_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var FilaSeleccionada = dgvClientesGranja.SelectedRows[0];
            if (FilaSeleccionada.Index == dgvClientesGranja.Rows.Count - 1)
            {
                MessageBox.Show("Seleccione una fila con datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtCodigoCliente.Text = dgvClientesGranja.SelectedCells[0].Value.ToString();
                CboxNombreCliente.Text = dgvClientesGranja.SelectedCells[1].Value.ToString();
                cboxTipoCliente.Text = dgvClientesGranja.SelectedCells[2].Value.ToString();
                txtTelefono.Text = dgvClientesGranja.SelectedCells[3].Value.ToString();
                txtCorreo.Text = dgvClientesGranja.SelectedCells[4].Value.ToString();
                txtDireccion.Text = dgvClientesGranja.SelectedCells[5].Value.ToString();
                cboxEstado.Text = dgvClientesGranja.SelectedCells[6].Value.ToString();

            }
        }
    }
}
