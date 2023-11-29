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
    public partial class FrmPesquisar : Form
    {
        private Cadastro cadastro;
        public FrmPesquisar(Cadastro cadastro)
        {
            InitializeComponent();
            this.cadastro = cadastro;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string cpf = txbPesquisa.Text.Trim();
                if (cpf == "")
                {
                    MessageBox.Show("Insira um valor para o campo \"CPF\"");
                    return;
                }

                //pesquisa se existe um funcionario com o cpf passado
                Cliente cliente = cadastro.pesquisarClienteCPF(cpf);

                //caso encontre um funcionario, a referência será diferente de null
                if (cliente != null)
                {
                    //atualiza os textbox com os dados do funcionário encontrado
                    txbNome.Text = cliente.getNome();
                    txbCPF.Text = cliente.getCPF();
                    txbTelefone.Text = cliente.getTelefone();
                    txbEmail.Text = cliente.getEmail();

                }
                // funcionario == null -> não encontrou um funcionario com o cpf passado!
                else
                {
                    //limpa os textbox com os dados do funcionario
                    clearTextBox();
                    //mostra uma mensagem de erro
                    MessageBox.Show( "Não existe um cliente com esse cpf!");
                }

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

        private void FrmPesquisar_Load(object sender, EventArgs e)
        {

        }
        private void clearTextBox()
        {
            txbNome.Clear();
            txbCPF.Clear();
            txbTelefone.Clear();
            txbEmail.Clear();
        }
    }
}
