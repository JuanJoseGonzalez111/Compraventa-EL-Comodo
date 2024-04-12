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
    public partial class Form1 : Form
    {
        private readonly IEmpeñar _empe;
        private readonly IRetirar _retirar;
        private readonly IClienteDatos _clienteDatos;
        public Form1(IEmpeñar empeñar,IRetirar retirar, IClienteDatos clienteDatos)
        {
            InitializeComponent();
            this._empe = empeñar;
            _retirar = retirar;
            _clienteDatos = clienteDatos;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmpeñarForms empeñarForms = new EmpeñarForms(_empe);
            empeñarForms.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Retiroforms retiroforms = new Retiroforms(_empe,_retirar);
            retiroforms.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Abonar abonar = new Abonar(_empe,_retirar);
            abonar.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClienteForms clienteForms = new ClienteForms(_clienteDatos);
            clienteForms.ShowDialog();

        }
    }
}
