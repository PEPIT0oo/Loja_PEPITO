using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendasPEPITO
{
    class Venda
    {
        private int idVenda;
        private int idCliente;
        private int idProduto;
        private string cupomVenda;
        private DateTime dataVenda;
        private int quantidadeVenda;
        private double valorVenda;
        private double totalVenda;

        public Venda(int idVenda, int idCliente, int idProduto, string cupomVenda, DateTime dataVenda, int quantidadeVenda, double valorVenda, double totalVenda)
        {
            this.idVenda = idVenda;
            this.idCliente = idCliente;
            this.idProduto = idProduto;
            this.cupomVenda = cupomVenda;
            this.dataVenda = dataVenda;
            this.quantidadeVenda = quantidadeVenda;
            this.valorVenda = valorVenda;
            this.totalVenda = totalVenda;
        }
        public void SetidVenda(int idVenda)
        {
            this.idVenda = idVenda;
        }
        public void SetidCliente(int idCliente)
        {
            this.idCliente = idCliente;
        }
        public void SetidProduto(int idProduto)
        {
            this.idProduto = idProduto;
        }
        public void SetcupomVenda(string cupomVenda)
        {
            this.cupomVenda = cupomVenda;
        }
        public void SetdataVenda(DateTime dataVenda)
        {
            this.dataVenda = dataVenda;
        }
        public void SetquantidadeVenda(int quantidadeVenda)
        {
            this.quantidadeVenda = quantidadeVenda;
        }
        public void SetvalorVenda(double valorVenda)
        {
            this.valorVenda = valorVenda;
        }
        public void SettotalVenda(double totalVenda)
        {
            this.totalVenda = totalVenda;
        }
        public int GetidVenda()
        {
            return this.idVenda;
        }
        public int GetidCliente()
        {
            return this.idCliente;
        }
        public int GetidProduto()
        {
            return this.idProduto;
        }
        public string GetcupomVenda()
        {
            return this.cupomVenda;
        }
        public DateTime GetdataVenda()
        {
            return this.dataVenda;
        }
        public int GetquantidadeVenda()
        {
            return this.quantidadeVenda;
        }
        public double GetvalorVenda()
        {
            return this.valorVenda;
        }
        public double GettotalVenda()
        {
            return this.totalVenda;
        }
        public void InserirVenda()
        {
            SqlCommand cmd = new SqlCommand();
            Conexao connect = new Conexao();

            cmd.CommandText = "Insert into Venda (idCliente,idProduto,cupomVenda,dataVenda,quantidadeVenda,valorVenda,totalVenda) values (@idCliente,@idProduto,@cupomVenda,@dataVenda,@quantidadeVenda,@valorVenda,@totalVenda)";

            cmd.Parameters.AddWithValue("@idCliente", this.idCliente);
            cmd.Parameters.AddWithValue("@idProduto", this.idProduto);
            cmd.Parameters.AddWithValue("@cupomVenda", this.cupomVenda);
            cmd.Parameters.AddWithValue("@dataVenda", this.dataVenda);
            cmd.Parameters.AddWithValue("@quantidadeVenda", this.quantidadeVenda);
            cmd.Parameters.AddWithValue("@valorVenda", this.valorVenda);
            cmd.Parameters.AddWithValue("@totalVenda", this.totalVenda);

            try
            {
                cmd.Connection = connect.conectar();
                cmd.ExecuteNonQuery();
                connect.desconectar();
                MessageBox.Show("Venda inserida com sucesso!");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

    }
}
