using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ServicoId { get; set; }
        public DateTime DataAtendimento { get; set; }
        public TimeSpan Horario { get; set; }

        private string connectionString;

        public Agendamento()
        {
            connectionString = @"server=localhost;port=3306;uid=root;pwd=159482;database=barbagenda;ConnectionTimeout=2";
        }

        public List<Tuple<int, string>> ObterNomesClientes()
        {
            List<Tuple<int, string>> nomesClientes = new List<Tuple<int, string>>();
            string query = "SELECT id, nome FROM Clientes";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string nome = reader["nome"].ToString();
                            nomesClientes.Add(new Tuple<int, string>(id, nome));
                        }
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erro ao obter nomes de clientes: " + e.Message);
                    throw; // ou faça o tratamento adequado da exceção
                }
            }

            return nomesClientes;
        }

        public List<string> ObterNomesServicos()
        {
            List<string> nomesServicos = new List<string>();
            string query = "SELECT Nome FROM Servico";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nomesServicos.Add(reader["Nome"].ToString());
                        }
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erro ao obter nomes de serviços: " + e.Message);
                    throw; // ou faça o tratamento adequado da exceção
                }
            }

            return nomesServicos;
        }

        public bool Agendar(int idCliente, int idServico, DateTime dataAtendimento, int idHorario)
        {
            string query = "INSERT INTO Agendamentos (cliente_id, servico_id, data_atendimento, horario_id) VALUES (@cliente_id, @servico_id, @data_atendimento, @horario_id)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@cliente_id", idCliente);
                command.Parameters.AddWithValue("@servico_id", idServico);
                command.Parameters.AddWithValue("@data_atendimento", dataAtendimento);
                command.Parameters.AddWithValue("@horario_id", idHorario);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Retorna true se a inserção for bem-sucedida
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erro ao agendar: " + e.Message);
                    throw;
                }
            }
        }
    

        public decimal ObterValorServico(string nomeServico)
        {
            string query = "SELECT Preco FROM Servico WHERE Nome = @Nome";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nome", nomeServico);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && decimal.TryParse(result.ToString(), out decimal preco))
                    {
                        return preco;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erro ao obter valor do serviço: " + e.Message);
                    throw; // ou faça o tratamento adequado da exceção
                }
                catch (Exception e)
                {
                    // Tratamento de outras exceções
                    MessageBox.Show("Erro desconhecido: " + e.Message, "ERRO Desconhecido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return 0; // Retorna 0 se não encontrar o valor do serviço
        }

        public int ObterIdServico(string nomeServico)
        {
            string query = "SELECT id FROM Servico WHERE Nome = @Nome";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nome", nomeServico);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        return id;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erro ao obter ID do serviço: " + e.Message);
                    throw; // ou faça o tratamento adequado da exceção
                }
            }

            return 0; // Retorna 0 se não encontrar o ID do serviço
        }

        public List<Agendamento> ObterAgendamentos()
        {
            List<Agendamento> agendamentos = new List<Agendamento>();
            string query = "SELECT id, cliente_id, servico_id, data_atendimento, horario FROM Agendamentos";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Agendamento agendamento = new Agendamento
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                ClienteId = Convert.ToInt32(reader["cliente_id"]),
                                ServicoId = Convert.ToInt32(reader["servico_id"]),
                                DataAtendimento = Convert.ToDateTime(reader["data_atendimento"]),
                                Horario = TimeSpan.Parse(reader["horario"].ToString()) // Convertendo para TimeSpan
                            };
                            agendamentos.Add(agendamento);
                        }
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erro ao obter agendamentos: " + e.Message);
                    throw; // ou faça o tratamento adequado da exceção
                }

                catch (Exception e)
                {
                    // Tratamento de outras exceções
                    MessageBox.Show("Erro desconhecido: " + e.Message, "ERRO Desconhecido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return agendamentos;
        }

        public List<TimeSpan> ObterHorariosDisponiveis()
        {
            List<TimeSpan> horariosDisponiveis = new List<TimeSpan>();
            string query = "SELECT horario FROM HorariosDisponiveis";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TimeSpan horario = TimeSpan.Parse(reader["horario"].ToString());
                            horariosDisponiveis.Add(horario);
                        }
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erro ao obter horários disponíveis: " + e.Message);
                    throw; // ou faça o tratamento adequado da exceção
                }
            }

            return horariosDisponiveis;
        }

        public List<int> ObterIdsHorariosDisponiveis()
        {
            List<int> idsHorariosDisponiveis = new List<int>();
            string query = "SELECT id FROM HorariosDisponiveis";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idHorario = Convert.ToInt32(reader["id"]);
                            idsHorariosDisponiveis.Add(idHorario);
                        }
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erro ao obter IDs de horários disponíveis: " + e.Message);
                    throw; // ou faça o tratamento adequado da exceção
                }
            }

            return idsHorariosDisponiveis;
        }

        public int ObterIdHorarioSelecionado(string horarioSelecionado)
        {
            string query = "SELECT id FROM HorariosDisponiveis WHERE horario = @HorarioSelecionado";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@HorarioSelecionado", TimeSpan.ParseExact(horarioSelecionado, @"hh\:mm", null));

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        return id;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erro ao obter ID do horário selecionado: " + e.Message);
                    throw; // ou faça o tratamento adequado da exceção
                }
            }

            return 0; // Retorna 0 se não encontrar o ID do horário selecionado
        }


    }

}

