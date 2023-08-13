using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Menu : Form
    {
        private IconButton botonActual;
        private Panel bordeIzquiedoBtn;
        private Form formularioHijoActual;
        public Menu()
        {
            
            InitializeComponent();
            bordeIzquiedoBtn = new Panel();
            bordeIzquiedoBtn.Size = new Size(7, 50);
            panelMenu.Controls.Add(bordeIzquiedoBtn);
            

            //Formulario
            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //cargar dato de usuario
            lbUsu.Text = Capa_Negocios.Negocio.NombreUsuario;

           


        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        //metodos
        private void activarBoton(object botonRemitente, Color color)
        {
            if (botonRemitente != null)
            {
               desactivarBoton();
                //Botón
                botonActual = (IconButton)botonRemitente;
                botonActual.BackColor = Color.FromArgb(37, 36, 81);
                botonActual.ForeColor = color;
                botonActual.TextAlign = ContentAlignment.MiddleCenter;
                botonActual.IconColor = color;
                botonActual.TextImageRelation = TextImageRelation.TextBeforeImage;
                botonActual.ImageAlign = ContentAlignment.MiddleRight;


                //Borde izquierdo del botón
                bordeIzquiedoBtn.BackColor = color;
                bordeIzquiedoBtn.Location = new Point(0, botonActual.Location.Y);
                bordeIzquiedoBtn.Visible = true;
                bordeIzquiedoBtn.BringToFront();

                //Icono formulario hijo actual
                //iconoFormularioHijoActual.IconChar = botonActual.IconChar;
                //iconoFormularioHijoActual.IconColor = color;

            }
        }
        private void desactivarBoton()
        {
            if (botonActual != null)
            {
                botonActual.BackColor = Color.FromArgb(31, 30, 68);
                botonActual.ForeColor = Color.FromName("Control");
                botonActual.TextAlign = ContentAlignment.MiddleLeft;
                botonActual.IconColor = Color.FromName("Control");
                botonActual.TextImageRelation = TextImageRelation.ImageBeforeText;
                botonActual.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void abrirFormularioHijo(Form formularioHijo)
        {
            if (formularioHijoActual != null)
            {
                //Abrir solo un formulario
                formularioHijoActual.Close();
            }
            formularioHijoActual = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panelEscritorio.Controls.Add(formularioHijo);
            panelEscritorio.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
            //lbTituloFormularioHijo.Text = formularioHijo.Text;
           // lbTituloFormularioHijo.Text = botonActual.Text;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void panelEscritorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUsu_Click(object sender, EventArgs e)
        {
            activarBoton(sender, RGBColors.color3);
            abrirFormularioHijo(new Usuarios());
        }

       

       

        private void btnInicio_Click(object sender, EventArgs e)
        {
            
            if (formularioHijoActual != null)
            {
                formularioHijoActual.Close();
            }
            reestablecer();
        }
        private void reestablecer()
        {
            desactivarBoton();
            bordeIzquiedoBtn.Visible = false;
           //iconoFormularioHijoActual.IconChar = IconChar.Home;
           //iconoFormularioHijoActual.IconColor = Color.MediumPurple;
           // lbTituloFormularioHijo.Text = "Inicio";
        }
        //Arrastrar formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTituloBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //activarBoton(sender, RGBColors.color3);
            abrirFormularioHijo(new Usuarios());
        }
    }
}
