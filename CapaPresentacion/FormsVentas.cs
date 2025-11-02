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
    public partial class FormsVentas : Form
    {

        CDVentas cd_Ventas = new CDVentas();
        CLVentas cl_Ventas = new CLVentas();
        public FormsVentas()
        {
            InitializeComponent();
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



        private void FormsVentas_Load(object sender, EventArgs e)
        {
            lblFecha.Text = cd_Ventas.MtdFechaHoy().ToString("d");
            MtdConsultaVentas();
            MtdMostrarListaClientes();
            MtdLimpiarCampos();


            if (string.IsNullOrEmpty(txtTotalVenta.Text))
            {
                txtTotalVenta.Text = 0m.ToString("C2");
            }
            else
            {
                if (int.TryParse(txtCodigoVenta.Text, out int codigoVenta))
                {
                    decimal total = Convert.ToDecimal(cl_Ventas.MtdTotalVenta(codigoVenta));
                    txtTotalVenta.Text = total.ToString("C2");
                }
                else
                {
                    txtTotalVenta.Text = 0m.ToString("C2");
                }
            }
        }

        private void MtdConsultaVentas()
        {
            DataTable dtVentas = cd_Ventas.MtdConsultaVentas();
            dgvSistemaGranjas.DataSource = dtVentas;
        }

        private void MtdMostrarListaClientes()
        {
            var ListaClientes = cd_Ventas.MtdListaClientes();

            foreach (var Cliente in ListaClientes)
            {
                cboxCodigoCliente.Items.Add(Cliente);
            }

            cboxCodigoCliente.DisplayMember = "Text";
            cboxCodigoCliente.ValueMember = "Value";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboxCodigoCliente.Text) || string.IsNullOrEmpty(DtpFechaVenta.Text) || string.IsNullOrEmpty(cboxTipoVenta.Text) || string.IsNullOrEmpty(txtTotalVenta.Text) || string.IsNullOrEmpty(cboxEstado.Text))
            {
                MessageBox.Show("Favor ingresar todos los datos en pantalla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int CodigoCliente = int.Parse(cboxCodigoCliente.Text.Split('-')[0].Trim());
                    DateTime FechaVenta = cd_Ventas.MtdFechaHoy();
                    string TipoVenta = cboxTipoVenta.Text;
                    double TotalVenta = 0;
                    string Estado = cboxEstado.Text;


                    if (string.IsNullOrEmpty(txtCodigoVenta.Text))
                    {
                        TotalVenta = 0;
                    }
                    else
                    {
                        TotalVenta = cl_Ventas.MtdTotalVenta(int.Parse(txtCodigoVenta.Text));
                    }


                    cd_Ventas.MtdAgregarVentas(CodigoCliente, FechaVenta, TipoVenta, TotalVenta, Estado);
                    MessageBox.Show("Venta agregada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultaVentas();
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
            txtCodigoVenta.Text = "";
            cboxCodigoCliente.Text = "";
            cboxTipoVenta.Text = "";
            txtTotalVenta.Text = "";
            cboxEstado.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboxCodigoCliente.Text) || string.IsNullOrEmpty(DtpFechaVenta.Text) || string.IsNullOrEmpty(cboxTipoVenta.Text) || string.IsNullOrEmpty(txtTotalVenta.Text) || string.IsNullOrEmpty(cboxEstado.Text))
            {
                MessageBox.Show("Favor ingresar todos los datos en pantalla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int CodigoVenta = int.Parse(txtCodigoVenta.Text);
                    int CodigoCliente = int.Parse(cboxCodigoCliente.Text.Split('-')[0].Trim());
                    DateTime FechaVenta = cd_Ventas.MtdFechaHoy();
                    string TipoVenta = cboxTipoVenta.Text;
                    double TotalVenta = 0;
                    string Estado = cboxEstado.Text;





                    cd_Ventas.MtdActualizarVentas(CodigoVenta, CodigoCliente, FechaVenta, TipoVenta, TotalVenta, Estado);
                    MessageBox.Show("Venta actualizada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultaVentas();
                    MtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
            MensajeLimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoVenta.Text))
            {
                MessageBox.Show("Favor seleccionar fila a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int CodigoVenta = int.Parse(txtCodigoVenta.Text);

                try
                {
                    cd_Ventas.MtdEliminarVentas(CodigoVenta);
                    MessageBox.Show("Datos eliminados correctamente >.<", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultaVentas();
                    MtdLimpiarCampos();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error x.x ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvSistemaGranjas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var FilaSeleccionada = dgvSistemaGranjas.SelectedRows[0];

            if (FilaSeleccionada.Index == dgvSistemaGranjas.Rows.Count - 1)
            {
                MessageBox.Show("Seleccione una fila con datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtCodigoVenta.Text = dgvSistemaGranjas.SelectedCells[0].Value.ToString();

                int CodigoCliente = (int)dgvSistemaGranjas.SelectedCells[1].Value;
                cboxCodigoCliente.Text = cd_Ventas.MtdListasClientesDgv(CodigoCliente);

                DtpFechaVenta.Text = dgvSistemaGranjas.SelectedCells[2].Value.ToString();

                cboxTipoVenta.Text = dgvSistemaGranjas.SelectedCells[3].Value.ToString();

                if (int.TryParse(txtCodigoVenta.Text, out int codigoVenta))
                {
                    decimal totalVenta = Convert.ToDecimal(cl_Ventas.MtdTotalVenta(codigoVenta));
                    txtTotalVenta.Text = totalVenta.ToString("C2");

                    decimal dgvValor = 0m;
                    try
                    {
                        dgvValor = Convert.ToDecimal(dgvSistemaGranjas.SelectedCells[4].Value);
                    }
                    catch
                    {
                        // Si no se puede convertir, asumir 0
                        dgvValor = 0m;
                    }

                    if (totalVenta != dgvValor)
                    {
                        MessageBox.Show("El monto de la venta, no coincide con el monto de la linea seleccionada, favor actualizar el registro con boton Editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    txtTotalVenta.Text = 0m.ToString("C2");
                }

                cboxEstado.Text = dgvSistemaGranjas.SelectedCells[5].Value.ToString();

            }
        }
    }
}
