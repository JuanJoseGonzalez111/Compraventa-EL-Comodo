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
    public partial class Retiroforms : Form
    {
        private readonly IEmpeñar _empe;
        private readonly IRetirar _retirar;
        public Retiroforms(IEmpeñar empeñar,IRetirar retirar)
        {
            InitializeComponent();
            _empe = empeñar;
            _retirar = retirar;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
             dataGridView1.DataSource = _empe.cargarDeudores(txtCedula.Text);
         

        }

    

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si la celda seleccionada pertenece a una fila de datos (no a encabezados o celdas vacías)
            if (e.RowIndex >= 0)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];

                // Extrae los valores de las celdas y los asigna a los TextBox correspondientes

                txtarticulo.Text = filaSeleccionada.Cells[1].Value.ToString();
                txtDeuda.Text = filaSeleccionada.Cells[2].Value.ToString();
                dateTimePicker2.Text = filaSeleccionada.Cells[3].Value.ToString();
                // Así sucesivamente para los demás campos
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cedulaCliente = txtCedula.Text;
            string articulo = txtarticulo.Text;
            DateTime fecha = dateTimePicker1.Value;
            decimal montoAdeudado = decimal.Parse(txtDeuda.Text);
            decimal montoPagado = decimal.Parse(txtPago.Text);
          decimal montoFaltante = 0;
            int estadoRetiro = 3;
            _retirar.EjecutarProcedimientoAlmacenado(cedulaCliente, articulo, fecha, montoAdeudado, montoPagado, montoFaltante, estadoRetiro);

            MessageBox.Show("Retiro realizado correctamente");
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
             
                string cedulaCliente = txtCedula.Text;
                string articulo = txtarticulo.Text;
            
                
            decimal deudaActual = decimal.Parse(txtDeuda.Text);
            decimal pago = decimal.Parse(txtPago.Text);
            decimal nuevoMontoDeuda = deudaActual - pago;
            DateTime fechaActual = dateTimePicker2.Value;
            DateTime nuevaFechaSalida = fechaActual.AddDays(10);


           // _retirar.ActualizarEmpeñar(cedulaCliente, articulo, nuevoMontoDeuda, nuevaFechaSalida);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Retiroforms_Load(object sender, EventArgs e)
        {

        }
    }
}
