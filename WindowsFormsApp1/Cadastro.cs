using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Cadastro
    {
        private string connectionStr;

        //-------------------------------------------------------------------------

        public Cadastro()
        {
            connectionStr = @"server=localhost;port=3306;uid=root;pwd=834483Ti;database=barbagenda;ConnectionTimeout=2";
        }

        //-------------------------------------------------------------------------

        public void inserirCliente(Cliente cliente)
        {
            MySqlConnection connectionBD = null;
            MySqlCommand cmdInsert = null;

            try
            {
                //tenta criar uma conexão com o banco
                connectionBD = new MySqlConnection(connectionStr);

                //abre a conexão com o banco
                connectionBD.Open();

                // Executa um comando INSERT para inserir um registro na tabela 'Funcionario'
                // Como o INSERT não retorna valores, devemos executar o comando 'ExecuteNonQuery'
                cmdInsert = new MySqlCommand();

                //atribui uma conexão ao comando (obrigatório)
                cmdInsert.Connection = connectionBD;

                //seta o comando sql que será executado
                cmdInsert.CommandText = "INSERT INTO clientes (nome, cpf, telefone, email)" +
                                    "VALUES ( @nome, @cpf, @telefone, @email)";

                //seta os parametros que deverão ser passados para a consulta sql
                cmdInsert.Parameters.AddWithValue("nome", cliente.getNome());
                cmdInsert.Parameters.AddWithValue("cpf", cliente.getCPF());
                cmdInsert.Parameters.AddWithValue("telefone", cliente.getTelefone());
                cmdInsert.Parameters.AddWithValue("email", cliente.getEmail());
                

                //executa o comando / consulta sql
                cmdInsert.ExecuteNonQuery();

            }

         
            finally
            {
                //libera a memória utilizada pelos comandos
                if (cmdInsert != null) cmdInsert.Dispose();
                //fecha a conexão com o banco!
                if (connectionBD != null) connectionBD.Close();
            }
        }

        //-------------------------------------------------------------------------

        public Cliente pesquisarClienteNome(string nome)
        {

            MySqlConnection connectionBD = null;
            MySqlCommand cmdSelect = null;
            Cliente cliente = null;

            try
            {
                //tenta criar uma conexão com o banco
                connectionBD = new MySqlConnection(connectionStr);

                //abre a conexão com o banco
                connectionBD.Open();

                // Executa um comando INSERT para inserir um registro na tabela 'Funcionario'
                // Como o INSERT não retorna valores, devemos executar o comando 'ExecuteNonQuery'
                cmdSelect = new MySqlCommand();

                //atribui uma conexão ao comando (obrigatório)
                cmdSelect.Connection = connectionBD;

                //seta o comando sql que será executado
                cmdSelect.CommandText = "SELECT cpf, telefone, email " +
                                        "FROM clientes WHERE nome = @nome";

                //seta os parametros que deverão ser passados para a consulta sql
                cmdSelect.Parameters.AddWithValue("nome", nome);

                MySqlDataReader reader = cmdSelect.ExecuteReader(); //executa o comando que retornará um datareader
                                                                    //para acessar os dados da tabela

                //caso o comando select tenha retornado alguma linha
                if (reader.HasRows)
                {
                    //Lê a primeira linha (o cpf é único para cada funcionário) não é para retornar mais de uma linha!
                    reader.Read();

                    //pega os dados das colunas da linha
                    string cpf = reader.GetString(0);
                    string telefone = reader.GetString(1);
                    string email = reader.GetString(2);
                    

                    //cria um objeto do tipo Funcionario com os dados que vieram do banco!!!
                    cliente = new Cliente(nome, cpf, telefone, email);
                }

                //tenho que fechar o reader após o uso !!!
                reader.Close();

            }
            finally
            {
                //libera a memória utilizada pelos comandos
                if (cmdSelect != null) cmdSelect.Dispose();
                //fecha a conexão com o banco!
                if (connectionBD != null) connectionBD.Close();
            }

            //retorna um objeto funcionario.
            return cliente;
        }

        //-------------------------------------------------------------------------

        //Remove a pessoa do cadastro que possuir um cpf igual ao passado como parâmetro.
        public bool removerClienteNome(string nome)
        {
            //procura um funcionário que possua o cpf igual ao passado como parâmetro
            //caso encontre retorna uma referência para esse funcionário;
            //caso não encontre, retorna null
            Cliente cliente = pesquisarClienteNome(nome);

            //caso encontre uma pessoa
            if (cliente != null)
            {
                MySqlConnection connectionBD = null;
                MySqlCommand cmdDelete = null;

                try
                {
                    //tenta criar uma conexão com o banco
                    connectionBD = new MySqlConnection(connectionStr);

                    //abre a conexão com o banco
                    connectionBD.Open();

                    // Executa um comando INSERT para inserir um registro na tabela 'Funcionario'
                    // Como o INSERT não retorna valores, devemos executar o comando 'ExecuteNonQuery'
                    cmdDelete = new MySqlCommand();

                    //atribui uma conexão ao comando (obrigatório)
                    cmdDelete.Connection = connectionBD;

                    //seta o comando sql que será executado
                    cmdDelete.CommandText = "DELETE FROM clientes " +
                                            "WHERE nome = @nome";

                    //seta os parametros que deverão ser passados para a consulta sql
                    cmdDelete.Parameters.AddWithValue("nome", nome);

                    //executa o comando / consulta sql
                    cmdDelete.ExecuteNonQuery();

                    //indica que conseguiu remover a pessoa
                    return true;

                }
                finally
                {
                    //libera a memória utilizada pelos comandos
                    if (cmdDelete != null) cmdDelete.Dispose();
                    //fecha a conexão com o banco!
                    if (connectionBD != null) connectionBD.Close();
                }

            }
            //caso não encontre o funcionário
            else
            {
                //indica que não conseguiu remover a pessoa
                return false;
            }

        }

        //-------------------------------------------------------------------------

        public bool atualizarCliente(string pesquisanome, Cliente cliente)
        {
            int numLinhasAfetadas = 0;
            MySqlConnection connectionBD = null;
            MySqlCommand cmdUpdate = null;

            try
            {
                //tenta criar uma conexão com o banco
                connectionBD = new MySqlConnection(connectionStr);

                //abre a conexão com o banco
                connectionBD.Open();

                // Executa um comando UPDATE para atualizar um registro na tabela 'Funcionario'
                // Como o UPDATE não retorna valores, devemos executar o comando 'ExecuteNonQuery'
                cmdUpdate = new MySqlCommand();

                //atribui uma conexão ao comando (obrigatório)
                cmdUpdate.Connection = connectionBD;

                //seta o comando sql que será executado
                cmdUpdate.CommandText = "UPDATE clientes SET " +
                        "nome=@nome, " +
                        "telefone=@telefone, " +
                        "email=@email, " +
                        "cpf=@cpf " +
                        "WHERE nome = @pesquisanome";

                //seta os parametros que deverão ser passados para a consulta sql
                cmdUpdate.Parameters.AddWithValue("nome", cliente.getNome());
                cmdUpdate.Parameters.AddWithValue("cpf", cliente.getCPF());
                cmdUpdate.Parameters.AddWithValue("telefone", cliente.getTelefone());
                cmdUpdate.Parameters.AddWithValue("email", cliente.getEmail());             
                cmdUpdate.Parameters.AddWithValue("pesquisanome", pesquisanome);

                //executa o comando / consulta sql
                numLinhasAfetadas = cmdUpdate.ExecuteNonQuery();

            }
            finally
            {
                //libera a memória utilizada pelos comandos
                if (cmdUpdate != null) cmdUpdate.Dispose();
                //fecha a conexão com o banco!
                if (connectionBD != null) connectionBD.Close();
            }

            if (numLinhasAfetadas != 0) return true;
            else return false;
        }


        //-------------------------------------------------------------------------

        public void gerarRelatorioCliente(DataTable table)
        {
            MySqlConnection connectionBD = null;
            MySqlCommand cmdSelect = null;

            try
            {
                //limpa qualquer dado anterior da tabela
                table.Clear();

                //tenta criar uma conexão com o banco
                connectionBD = new MySqlConnection(connectionStr);

                //abre a conexão com o banco
                connectionBD.Open();

               
                cmdSelect = new MySqlCommand();

                //atribui uma conexão ao comando (obrigatório)
                cmdSelect.Connection = connectionBD;

                //seta o comando sql que será executado
                cmdSelect.CommandText = "SELECT nome, cpf, telefone, email FROM clientes";


                MySqlDataReader reader = cmdSelect.ExecuteReader(); //executa o comando que retornará um datareader
                                                                    //para acessar os dados da tabela

                //caso o comando select tenha retornado alguma linha
                if (reader.HasRows)
                {
                    //passa o datareader para a tabela ser inicializada com os seus dados!
                    table.Load(reader);
                }

                //tenho que fechar o reader após o uso !!!
                reader.Close();

            }
            finally
            {
                //libera a memória utilizada pelos comandos
                if (cmdSelect != null) cmdSelect.Dispose();
                //fecha a conexão com o banco!
                if (connectionBD != null) connectionBD.Close();

                //libera os recursos da tabela!
         
            }
        }

        public static class AtualizadorClientes
        {
            public static event EventHandler ClienteCadastrado;

            public static void NotificarClienteCadastrado()
            {
                EventHandler handler = ClienteCadastrado;
                handler?.Invoke(null, EventArgs.Empty);
            }
        }

    }
}
