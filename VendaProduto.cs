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
    public partial class VendaProduto : Form
    {

       

        void Somar()
        {
            double totGeral = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                totGeral += Convert.ToDouble (dataGridView1.Rows[i].Cells[4].Value);
            }

            lbValorCOMPRA.Text = totGeral.ToString();
        }
        public VendaProduto()
        {
            InitializeComponent();
            DateTime data = DateTime.Now;
            labelData.Text = data.ToString("yy/M/d");
            var cupom = data.ToString("yyyymdhhmmss");
            labelCupom.Text = data.ToString("yyyymdhhmmss");
        }

        private void btnMostrarCliente_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtCliente.Text);
            Cliente A;
            A = new Cliente(" ", " ", " ", " ", 0);
            A.Selecionar(id);
            labelCliente.Text = A.GetnomeCliente();
        }

        private void btnMostrarProduto_Click(object sender, EventArgs e)
        {
            int idProduto = Int32.Parse(txtProduto.Text);
            Produto B;
            B = new Produto(" ", 0, 0, 0);
            B.SelecionarProduto(idProduto);
            nomeProduto.Text = B.GetdescricaoProduto();
            lbValorPro.Text = B.GetvalorProduto().ToString();
        }

        private void VendaProduto_Load(object sender, EventArgs e)
        {

        }

        private void brnMostrarQuantidade_Click(object sender, EventArgs e)
        {
            Double tot = Double.Parse(txtQuantidade.Text) * Double.Parse(lbValorPro.Text);
            lbTotal.Text = tot.ToString();
        }

        private void labelCupom_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string[] linha = new string[] { txtProduto.Text, nomeProduto.Text, txtQuantidade.Text, lbValorPro.Text, lbTotal.Text };
            dataGridView1.Rows.Add(linha);
            Somar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            Somar();
        }

        private void btnFecharCompra_Click(object sender, EventArgs e)
        {
            Venda M;
            int idClientes = Convert.ToInt32(txtCliente.Text);
            int idProdutos = Convert.ToInt32(txtProduto.Text);
            string cupom = labelCupom.Text;
            DateTime data = DateTime.Now;
           
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                int quantidade = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                double valor = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                double total = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);

                M = new Venda(0, idClientes, idProdutos, cupom, data, quantidade, valor, total);
                M.InserirVenda();
            
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}