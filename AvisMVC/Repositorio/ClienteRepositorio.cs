using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AvisMVC.Models;
using System.Data;

namespace AvisMVC.Repositorio
{
   public class ClienteRepositorio
    {
        private SqlConnection _con;
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString(); 
  
            //SqlConnection constr = new SqlConnection();
            //constr.ConnectionString = "stringConexao";

            _con = new SqlConnection(constr);
        }
        public bool AdicionarCliente(Cliente ClienteObj)
        {
            Connection();
            int i;
            using ( SqlCommand command = new SqlCommand("SPIncluirCliente", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nome", ClienteObj.Nome);
                command.Parameters.AddWithValue("@Logradouro", ClienteObj.Logradouro);
                command.Parameters.AddWithValue("@CPF", ClienteObj.Cpf);
                _con.Open();
                i = command.ExecuteNonQuery();
            }
            _con.Close();
            return i >= 1;
        }

        public List<Cliente> ObterCliente( int _ClienteID )
        {
            Connection();
            List<Cliente> clienteList = new List<Cliente>();

            using (SqlCommand command = new SqlCommand("SPObterCliente", _con ))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClienteID", _ClienteID);
                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Cliente _cliente = new Cliente()
                    {
                        ClienteID = Convert.ToInt32(reader["ClienteID"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        Logradouro = Convert.ToString(reader["Logradouro"]),
                        Cpf = Convert.ToString(reader["Cpf"])
                    };

                    clienteList.Add(_cliente);

                }
                _con.Close();
                return clienteList;
            }
        }

        public bool AtualizarCliente(Cliente ClienteObj)
        {
            Connection();
            int i;
            using (SqlCommand command = new SqlCommand("SPAtualizaCliente", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClienteID", ClienteObj.ClienteID);
                command.Parameters.AddWithValue("@Nome", ClienteObj.Nome);
                command.Parameters.AddWithValue("@Logradouro", ClienteObj.Logradouro);
                command.Parameters.AddWithValue("@CPF", ClienteObj.Cpf);
                _con.Open();
                i = command.ExecuteNonQuery();
            }
            _con.Close();
            return i >= 1;
        }

        public bool ExcluirCliente(int _ClienteID)
        {
            Connection();
            int i;
            using (SqlCommand command = new SqlCommand("SPExcluirCliente", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClienteID", _ClienteID);
                _con.Open();
                i = command.ExecuteNonQuery();
            }
            _con.Close();
            return i >= 1;
        }

    }
}