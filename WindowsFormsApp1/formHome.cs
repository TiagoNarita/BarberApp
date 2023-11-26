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
    public partial class formHome : Form
    {
        private ArmazenaInfo armazenaInfo;
        public formHome(ArmazenaInfo armazenaInfo)
        {
            InitializeComponent();
            this.armazenaInfo = armazenaInfo;
        }

        private void formHome_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            timer1.Start();

            LblBemVindos.Text = "Bem Vindo " + armazenaInfo.GetNick();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblRelogio.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
