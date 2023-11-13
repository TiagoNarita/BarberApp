using System;
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


namespace WindowsFormsApp1
{
    public partial class frmCreateAccount : Form
    {
        public frmCreateAccount()
        {
            InitializeComponent();
        }

            MySqlConnection con = new MySqlConnection(@"server=localhost;port=3306;uid=root;pwd=834483Ti;database=barbagenda");
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter da = new MySqlDataAdapter();

            private void button1_Click(object sender, EventArgs e)
            {
                if (txtUsername.Text == "" && txtPassword.Text == "" && txtConfPassword.Text == "")
                {
                    MessageBox.Show("Usarname and Password fields are empty", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtPassword.Text == txtPassword.Text)
                {
                    con.Open();
                    string register = "INSERT INTO users VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "')";
                    cmd = new MySqlCommand(register, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Your Account has been Successfully created", "Registration Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Passwords does not match, Please Re-enter", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
    }
}
