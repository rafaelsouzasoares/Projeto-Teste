using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ClienteModel
    {
        string connectionString = @"Server=.\sqlexpress;Database=varejo_db;Trusted_Connection=True;";
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }


        public ClienteModel() { }

        public ClienteModel(int id, String nome, String cpf, String rg)
        {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            this.rg = rg;
        }

        public Boolean salvarCliente(string sql)
        {
            bool retorno = false;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    retorno = true;
                else
                    retorno = false;
            }
            finally
            {
                con.Close();
            }

            return retorno;
        }

        public List<ClienteModel> listarTodos(string sql)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = null;
            con.Open();

            List<ClienteModel> listaCliente = new List<ClienteModel>();

            try
            {
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ClienteModel cliente = new ClienteModel();

                    cliente.id = Convert.ToInt32(reader["cliente_id"].ToString());
                    cliente.nome = reader["nome_cli"].ToString();
                    cliente.cpf = reader["cpf"].ToString();
                    cliente.rg = reader["rg"].ToString();
                    listaCliente.Add(cliente);
                }                           
            }
            finally
            {
                con.Close();
            }

            return listaCliente;
        }
    }
}
