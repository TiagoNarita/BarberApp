using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class FormEvento : Form
    {
        String connString = @"server=127.0.0.1;uid=root;pwd=834483Ti;database=bd_calendario;ConnectionTimeout=2";

        public FormEvento()
        {
            InitializeComponent();
            
        }

        private void FormEvento_Load(object sender, EventArgs e)
        {
            txbData.Text = UserControlDays.static_day + "/" + formCalendar.static_month + "/" + formCalendar.static_year;   
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        { 
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            // Convertendo a string de data para o formato correto (YYYY-MM-DD)
            DateTime dataEvento;
            if (DateTime.TryParseExact(txbData.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataEvento))
            {
                String sql = "INSERT INTO Calendario(data_evento, evento) VALUES (@data_evento, @evento)";
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@data_evento", dataEvento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@evento", txbEvento.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Salvo com sucesso!");
                cmd.Dispose();
            }
            else
            {
                MessageBox.Show("Formato de data inválido. Use o formato DD/MM/YYYY.");
            }

            conn.Close();

        }

    }
}

   
