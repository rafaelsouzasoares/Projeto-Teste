using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Modelos;


namespace ProjetoVarejo
{
    class cliente
    {
        string connectionString = @"Server=.\sqlexpress;Database=varejo_db;Trusted_Connection=True;";
        bool novoRegistro;
        

        private int codigo;
        private String nome;
        private String cpf;
        private String rg;
        private String telefone;
        private String email;
        private DateTime dataNascimento;
        private String endereco;
        private String cep;

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Cpf
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }

        public string Rg
        {
            get
            {
                return rg;
            }

            set
            {
                rg = value;
            }
        }

        public string Telefone
        {
            get
            {
                return telefone;
            }

            set
            {
                telefone = value;
            }
        }

        public DateTime DataNascimento
        {
            get
            {
                return dataNascimento;
            }

            set
            {
                dataNascimento = value;
            }
        }

        public string Endereco
        {
            get
            {
                return endereco;
            }

            set
            {
                endereco = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Cep
        {
            get
            {
                return cep;
            }

            set
            {
                cep = value;
            }
        }

        public cliente() {}

        public cliente(int codigo, String nome, String cpf, String rg, String telefone, DateTime dataNascimento, String endereco, String email, String cep)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Telefone = telefone;
            this.DataNascimento = dataNascimento;
            this.Endereco = endereco;
            this.email = email;
            this.cep = cep;
        }

        public void Teste() {
            TelaPricipal tela = new TelaPricipal();
            tela.Show();
        }

        public String salvarTeste(cliente c) {
            string mensagem = "";
            string sql = " INSERT INTO CLIENTE_TB(NOME_CLI, CPF, RG, DATA_NASCIMENTO, TELEFONE, EMAIL, ENDERECO, CEP)VALUES("
                          + "'" + c.nome + "', "
                          + "'" + c.cpf + "', "
                          + "'" + c.rg + "', "
                          + "'" + c.dataNascimento + "', "
                          + "'" + c.telefone + "', "
                          + "'" + c.email + "', "
                          + "'" + c.endereco + "', "
                          + "'" + c.cep + "')";
            

            //SqlConnection con = new SqlConnection(connectionString);
            //SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.CommandType = System.Data.CommandType.Text;
            //con.Open();

            //try
            //{
            //    int i = cmd.ExecuteNonQuery();
            //    if (i > 0)
            //        mensagem = "Cadastrado com sucesso!";
            //}
            //catch (Exception ex)
            //{
            //    mensagem = "Erro: " + ex.ToString();                
            //}
            //finally
            //{
            //    con.Close();
            //}

            return mensagem;            
        }

        public cliente Pesquisar(int cliente_id)
        {
            string sql = " select * from cliente_tb where cliente_id = " + cliente_id;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader;
            con.Open();
            cliente cli = new cliente();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cli.codigo = Convert.ToInt32(reader[0].ToString());
                    cli.nome = reader[1].ToString();
                    cli.cpf = reader[2].ToString();
                    cli.rg = reader[3].ToString();
                    cli.dataNascimento = Convert.ToDateTime(reader[4].ToString());
                    cli.telefone = reader[5].ToString();
                    cli.email = reader[6].ToString();
                    cli.endereco = reader[7].ToString();
                    cli.cep = reader[8].ToString();                        
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return cli;
        }
    }
    
}
