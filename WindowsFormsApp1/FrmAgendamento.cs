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

        private MySqlConnection connection;
        private string connectionString = (@"server=localhost;port=3306;uid=root;pwd=159482;database=barbagenda");

        public FrmAgendamento()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            LoadData();

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

        private void LoadData()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM users";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable; // Vincula os dados ao DataGridView
                ConfigurarGradeLivros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void ConfigurarGradeLivros()
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 9);
            dataGridView1.RowHeadersWidth = 25;

            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["id"].Visible = false;

            dataGridView1.Columns["username"].HeaderText = "Usuários";
            dataGridView1.Columns["username"].Width = 130;
            dataGridView1.Columns["username"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
         
            dataGridView1.Columns["passwords"].HeaderText = "Book authors";
            dataGridView1.Columns["passwords"].Width = 500;
        }
    }
}
