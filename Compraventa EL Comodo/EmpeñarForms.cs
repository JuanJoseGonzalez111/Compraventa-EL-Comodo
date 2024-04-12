using Compraventa_EL_Comodo.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compraventa_EL_Comodo
{
    public partial class EmpeñarForms : Form
    {
        private readonly IEmpeñar _empeñar1;
        public EmpeñarForms(IEmpeñar empeñar)
        {
            InitializeComponent();
            
            dataGridView1.AutoGenerateColumns = false;
            this._empeñar1 = empeñar;
            dataGridView1.DataSource = _empeñar1.Loadempe();
        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {

            byte[] imagenBytes;
            using (MemoryStream stream = new MemoryStream())
            {
                pictureBox1.Image.Save(stream, ImageFormat.Jpeg);
                imagenBytes = stream.ToArray();
            }


            DateTime fechaSeleccionada = dateTimePicker1.Value;
            var estado = "2";

            DateTime segundaFecha = fechaSeleccionada.AddDays(10);

            _empeñar1.InsertarEnPeño(txtcedula.Text, txtarticulo.Text, txtidentificador.Text, txtDescripción.Text, fechaSeleccionada, segundaFecha, decimal.Parse(txtMonto.Text), estado.ToString(), decimal.Parse(txtMonto.Text), imagenBytes);
            MessageBox.Show("Se guardaron los datos Correctamente");
            dataGridView1.DataSource = _empeñar1.Loadempe();


        }

        
        private bool EsImagen(string rutaArchivo)
        {
            try
            {
                using (var img = Image.FromFile(rutaArchivo))
                {
                    return img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid ||
                           img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid ||
                           img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid ||
                           img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid ||
                           img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Tiff.Guid;
                }
            }
            catch
            {
                return false;
            }
        }


        /*private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";
            openFileDialog.Title = "Seleccionar imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionado
                string rutaImagen = openFileDialog.FileName;

                try
                {
                    // Cargar la imagen desde el archivo
                    Image imagen = Image.FromFile(rutaImagen);

                    // Mostrar la imagen en un PictureBox u otro control
                    pictureBox1.Image = imagen;

                    // Opcional: almacenar la ruta de la imagen para guardarla en la base de datos o utilizarla posteriormente
                    // string rutaAlmacenada = rutaImagen;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";
            openFileDialog.Title = "Seleccionar imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionado
                string rutaImagen = openFileDialog.FileName;

                try
                {
                    // Verificar si el archivo seleccionado es una imagen
                    if (EsImagen(rutaImagen))
                    {
                        // Cargar la imagen desde el archivo
                        using (Image imagen = Image.FromFile(rutaImagen))
                        {
                            // Mostrar la imagen en un PictureBox u otro control
                            pictureBox1.Image = new Bitmap(imagen);

                            // Almacenar la ruta de la imagen para guardarla en la base de datos o utilizarla posteriormente
                            // string rutaAlmacenada = rutaImagen;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El archivo seleccionado no es una imagen válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
