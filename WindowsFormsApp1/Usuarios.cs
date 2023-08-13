using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Usuarios : Form
    {
        private DataTable dtLista;
        bool imagenLista = false;
        string Nombre;
        public Usuarios()
        {
            InitializeComponent();
            CargarUsuarios();
            DataTable dt = new DataTable();
            dt.Clear();
            dt = Capa_Negocios.Negocio.consulta("Estado");
            comboBox1.DisplayMember = "Estado";
            comboBox1.ValueMember = "idEstado";
            comboBox1.DataSource = dt;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }
        private void Limpiar()
        {
            Image nothing = null;
            pictureBox1.Image = nothing;
            comboBox1.SelectedIndex = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }
        private void CargarUsuarios()
        {
            string texto = "usuarios";
            dgUsuarios.DataSource = Capa_Negocios.Negocio.consulta(texto);
            dgUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Codigo mike
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                Nombre = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    imagenLista = true;
                }
                catch (IOException)
                {

                    throw;
                }

            }

            // COdigo Marvin
            //int size = -1;
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //DialogResult result = openFileDialog1.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    string file = openFileDialog1.FileName;
            //    Nombre = openFileDialog1.FileName;
            //    try
            //    {
            //        string text = File.ReadAllText(file);
            //        size = text.Length;
            //        pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            //        imagenLista = true;
            //    }
            //    catch (IOException)
            //    {

            //    }
            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Image imag1 = null;
        private void dgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Limpiar();
            int RowNo;
            RowNo = e.RowIndex;
            textBox1.Text = dgUsuarios.Rows[RowNo].Cells[0].Value.ToString();
            textBox2.Text = dgUsuarios.Rows[RowNo].Cells[1].Value.ToString();
            textBox3.Text = dgUsuarios.Rows[RowNo].Cells[2].Value.ToString();
            textBox4.Text = dgUsuarios.Rows[RowNo].Cells[3].Value.ToString();
            textBox5.Text = dgUsuarios.Rows[RowNo].Cells[4].Value.ToString();
            textBox6.Text = dgUsuarios.Rows[RowNo].Cells[5].Value.ToString();
            DataGridViewCell selectedCell = dgUsuarios.Rows[RowNo].Cells[7];

            // Verificar si la celda contiene un valor
            if (selectedCell.Value != null)
            {
                string cellValue = selectedCell.Value.ToString();

                // Asignar el valor de la celda al ComboBox
                comboBox1.SelectedItem = cellValue;    
            }
            //  pictureBox1.Image = Image.FromStream(new MemoryStream((byte[])dtLista.Rows[RowNo][6]));
            //imag1 = Image.FromStream(new MemoryStream((byte[])dtLista.Rows[RowNo][6]));

            // CODIGO QUE PRODUCIA EL ERROR
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dgUsuarios.Rows[e.RowIndex];
            //    byte[] imagenBytes = (byte[])row.Cells[6].Value; // Cambia el nombre de la columna
            //    MostrarImagenEnPictureBox(imagenBytes);
            //}

            //Verificamos si el registro de la imagen es nulo para evitar errores en el picture box
            if (dgUsuarios.Rows[RowNo].Cells[6].Value != DBNull.Value)
            {
                pictureBox1.Image = (Bitmap)((new ImageConverter()).ConvertFrom(dgUsuarios.Rows[RowNo].Cells[6].Value));
            }
            else
            {
                pictureBox1.Image = null;
            }

        }
        private void MostrarImagenEnPictureBox(byte[] imagenBytes)
        {
            if (imagenBytes != null && imagenBytes.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imagenBytes))
                {
                    Image imagen = Image.FromStream(ms);
                    pictureBox1.Image = imagen;
                }
            }
            else
            {
                pictureBox1.Image = null; // Limpiar la PictureBox si no hay imagen
            }
        }

        private byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Cambia el formato según tu necesidad
                return ms.ToArray();

            }
        }
        //este boton es para actualizar el usuario
        private void button2_Click(object sender, EventArgs e)
        {

            //COdigo Mike
            if (imagenLista)
            {
                MemoryStream ms = new MemoryStream();
                Image image = Image.FromFile(Nombre);
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                //categorias.Picture = (ms.ToArray());
                var agregar = Capa_Negocios.Usuarios.ActualizarUsuario(Convert.ToInt32(textBox1.Text), Convert.ToString(textBox2.Text), Convert.ToString(textBox3.Text),
                    Convert.ToString(textBox4.Text), Convert.ToString(textBox5.Text), Convert.ToString(textBox6.Text), ms.ToArray(), Convert.ToInt32(comboBox1.SelectedValue));
                imagenLista = false;
            }
            else
            {
                //verifica si no existe previamente una imagen en el pciture box para guardar el campo de la imagen como nulo
                //de lo contrario se guarda la imagen del picture box en el campo de la imagen
                if (pictureBox1.Image == null)
                {
                    var agregar = Capa_Negocios.Usuarios.ActualizarUsuario(Convert.ToInt32(textBox1.Text), Convert.ToString(textBox2.Text), Convert.ToString(textBox3.Text),
                   Convert.ToString(textBox4.Text), Convert.ToString(textBox5.Text), Convert.ToString(textBox6.Text), null, Convert.ToInt32(comboBox1.SelectedValue));
                }
                else
                {
                    MemoryStream ms2 = new MemoryStream();
                    Image image = pictureBox1.Image;
                    image.Save(ms2, System.Drawing.Imaging.ImageFormat.Bmp);
                    //categorias.Picture = (ms.ToArray());
                    var agregar = Capa_Negocios.Usuarios.ActualizarUsuario(Convert.ToInt32(textBox1.Text), Convert.ToString(textBox2.Text), Convert.ToString(textBox3.Text),
                   Convert.ToString(textBox4.Text), Convert.ToString(textBox5.Text), Convert.ToString(textBox6.Text), ms2.ToArray(), Convert.ToInt32(comboBox1.SelectedValue));
                    imagenLista = false;
                }
            }


            //COdigo Marvin
            //byte[] imagenBytes = ConvertImageToByteArray(pictureBox1.Image);
                //var agregar = Capa_Negocios.Usuarios.ActualizarUsuario(Convert.ToInt32(textBox1.Text), Convert.ToString(textBox2.Text), Convert.ToString(textBox3.Text),
                //Convert.ToString(textBox4.Text), Convert.ToString(textBox5.Text), Convert.ToString(textBox6.Text), imagenBytes, Convert.ToInt32(comboBox1.SelectedValue));
            //verificacion de correco electronico en  Texbox  
            string email = textBox5.Text.Trim();

            if (IsValidEmail(email))
            {
                MessageBox.Show("Correo electrónico válido.");
            }
            else
            {
                MessageBox.Show("Correo electrónico no válido.");
            }

            CargarUsuarios();
        }
        private bool IsValidEmail(string email)
        {
            // Patrón de expresión regular para validar direcciones de correo electrónico
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Utilizar la clase Regex para verificar si el email coincide con el patrón
            return Regex.IsMatch(email, pattern);
        }

    }
}
