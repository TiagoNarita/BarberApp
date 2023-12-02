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
using static WindowsFormsApp1.Cadastro;

namespace WindowsFormsApp1
{
    public partial class FormPesquisar : Form
    {
        private Cadastro cadastro;
        private DataTable dataTable;
        public FormPesquisar(Cadastro cadastro)
        {
            InitializeComponent();
            this.cadastro = cadastro;

            dataTable = new DataTable();
        }

        private string nomeOriginal;
        private string cpfOriginal;
        private string telefoneOriginal;
        private string emailOriginal;

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtPesquisar.Text.Trim();
                if (nome == "")
                {
                    MessageBox.Show("Insira um valor para o campo \"Nome\"");
                    return;
                }

                //pesquisa se existe um funcionario com o cpf passado
                Cliente cliente = cadastro.pesquisarClienteNome(nome);

                //caso encontre um funcionario, a referência será diferente de null
                if (cliente != null)
                {

                    // Armazena os dados originais obtidos na pesquisa
                    nomeOriginal = cliente.getNome();
                    cpfOriginal = cliente.getCPF();
                    telefoneOriginal = cliente.getTelefone();
                    emailOriginal = cliente.getEmail();

                    // Preenche os campos do formulário com os dados obtidos
                    txbNome.Text = nomeOriginal;
                    txbCPF.Text = cpfOriginal;
                    txbTelefone.Text = telefoneOriginal;
                    txbEmail.Text = emailOriginal;

                    liberaCampos();

                    datagridView.DataSource = dataTable;
                    cadastro.gerarRelatorioCliente(dataTable);
                    AtualizadorClientes.NotificarClienteCadastrado();

                }
                // funcionario == null -> não encontrou um funcionario com o cpf passado!
                else
                {
                    //limpa os textbox com os dados do funcionario
                    clearTextBox();
                    //mostra uma mensagem de erro
                    MessageBox.Show("Não existe um cliente com esse nome!");
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

        private void clearTextBox()
        {
            txbNome.Clear();
            txbCPF.Clear();
            txbTelefone.Clear();
            txbEmail.Clear();
        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            try
            {
                // Recupera os dados atuais dos campos
                string nomeAtual = txbNome.Text.Trim();
                string cpfAtual = txbCPF.Text.Trim();
                string telefoneAtual = txbTelefone.Text.Trim();
                string emailAtual = txbEmail.Text.Trim();

                // Verifica se os dados foram modificados
                if (nomeAtual != nomeOriginal || cpfAtual != cpfOriginal || telefoneAtual != telefoneOriginal || emailAtual != emailOriginal)
                {
                    // Cria um novo objeto Cliente apenas com os campos alterados
                    Cliente clienteAtualizado = new Cliente(
                        nomeAtual,
                        cpfAtual,
                        telefoneAtual,
                        emailAtual
                    );

                    // Atualiza somente os campos que foram alterados
                    // (você precisará implementar a lógica para fazer isso no seu método de atualização)
                    bool sucesso = cadastro.atualizarCliente(nomeOriginal, clienteAtualizado);

                    if (sucesso)
                    {
                        // Atualiza os dados originais para os novos valores
                        nomeOriginal = nomeAtual;
                        cpfOriginal = cpfAtual;
                        telefoneOriginal = telefoneAtual;
                        emailOriginal = emailAtual;

                        MessageBox.Show("Dados Salvos!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cadastro.gerarRelatorioCliente(dataTable);

                        AtualizadorClientes.NotificarClienteCadastrado();

                        bloqueiaCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível atualizar os dados do cliente");
                    }
                    clearTextBox();
                }
                else
                {
                    MessageBox.Show("Nenhum dado foi alterado.");
                }

            }
            catch (MySqlException erro)
            {
                // Tratamento de exceção para o banco de dados
                MessageBox.Show("Erro no banco de dados: " + erro.Message, "ERRO BANCO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception erro)
            {
                // Tratamento de outras exceções
                MessageBox.Show("Erro desconhecido: " + erro.Message, "ERRO Desconhecido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string nome = txbNome.Text.Trim();
            if (nome == "")
            {
                MessageBox.Show("Insira um valor para o campo \"Nome - Pesquisar\"");
                return;
            }

            //caso encontre uma pessoa com o cpf digitado
            if (cadastro.removerClienteNome(nome) == true)
            {


                clearTextBox();

                //informa o usuário que o funcionário foi removido do banco!
                MessageBox.Show("Cliente removido do cadastro com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cadastro.gerarRelatorioCliente(dataTable);
                AtualizadorClientes.NotificarClienteCadastrado();
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
                MessageBox.Show(sb.ToString());
            }

            //limpa os texbox de dados
            clearTextBox();

            bloqueiaCampos();
        }

        private void liberaCampos()
        {
            btnAltera.Visible = true;
            btnExcluir.Visible = true;


            txbNome.Enabled = true;
            txbCPF.Enabled = true;
            txbEmail.Enabled = true;
            txbTelefone.Enabled = true;
        }

        private void bloqueiaCampos()
        {
            btnAltera.Visible = false;
            btnExcluir.Visible = false;


            txbNome.Enabled = false;
            txbCPF.Enabled = false;
            txbEmail.Enabled = false;
            txbTelefone.Enabled = false;
        }
    }
}
