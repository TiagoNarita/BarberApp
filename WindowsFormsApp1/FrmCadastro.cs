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
        private Cadastro cadastro;
        private DataTable dataTable;
        public FrmCadastro(Cadastro cadastro)
        {
            InitializeComponent();
            this.cadastro = cadastro;
        }
        private void FrmCadastro_Load(object sender, EventArgs e)
        {
            cadastro = new Cadastro();

            //cria uma tabela vazia
            dataTable = new DataTable();

            //insere os dados do relatório na tabela
            cadastro.gerarRelatorioCliente(dataTable);

            //diz para o grid utilizar essa tabela como fonte de dados
            //nesse caso o grid irá exibir os dados da tabela!
            gvFuncionarios.DataSource = dataTable;

            //libera os recursos da tabela!
           
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
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
            string telefone = txbTelefone.Text.Trim();
            if (telefone == "")
            {
                MessageBox.Show("Insira um valor para o campo \"Telefone\"");
                return;
            }

            //pega e valida os dados do textbox
            string email = txbEmail.Text.Trim();
            if (email == "")
            {
                MessageBox.Show("Insira um valor para o campo \"Email\"");
                return;
            }

            //pega e valida os dados do textbox


            try
            {
                //cria um objeto funcionário com os dados dos textbox
                Cliente cliente = new Cliente(nome, cpf, telefone, email);

                //cadastra o funcionario no banco
                cadastro.inserirCliente(cliente);

                //limpa os textbox com os dados do funcionario
                clearTextBox();

                //informa o usuário que o funcionario foi cadastrado no banco
                MessageBox.Show("Dados Salvos!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cadastro.gerarRelatorioCliente(dataTable);
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

        private string nomeOriginal;
        private string cpfOriginal;
        private string telefoneOriginal;
        private string emailOriginal;
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txbNome.Text.Trim();
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
                    }

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

    

        private void btnAtualizar_Click(object sender, EventArgs e)
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
        {//recupera o cpf usado na pesquisa (remove os espaços em branco do começo e fim do texto)
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
