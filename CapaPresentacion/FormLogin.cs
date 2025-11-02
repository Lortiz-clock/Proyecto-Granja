using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaDatos;


namespace CapaSeguridad
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);




              private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO") {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "") { 
             txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPast_Enter(object sender, EventArgs e)
        {
            if (txtPast.Text == "CONTRASEÑA")
            {
                txtPast.Text = "";
                txtPast.ForeColor = Color.LightGray;
                txtPast.UseSystemPasswordChar = true;
            }
        }

        private void FormLogin_Leave(object sender, EventArgs e)
        {
            if (txtPast.Text == "")
            {
                txtPast.Text = "CONTRASEÑA";
                txtPast.ForeColor = Color.DimGray;
                txtPast.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            string usuario = txtUser.Text;
            string clave = txtPast.Text;


        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
