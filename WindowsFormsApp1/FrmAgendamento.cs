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
    public partial class FrmAgendamento : Form
    {
        private Agendamento agendamento;
        public FrmAgendamento()
        {
            InitializeComponent();

            agendamento = new Agendamento();


            /* Image image = Image.FromFile("C:\\Users\\Usuario\\OneDrive\\Área de Trabalho\\testeTrabalho\\WindowsFormsApp1\\Resources\\Agenda-PainelFundo.png");

             // Definindo a cor de fundo do PictureBox como a cor que você deseja tornar transparente
             formularioImg.BackColor = Color.Transparent;

             // Evento Paint do PictureBox
             formularioImg.Paint += (s, args) =>
             {
                 // Desenha a imagem com partes transparentes no PictureBox
                 args.Graphics.DrawImage(image, new Rectangle(Point.Empty, formularioImg.Size));
             };*/
        }

        private void FrmAgendamento_Load(object sender, EventArgs e)
        {
            // Preencher ComboBox de Clientes
            List<Tuple<int, string>> nomesClientes = agendamento.ObterNomesClientes();
            comboBoxCliente.DisplayMember = "Item2";
            comboBoxCliente.ValueMember = "Item1";
            comboBoxCliente.DataSource = nomesClientes;

            // Preencher ComboBox de Serviços
            List<string> nomesServicos = agendamento.ObterNomesServicos();
            comboBoxServico.DataSource = nomesServicos;

            // Adicionar o evento SelectedIndexChanged ao ComboBox de Serviços
            comboBoxServico.SelectedIndexChanged += comboBoxServico_SelectedIndexChanged;

            // Mostrar o valor do serviço inicialmente selecionado
            if (comboBoxServico.SelectedItem != null)
            {
                string servicoSelecionado = comboBoxServico.GetItemText(comboBoxServico.SelectedItem);
                decimal valorServico = agendamento.ObterValorServico(servicoSelecionado);
                txbValor.Text = valorServico.ToString("C");
            }
        }


        private void comboBoxServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtem o valor selecionado do ComboBox convertendo para string
            string servicoSelecionado = comboBoxServico.GetItemText(comboBoxServico.SelectedItem);

            // Verifica se o valor não é nulo ou vazio antes de prosseguir
            if (!string.IsNullOrEmpty(servicoSelecionado))
            {
                // Obter o valor do serviço e exibir na TextBox
                decimal valorServico = agendamento.ObterValorServico(servicoSelecionado);
                txbValor.Text = valorServico.ToString("C");
            }
        }

        private void AtualizarComboBoxClientes()
        {
            List<Tuple<int, string>> nomesClientes = agendamento.ObterNomesClientes();
            comboBoxCliente.DisplayMember = "Item2";
            comboBoxCliente.ValueMember = "Item1";
            comboBoxCliente.DataSource = nomesClientes;
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            // Obter os valores selecionados nos ComboBoxes e TextBoxes
            int idCliente = (int)comboBoxCliente.SelectedValue;
            string servicoSelecionado = comboBoxServico.SelectedItem.ToString();
            DateTime dataAtendimento = DateTime.Parse(txbData.Text);
            DateTime horario = DateTime.Parse(txbHorario.Text);

            // Obter o ID do serviço selecionado
            int idServico = agendamento.ObterIdServico(servicoSelecionado); // Implemente essa função na sua lógica

            // Agendar
            bool agendado = agendamento.Agendar(idCliente, idServico, dataAtendimento, horario);
            if (agendado)
            {
                MessageBox.Show("Agendamento realizado com sucesso!");
                // Atualizar o DataGridView com os novos dados
                AtualizarGridAgendamentos();
            }
            else
            {
                MessageBox.Show("Falha ao agendar!");
            }
        }


        private void AtualizarGridAgendamentos()
        {
             dataGridView1.DataSource = agendamento.ObterAgendamentos();
        }



      


    }  
    
}
