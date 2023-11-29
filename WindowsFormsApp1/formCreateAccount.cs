using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace WindowsFormsApp1
{
    public partial class frmCreateAccount : Form
    {
        public frmCreateAccount()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection(@"server=localhost;port=3306;uid=root;pwd=159482;database=barbagenda");
        
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        String confirmandoTeoria;


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "" && txtConfPassword.Text == "")
            {
                MessageBox.Show("Use" +
                    "Username and Password fields are empty", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == txtConfPassword.Text)
            {
                con.Open();
                string query = "INSERT INTO users (username, passwords) VALUES (@username, @password)";


              
                cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                cmd.ExecuteNonQuery();
                con.Close();

                txtPassword.Text = "";
                txtConfPassword.Text = "";
                txtUsername.Text = "";

                MessageBox.Show("Your Account has been Successfully created", "Registration Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Passwords does not match, Please Re-enter", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtConfPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void checkBxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfPassword.PasswordChar = '*';

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtConfPassword.Text = "";
            txtUsername.Text = "";
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLoguin frmlogin = new frmLoguin();
            frmlogin.ShowDialog();
            this.Close();
        }

        private void frmCreateAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
