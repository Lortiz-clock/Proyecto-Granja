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
using CapaPresentacion;

namespace CapaPresentacion
{
    public partial class FormAnimales : Form
    {
        CDAnimales CdAnimales = new CDAnimales();

        public FormAnimales()
        {
            InitializeComponent();
        }

        private void FormAnimales_Load(object sender, EventArgs e)
        {
            MtdCargarDatos();
            lblFecha.Text = CdAnimales.MtdFechaHoy().ToString("d");
        }

        public void MtdCargarDatos()
        {
            DataTable dtCargarDatos = CdAnimales.MtdCargarDatos();
            dgvAnimales.DataSource = dtCargarDatos;
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

        public void MtdLimpiarCampos()
        {
            txtCodigoAnimal.Text = "";
            cboxCodigoGranja.Text = "";
            txtTipoAnimal.Text = "";
            txtRaza.Text = "";
            FechaNacimiento.Text = DateTime.Now.ToString("d");
            txtPrecio.Text = "";
            txtDescripcion.Text = "";
            cboxEstado.Text = "";
        }

        private void dgvAnimales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoAnimal.Text = dgvAnimales.CurrentRow.Cells[0].Value.ToString();
            cboxCodigoGranja.Text = dgvAnimales.CurrentRow.Cells[1].Value.ToString();
            txtTipoAnimal.Text = dgvAnimales.CurrentRow.Cells[2].Value.ToString();
            txtRaza.Text = dgvAnimales.CurrentRow.Cells[3].Value.ToString();
            FechaNacimiento.Text = dgvAnimales.CurrentRow.Cells[4].Value.ToString();
            txtPrecio.Text = dgvAnimales.CurrentRow.Cells[5].Value.ToString();
            txtDescripcion.Text = dgvAnimales.CurrentRow.Cells[6].Value.ToString();
            cboxEstado.Text = dgvAnimales.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigoAnimal.Text == "" || txtTipoAnimal.Text == "" || txtRaza.Text == "" || FechaNacimiento.Text == "" || txtPrecio.Text == "" || txtDescripcion.Text == "" || cboxEstado.Text == "")

                {
                    MensajeCamposVacios();
                }

                else
                {
                    int CodigoAnimal = int.Parse(txtCodigoAnimal.Text);
                    CdAnimales.MtdEliminarDatos(CodigoAnimal);
                    MtdLimpiarCampos();
                    MtdCargarDatos();
                    MensajeAccionEjecutada();
                }
            }
            catch (Exception)
            {

                MtdLimpiarCampos();
                MtdCargarDatos();
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

        private void btnGuard_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTipoAnimal.Text == "" || txtRaza.Text == "" || FechaNacimiento.Text == "" || txtPrecio.Text == "" || txtDescripcion.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    string TipoAnimal = txtTipoAnimal.Text;
                    string Raza = txtRaza.Text;
                    DateTime FechaNac = DateTime.Parse(FechaNacimiento.Text);
                    double Precio = double.Parse(txtPrecio.Text);
                    string Descripcion = txtDescripcion.Text;
                    string Estado = cboxEstado.Text;
                    CdAnimales.MtdAgregarDatos(TipoAnimal, Raza, FechaNac, Precio, Descripcion, Estado);
                    MtdLimpiarCampos();
                    MtdCargarDatos();
                    MensajeAccionEjecutada();
                }
            }
            catch (Exception)
            {

                MtdLimpiarCampos();
                MtdCargarDatos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigoAnimal.Text == "" || txtTipoAnimal.Text == "" || txtRaza.Text == "" || FechaNacimiento.Text == "" || txtPrecio.Text == "" || txtDescripcion.Text == "" || cboxEstado.Text == "")
                {
                    MensajeCamposVacios();
                }
                else
                {
                    int CodigoAnimal = int.Parse(txtCodigoAnimal.Text);
                    string TipoAnimal = txtTipoAnimal.Text;
                    string Raza = txtRaza.Text;
                    DateTime FechaNacimient = DateTime.Parse(FechaNacimiento.Text);
                    double Precio = double.Parse(txtPrecio.Text);
                    string Descripcion = txtDescripcion.Text;
                    string Estado = cboxEstado.Text;
                    CdAnimales.MtdEditarDatos(CodigoAnimal, TipoAnimal, Raza, FechaNacimient, Precio, Descripcion, Estado);
                    MtdLimpiarCampos();
                    MtdCargarDatos();
                    MensajeAccionEjecutada();
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
