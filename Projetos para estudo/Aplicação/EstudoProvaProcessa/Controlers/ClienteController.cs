using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using System.Data;
using System.Data.SqlClient;

namespace Controlers
{
    public class ClienteController
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }

        public ClienteController() { }

        public ClienteController(int id, String nome, String cpf, String rg)
        {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            this.rg = rg;
        }



        public String salvarTeste(ClienteController c)
        {
            string mensagem = "";
            string sql = " INSERT INTO CLIENTE_TB(NOME_CLI, CPF, RG)VALUES("
                          + "'" + c.nome + "', "
                          + "'" + c.cpf + "', "
                          + "'" + c.rg +  "')";

            ClienteModel cliente = new ClienteModel();
            
            if (cliente.salvarCliente(sql))
            {
                mensagem = "Cliente cadastrado com sucesso!";
            }
            else {
                mensagem = "Ocorreu um erro durante a gravação e o cliente não foi salvo!";
            }
            return mensagem;
        }

        public List<ClienteModel> listarTodos()
        {
            string sql = "SELECT * FROM CLIENTE_TB";
            ClienteModel clienteModel = new ClienteModel();

            List <ClienteModel> ListaCliente = new List<ClienteModel>();
            return clienteModel.listarTodos(sql);
                      
            
        }

    }
}
