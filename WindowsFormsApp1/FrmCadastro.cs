using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmCadastro : Form
    {
        public FrmCadastro()
        {
            InitializeComponent();
        }

        private void btnCadastar_Click(object sender, EventArgs e)
        {
            //recupera o texto do componente textbox e remove os espaços em branco do começo e fim
            string nome = txbNome.Text.Trim();
            if (nome == "")
            {
                MessageBox.Show("Insira um valor para o campo \"Nome\"");
                return;
            }

            //recupera o texto do componente textbox e remove os espaços em branco do começo e fim
            string cpf = txbCPF.Text.Trim();
            if (cpf == "")
            {
                MessageBox.Show("Insira um valor para o campo \"CPF\"");
                return;
            }

            //pega e valida os dados do textbox
            int qtdDependentes;
            try
            {
                qtdDependentes = int.Parse(txbTelefone.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("Insira um valor válido para o campo \"Nº de Dependentes\"");
                return;
            }

            //pega e valida os dados do textbox
            DateTime dataAdmissao;
            try
            {
                dataAdmissao = DateTime.Parse(txbIdade.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("Insira um valor válido para o campo \"Data Admissão\"");
                return;
            }

            //trata os erros relacionados ao banco
            catch (MySqlException erro)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(erro.GetType().ToString());
                sb.AppendLine(erro.Message);
                sb.Append(erro.SqlState);
                sb.AppendLine("\n");
                sb.AppendLine(erro.StackTrace);
                MessageBox.Show(sb.ToString(), "ERRO BANCO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //tratamento dos demais erros que possam ocorrer
            catch (Exception erro)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(erro.GetType().ToString());
                sb.AppendLine(erro.Message);
                sb.AppendLine("\n");
                sb.AppendLine(erro.StackTrace);
                MessageBox.Show(sb.ToString(), "ERRO Desconhecido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearTextBox()
        {
            txbNome.Clear();
            txbCPF.Clear();
            txbTelefone.Clear();
            txbIdade.Clear();
           
        }

    }
}
