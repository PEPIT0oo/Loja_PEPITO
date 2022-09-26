using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendasPEPITO
{
    class Cliente
    {
        private int idCliente;
        private string nomeCliente;
        private string cpfCliente;
        private string telefoneCliente;
        private string emailCliente;

       

        public Cliente(string nomeCliente, string cpfCliente, string telefoneCliente, string emailCliente, int idCliente)
        {
            this.idCliente = idCliente;
            this.nomeCliente = nomeCliente;
            this.cpfCliente = cpfCliente;
            this.telefoneCliente = telefoneCliente;
            this.emailCliente = emailCliente;

        }

        public void SetidCliente( int idCliente)
        {
            this.idCliente = idCliente;
        }
        public void SetnomeCliente(string nomeCliente)
        {
            this.nomeCliente = nomeCliente;
        }
        public void SetcpfCliente(string cpfCliente)
        {
            this.cpfCliente = cpfCliente;
        }
        public void SettelefoneCliente(string telefoneCliente)
        {
            this.telefoneCliente = telefoneCliente;
        }
        public void SetemailCliente(string emailCliente)
        {
            this.emailCliente = emailCliente;
        }
        public int GetidCliente()
        {
            return this.idCliente;
        }
        public string GetnomeCliente()
        {
            return this.nomeCliente;
        }
        public string GetcpfCliente()
        {
            return this.cpfCliente;
        }
        public string GettelefoneCliente()
        {
            return this.telefoneCliente;
        }
        public string GetemailCliente()
        {
            return this.emailCliente;
        }
 
        public void Inserir()
        {
            SqlCommand cmd = new SqlCommand();
            Conexao connect = new Conexao();

            cmd.CommandText = "Insert into Cliente (nomeCliente, cpfCliente, telefoneCliente, emailCliente) values ( @nomeCliente, @cpfCliente, @telefoneCliente, @emailCliente)";

            cmd.Parameters.AddWithValue("@nomeCliente", this.nomeCliente);
            cmd.Parameters.AddWithValue("@cpfCliente", this.cpfCliente);
            cmd.Parameters.AddWithValue("@telefoneCliente", this.telefoneCliente);
            cmd.Parameters.AddWithValue("@emailCliente", this.emailCliente);

            try
            {
                cmd.Connection = connect.conectar();
                cmd.ExecuteNonQuery();
                connect.desconectar();
                MessageBox.Show("Dados salvos com sucesso!");
            }
            catch (SqlException e)
            {
                MessageBox.Show("Dados não inseridos!");
            }


        }
        public void Selecionar(int id)
        {
            SqlCommand cmd = new SqlCommand();
            Conexao connect = new Conexao();

            cmd.CommandText = "Select * from Cliente where idCliente = @idCliente";

            cmd.Parameters.AddWithValue("@idCliente", id);
            SqlDataReader reader;

            try
            {
                cmd.Connection = connect.conectar();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    this.nomeCliente = reader[1].ToString();
                    this.cpfCliente = reader[2].ToString();
                    this.telefoneCliente = reader[3].ToString();
                    this.emailCliente = reader[4].ToString();
                  MessageBox.Show("Dados selecionados com sucesso!");
                }
                else
                {
                    MessageBox.Show("Dados não selecionados!");
                }
                connect.desconectar();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Comando não executado!");
            }
        }
        public void Deletar(int idCliente)
        {
            SqlCommand cmd = new SqlCommand();
            Conexao connect = new Conexao();

            cmd.CommandText = "delete from Cliente where idCliente = @idCliente";
            cmd.Parameters.AddWithValue("@idCliente", idCliente);



            try
            {
                cmd.Connection = connect.conectar();
                cmd.ExecuteNonQuery();
                connect.desconectar();
                MessageBox.Show("Dados excluídos com sucesso!");
            }
            catch (SqlException e)
            {
                MessageBox.Show("Dados não excluídos");
            }
        }
        public void Atualizar(int idCliente)
        {
            SqlCommand cmd = new SqlCommand();
            Conexao connect = new Conexao();

            cmd.CommandText = "update Cliente set nomeCliente = @nomeCliente, cpfCliente = @cpfCliente, telefoneCliente = @telefoneCliente, emailCliente = @emailCliente where idCliente = @idCliente ";
            cmd.Parameters.AddWithValue("@idCliente", idCliente);
            cmd.Parameters.AddWithValue("@nomeCliente", this.nomeCliente);
            cmd.Parameters.AddWithValue("@cpfCliente", this.cpfCliente);
            cmd.Parameters.AddWithValue("@telefoneCliente", this.telefoneCliente);
            cmd.Parameters.AddWithValue("@emailCliente", this.emailCliente);

            try
            {
                cmd.Connection = connect.conectar();
                cmd.ExecuteNonQuery();
                connect.desconectar();
                MessageBox.Show("Dados atualizados com sucesso!");
            }
            catch (SqlException e)
            {
                MessageBox.Show("Dados não foram atualizados!");
            }
        }
    }
    }

