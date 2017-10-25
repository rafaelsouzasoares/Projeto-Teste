using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoVarejo
{
    public partial class TelaPricipal : Form
    {
        public TelaPricipal()
        {
            InitializeComponent();
        }

        private void tarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroCliente cadastroCliente = new CadastroCliente();

            cadastroCliente.Show();
        }
    }
}
