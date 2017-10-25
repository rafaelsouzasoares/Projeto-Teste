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
    public partial class CadastroCliente : Form
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            cliente cliente = new cliente();

            cliente.Nome = txbNome.Text;
            cliente.Cpf = txbCpf.Text;
            cliente.Rg = txbRg.Text;
            cliente.Endereco = txbEndereco.Text;
            cliente.Telefone = txbTelefone.Text;
            cliente.DataNascimento = Convert.ToDateTime(txbDataNasc.Text);
            cliente.Email = txbEmail.Text;

            MessageBox.Show(cliente.salvarTeste(cliente));
            
        }

        private void CadastroCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            cliente cliente = new cliente();

            cliente = cliente.Pesquisar(Convert.ToInt32(txbPesquisar.Text));

            txbId.Text = cliente.Codigo.ToString();
            txbNome.Text = cliente.Nome;
            txbCpf.Text = cliente.Cpf;
            txbRg.Text = cliente.Rg;
            txbEndereco.Text = cliente.Endereco;
            txbEmail.Text = cliente.Email;
            txbCep.Text = cliente.Cep;
            txbDataNasc.Text = cliente.DataNascimento.ToString();
            txbTelefone.Text = cliente.Telefone;
        }
    }
}
