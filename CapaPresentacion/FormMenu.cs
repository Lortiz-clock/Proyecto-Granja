using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            FormRoles formRoles = new FormRoles();
            formRoles.Show();
        }

        private void iconButton14_Click(object sender, EventArgs e)
        {
            //
        }

        private void iconButton15_Click(object sender, EventArgs e)
        {
            FormGranja formGranja = new FormGranja();
            formGranja.Show();
        }

        private void iconButton16_Click(object sender, EventArgs e)
        {
            FormEmpleados formEmpleados = new FormEmpleados();
            formEmpleados.Show();
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            //
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            FormVentaDetalle formVentaDetalle = new FormVentaDetalle();
            formVentaDetalle.Show();
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            Form1 formproveedores = new Form1();
            formproveedores.Show();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            FormPagoEmpleados formPagoEmpleados = new FormPagoEmpleados();
            formPagoEmpleados.Show();
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            //
        }

        private void iconButton13_Click(object sender, EventArgs e)
        {
            //
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            //Forms
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            FormProductos formProductos = new FormProductos();
            formProductos.Show();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            FormEnvios formEnvios = new FormEnvios();
            formEnvios.Show();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            FormPagoVentas formPagoVentas = new FormPagoVentas();
            formPagoVentas.Show();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            FormsVentas formsventas = new FormsVentas();
            formsventas.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            FormsClientes formClientes = new FormsClientes();
            formClientes.Show();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
