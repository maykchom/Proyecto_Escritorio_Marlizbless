using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var login = Capa_Negocios.Negocio.Login(txtUser.Text, PasswordtextBox.Text);
            if (login == false)
                MessageBox.Show("CREDENCIALES INVALIDAD,ERROR");
            else
            {
                //MessageBox.Show("Bievenido,Entrando");
                this.Hide();
                Menu prin = new Menu();
               
                //prin.Size= new Size (1500,800);
                prin.Show();
               
                //prin.StartPosition = FormStartPosition.CenterParent;
               // prin.WindowState= FormWindowState.Normal;
                

            }

        }
       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string text = PasswordtextBox.Text;
            if (checkBox1.Checked)
            {
                PasswordtextBox.UseSystemPasswordChar = false;
                PasswordtextBox.Text = text;

            }
            else
            {
                PasswordtextBox.UseSystemPasswordChar = true;
                PasswordtextBox.Text = text;
            }
        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            string text = PasswordtextBox.Text;
            if (checkBox1.Checked)
            {
                PasswordtextBox.UseSystemPasswordChar = false;
                PasswordtextBox.Text = text;

            }
            else
            {
                PasswordtextBox.UseSystemPasswordChar = true;
                PasswordtextBox.Text = text;
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
