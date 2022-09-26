using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendasPEPITO
{
    public partial class TelaProduto : Form
    {
        Produto B;
        public TelaProduto()
        {
            InitializeComponent();
        }

        private void btnCadastrarPro_Click(object sender, EventArgs e)
        {
            string descricaoProduto = txtDescricao.Text;
            double valorProduto = double.Parse(txtValor.Text);
            int quantidadeProduto = Int32.Parse(txtQuantidade.Text);
            

            Produto B = new Produto(descricaoProduto,valorProduto,quantidadeProduto,0);
            B.InserirProduto();

            txtDescricao.Text = " ";
            txtValor.Text = " ";
            txtQuantidade.Text = " ";
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            int idProduto = Int32.Parse(txtIDPro.Text);

            B = new Produto(" ",0,0,0);
            B.SelecionarProduto(idProduto);
            txtDescricao.Text = B.GetdescricaoProduto();
            txtQuantidade.Text = Convert.ToString (B.GetquantidadeProduto());
            txtValor.Text = Convert.ToString (B.GetvalorProduto());
            
        }

        private void btnDeletarPro_Click(object sender, EventArgs e)
        {
            int idProduto = Int32.Parse(txtIDPro.Text);
            B = new Produto(" ",0,0,0);
            B.DeletarProduto(idProduto);
        }

        private void btnAtualizarPro_Click(object sender, EventArgs e)
        {
            int idProduto = Int32.Parse(txtIDPro.Text);
            string descricaoProduto = txtDescricao.Text;
            double valorProduto = double.Parse(txtValor.Text);
            int quantidadeProduto = Int32.Parse(txtQuantidade.Text);

            Produto B = new Produto(descricaoProduto,valorProduto,quantidadeProduto,0);

            B.AtualizarProduto(idProduto);
        }
    }
}
