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
    public partial class FrmAlterar : Form
    {
        private Cadastro cadastro;
        public FrmAlterar(Cadastro cadastro)
        {
            InitializeComponent();
            this.cadastro = cadastro;
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
                    MessageBox.Show( "Não existe um cliente com esse cpf!!");
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                //recupera o cpf usado na pesquisa e remove os espaços em branco do começo e fim
                string pesquisacpf = txbPesquisa.Text.Trim();
                if (pesquisacpf == "")
                {
                    MessageBox.Show("Insira um valor para o campo \"CPF - Pesquisar\"");
                    return;
                }

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
                string telefone = txbTelefone.Text.Trim();
                
                if (telefone == "")
                {
                    MessageBox.Show("Insira um valor para o campo \"Telefone\"");
                    return;
                }


                string email = txbEmail.Text.Trim();
                if (email == "")
                {
                    MessageBox.Show("Insira um valor para o campo \"Email\"");
                    return;
                }

                


                //cria um objeto funcionário com os dados atualizados
                Cliente cliente = new Cliente(nome, cpf, telefone, email);

                //atualiza os dados do funcionário que possui o cpf pesquisado
                bool rs = cadastro.atualizarCliente(pesquisacpf, cliente);
                if (rs)
                {
                    //Informa ao usuário que os dados foram atualizados com sucesso
                    MessageBox.Show("Dados Salvos!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //limpa os textbox com os dados do funcionário
                    clearTextBox();

                    //exibe uma mensagem de erro informando que não encontrou um funcionário que possua o cpf pesquisado
                    //sendo assim, não conseguiu atualizar os dados no banco!
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Não foi possível atualizar os dados do cliente");
                    sb.AppendLine("Verifique se existe um cliente cadastrado com o cpf pesquisado!");
                   MessageBox.Show(sb.ToString());

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

        private void clearTextBox()
        {
            txbNome.Clear();
            txbCPF.Clear();
            txbTelefone.Clear();
            txbEmail.Clear();
        }

        private void FrmAlterar_Load(object sender, EventArgs e)
        {

        }

       
    }
}
