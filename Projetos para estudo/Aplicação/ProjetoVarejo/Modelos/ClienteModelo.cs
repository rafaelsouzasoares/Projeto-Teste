using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class ClienteModelo
    {
        public ClienteModelo() { }


        string connectionString = @"Server=.\sqlexpress;Database=varejo_db;Trusted_Connection=True;";

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
            }
            catch (Exception ex)
            {
                retorno = false;
            }
            finally
            {
                con.Close();
            }

            return retorno;
        }
    }
}
