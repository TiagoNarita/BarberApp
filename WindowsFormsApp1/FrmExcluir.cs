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
    public partial class FrmExcluir : Form
    {
        private Cadastro cadastro;
        public FrmExcluir(Cadastro cadastro)
        {
            InitializeComponent();
            this.cadastro = cadastro;
            
        }

        private void FrmExcluir_Load(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                //recupera o cpf usado na pesquisa e remove os espaços em branco do começo e fim
                string cpf = txbPesquisa.Text.Trim();
                if (cpf == "")
                {
                   MessageBox.Show("Insira um valor para o campo \"Pesquisar CPF\"");
                    return;
                }

                //pesquisa se existe um funcionario com o cpf passado
                Cliente cliente = cadastro.pesquisarClienteCPF(cpf);

                //caso encontre um funcionario, a referência será diferente de null
                if (cliente != null)
                {
                    txbNome.Text = cliente.getNome();
                    txbCPF.Text = cliente.getCPF();
                    txbTelefone.Text = cliente.getTelefone();
                    txbEmail.Text = cliente.getEmail();

                }
                // funcionario == null -> não encontrou um funcionario com o cpf passado!
                else
                {
                    MessageBox.Show("Não existe um cliente com esse cpf!!");
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //recupera o cpf usado na pesquisa (remove os espaços em branco do começo e fim do texto)
            string cpf = txbPesquisa.Text.Trim();
            if (cpf == "")
            {
                MessageBox.Show("Insira um valor para o campo \"CPF - Pesquisar\"");
                return;
            }

            //caso encontre uma pessoa com o cpf digitado
            if (cadastro.removerClienteCPF(cpf) == true)
            {

                //limpa o textbox de pesquisa
                txbPesquisa.Clear();

                //limpa os textbox com os dados do usuário
                clearTextBox();

                //informa o usuário que o funcionário foi removido do banco!
                MessageBox.Show("Cliente removido do cadastro com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            //caso não encontre uma pessoa com o cpf digitado
            else
            {
                //limpa os textbox com os dados do funcionário
                clearTextBox();

                //exibe uma mensagem de erro informando que não encontrou um funcionário que possua o cpf pesquisado
                //sendo assim, não conseguiu atualizar os dados no banco!
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Não foi possivel remover o cliente do cadastro!");
                sb.AppendLine("Verifique se existe um cliente cadastrado com o cpf pesquisado!");
                MessageBox.Show( sb.ToString());
            }

            //limpa os texbox de dados
            clearTextBox();
        }

        private void clearTextBox()
        {
            txbNome.Clear();
            txbCPF.Clear();
            txbTelefone.Clear();
            txbEmail.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
