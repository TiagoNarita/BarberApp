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
    public partial class FrmAgendamento : Form
    {
        private Agendamento agendamento;
        private List<TimeSpan> horariosDisponiveis;
        public FrmAgendamento()
        {
            InitializeComponent();

            agendamento = new Agendamento();

            AtualizadorClientes.ClienteCadastrado += AtualizarComboBoxClientes;
            PreencherComboBoxHorarios(comboBoxHorarios);



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

        private void AtualizarComboBoxClientes(object sender, EventArgs e)
        {
            // Atualiza a ComboBox de Clientes
            List<Tuple<int, string>> nomesClientes = agendamento.ObterNomesClientes();
            comboBoxCliente.DisplayMember = "Item2";
            comboBoxCliente.ValueMember = "Item1";
            comboBoxCliente.DataSource = nomesClientes;
        }

        public void PreencherComboBoxHorarios(ComboBox comboBox)
        {
            List<TimeSpan> horarios = agendamento.ObterHorariosDisponiveis();
            comboBox.Items.Clear(); // Limpa os itens atuais da ComboBox

            foreach (TimeSpan horario in horarios)
            {
                comboBox.Items.Add(horario.ToString(@"hh\:mm"));
            }
        }
        private void btnAgendar_Click(object sender, EventArgs e)
        {
            if (comboBoxHorarios.SelectedItem != null)
            {
                string horarioSelecionado = comboBoxHorarios.SelectedItem.ToString();

                if (TimeSpan.TryParseExact(horarioSelecionado, @"hh\:mm", null, out TimeSpan horario))
                {
                    if (comboBoxCliente.SelectedItem != null && comboBoxServico.SelectedItem != null && dateTimePickerData.Value != DateTime.MinValue)
                    {
                        int idServico = agendamento.ObterIdServico(comboBoxServico.SelectedItem.ToString());

                        if ((int)comboBoxCliente.SelectedValue > 0 && idServico > 0)
                        {
                            int idHorario = agendamento.ObterIdHorarioSelecionado(comboBoxHorarios.SelectedItem.ToString());
                            // Substitua ObterIdHorarioSelecionado pelo método que você criou para obter o ID do horário selecionado

                            if (idHorario > 0)
                            {
                                bool agendado = agendamento.Agendar((int)comboBoxCliente.SelectedValue, idServico, dateTimePickerData.Value, idHorario);

                                if (agendado)
                                {
                                    MessageBox.Show("Agendamento realizado com sucesso!");
                                    AtualizarGridAgendamentos();
                                }
                                else
                                {
                                    MessageBox.Show("Falha ao agendar!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falha ao obter o ID do horário selecionado.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, selecione um cliente e um serviço válidos.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, preencha todos os campos corretamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Formato de horário inválido!");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um horário.");
            }
        }


        private void AtualizarGridAgendamentos()
        {
            dataGridView1.DataSource = agendamento.ObterAgendamentos();
        }

       
    }

}

