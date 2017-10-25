using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlers;

namespace EstudoProvaProcessa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ClienteController cliente = new ClienteController(Convert.ToInt32(txbId.Text), txbNome.Text,  txbCpf.Text, txbRg.Text);

            MessageBox.Show(cliente.salvarTeste(cliente));
            btnListarTodos_Click(sender, e);
        }

        private void btnListarTodos_Click(object sender, EventArgs e)
        {
            ClienteController cliente = new ClienteController();
            
            gvClientes.DataSource = cliente.listarTodos();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
