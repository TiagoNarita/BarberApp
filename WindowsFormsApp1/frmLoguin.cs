using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class frmLoguin : Form
    {
        public frmLoguin()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection(@"server=localhost;port=3306;uid=root;pwd=834483Ti;database=barbagenda");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "SELECT * FROM users WHERE username = @username and passwords = @passwords";
            cmd = new MySqlCommand(login, con);

            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@passwords", txtPassword.Text);

            MySqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read() == true)
            {
                new Form1().Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try again", "Login Failed", MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtUsername.Text = "";
                txtUsername.Focus();
                con.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
            txtUsername.Focus();
        }

        private void checkBxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            new frmCreateAccount().Show();
            this.Hide();
        }
    }
}
