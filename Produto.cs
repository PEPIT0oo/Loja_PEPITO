using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendasPEPITO
{
    class Produto
    {
        private string descricaoProduto;
        private double valorProduto;
        private int   quantidadeProduto;
        private int idProduto;

        public Produto(string descricaoProduto, double valorProduto, int quantidadeProduto, int idProduto)
        {
            this.descricaoProduto = descricaoProduto;
            this.valorProduto = valorProduto;
            this.quantidadeProduto = quantidadeProduto;
            this.idProduto = idProduto;
        }

        public void SetidProduto(int idProduto)
        {
            this.idProduto = idProduto;
        }
        public void SetdescricaoProduto(string descricaoProduto)
        {
            this.descricaoProduto = descricaoProduto;
        }
        public void SetvalorProduto(double valorProduto)
        {
            this.valorProduto = valorProduto;
        }
        public void SetidCliente(int quantidadeProduto)
        {
            this.quantidadeProduto = quantidadeProduto;
        }
        public int GetidProduto()
        {
            return this.idProduto;
        }
        public string GetdescricaoProduto()
        {
            return this.descricaoProduto;
        }
        public double GetvalorProduto()
        {
            return this.valorProduto;
        }
        public int GetquantidadeProduto()
        {
            return this.quantidadeProduto;
        }
        public void InserirProduto()
        {
            SqlCommand cmd = new SqlCommand();
            Conexao connect = new Conexao();

            cmd.CommandText = "Insert into Produto (descricaoProduto,valorProduto,quantidadeProduto) values (@descricaoProduto,@valorProduto,@quantidadeProduto)";

            cmd.Parameters.AddWithValue("@descricaoProduto", this.descricaoProduto);
            cmd.Parameters.AddWithValue("@valorProduto", this.valorProduto);
            cmd.Parameters.AddWithValue("@quantidadeProduto", this.quantidadeProduto);

            try
            {
                cmd.Connection = connect.conectar();
                cmd.ExecuteNonQuery();
                connect.desconectar();
                MessageBox.Show("Produto inserido com sucesso!");
            }
            catch (SqlException e)
            {
                MessageBox.Show("Produto não inserido!");
            }
        }
        public void SelecionarProduto(int idProduto)
        {
            SqlCommand cmd = new SqlCommand();
            Conexao connect = new Conexao();

            cmd.CommandText = "Select * from Produto where idProduto = @idProduto";
            cmd.Parameters.AddWithValue("@idProduto", idProduto);
            SqlDataReader reader;

            try
            {
                cmd.Connection = connect.conectar();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    this.descricaoProduto = reader[1].ToString();
                    this.valorProduto = reader.GetDouble(3);
                    this.quantidadeProduto = reader[2].GetHashCode();
                    MessageBox.Show("Produto selecionado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Produto não selecionado!");
                }
                connect.desconectar();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Comando não executado!");
            }

        }
        public void DeletarProduto(int idProduto)
        {
            SqlCommand cmd = new SqlCommand();
            Conexao connect = new Conexao();

            cmd.CommandText = "delete from Produto where idProduto = @idProduto";
            cmd.Parameters.AddWithValue("@idProduto", idProduto);

            try
            {
                cmd.Connection = connect.conectar();
                cmd.ExecuteNonQuery();
                connect.desconectar();
                MessageBox.Show("Produto excluído com sucesso!");
            }
            catch (SqlException e)
            {
                MessageBox.Show("Produto não excluído!");
            }

        }
        public void AtualizarProduto(int idProduto)
        {
            SqlCommand cmd = new SqlCommand();
            Conexao connect = new Conexao();

            cmd.CommandText = "update Produto set descricaoProduto = @descricaoProduto, valorProduto = @valorProduto, quantidadeProduto = @quantidadeProduto where idProduto = @idProduto";
            cmd.Parameters.AddWithValue("@idProduto", idProduto);
            cmd.Parameters.AddWithValue("@descricaoProduto", this.descricaoProduto);
            cmd.Parameters.AddWithValue("@valorProduto", this.valorProduto);
            cmd.Parameters.AddWithValue("@quantidadeProduto", this.quantidadeProduto);


            try
            {
                cmd.Connection = connect.conectar();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produto atualizado com sucesso!");
                connect.desconectar();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Produto não foi atualizado!");
            }
        }
    }
}
