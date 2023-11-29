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
    public partial class FrmCadastrar : Form
    {
        private Cadastro cadastro;
        public FrmCadastrar(Cadastro cadastro)
        {
            InitializeComponent();
            this.cadastro = cadastro;
               
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCadastrar_Load(object sender, EventArgs e)
        {

        }
    }
}
