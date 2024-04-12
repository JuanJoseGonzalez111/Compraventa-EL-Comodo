using Compraventa_EL_Comodo.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compraventa_EL_Comodo
{
    public partial class Abonar : Form
    {
        private readonly IEmpeñar _empe;
        private readonly IRetirar _retirar;
        public Abonar(IEmpeñar empeñar, IRetirar  retirar)
        {
            InitializeComponent();
            _empe = empeñar;
            _retirar = retirar;
        }

        private void Abonar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _empe.cargarDeudores(txtCedula.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];

                // Extrae los valores de las celdas y los asigna a los TextBox correspondientes

                txtarticulo.Text = filaSeleccionada.Cells[1].Value.ToString();
                txtDeuda.Text = filaSeleccionada.Cells[2].Value.ToString();
                dateTimePicker1.Text = filaSeleccionada.Cells[3].Value.ToString();
                dateTimePicker2.Text = filaSeleccionada.Cells[4].Value.ToString();
                // Así sucesivamente para los demás campos
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal deudaActual = decimal.Parse(txtDeuda.Text);
            decimal pago = decimal.Parse(txtPago.Text);
            decimal nuevoMontoDeuda = deudaActual - pago;
            DateTime fechaActual = dateTimePicker2.Value;
            DateTime nuevaFechaSalida = fechaActual.AddDays(10);
            _retirar.InsertarAbono(txtCedula.Text, txtarticulo.Text, DateTime.Parse(dateTimePicker1.Text), decimal.Parse(txtDeuda.Text)
                , decimal.Parse(txtPago.Text), decimal.Parse(txtDeuda.Text), nuevaFechaSalida);
        }
    }
}
