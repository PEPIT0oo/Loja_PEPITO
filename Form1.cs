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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nom = txtNome.Text;
            string cpf = TxtCPF.Text;
            string telefone = txtTelefone.Text;
            string email = txtEmail.Text;

            Cliente A = new Cliente(nom,cpf,telefone,email,' ');
            A.Inserir();

            txtNome.Text = " ";
            TxtCPF.Text = " ";
            txtTelefone.Text = " ";
            txtEmail.Text = " ";

        }
    }
}
