using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//teste2
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        formDashboard dashboard;
        formHome formHome;
        formCalendar formCalendar;
        FrmCadastro FrmCadastro;
        FrmAgendamento FrmAgendamento;
        Cadastro cadastro;
        frmLoguin frmLoguin;

        ArmazenaInfo armazenaInfo;
        public Form1(ArmazenaInfo armazenaInfo)
        {
            InitializeComponent();

            if (formHome == null)
            {
                this.armazenaInfo = armazenaInfo;
                formHome = new formHome(armazenaInfo);
                formHome.FormClosed += Home_FormClosed;
                formHome.MdiParent = this;
                formHome.Dock = DockStyle.Fill;
                formHome.Show();
            }
            else
            {
                formHome.Activate();
            }
        }
        bool menuExpande = true;    

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpande)
            {
                menu.Width -= 10;
                if (menu.Width <= 70)
                {
                    menuExpande = false;
                    sideBarTransition.Stop();

                    panelhome.Width = menu.Width;
                    panelDashboard.Width = menu.Width;
                    panelCalendar.Width = menu.Width;
                }
            }else
            {
                menu.Width += 10;
                if (menu.Width >= 180)
                {
                    menuExpande = true;
                    sideBarTransition.Stop();

                    panelhome.Width = menu.Width;
                    panelDashboard.Width = menu.Width;
                    panelCalendar.Width = menu.Width;

                }
            }
            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            sideBarTransition.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dashboard == null)
            {
                dashboard = new formDashboard();
                dashboard.FormClosed += Dashbord_FormClosed;
                dashboard.MdiParent = this;
                dashboard.Dock = DockStyle.Fill;
                dashboard.Show();
            }
            else
            {
                dashboard.Activate();
            }
        }

        private void Dashbord_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard = null;
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            formHome = null;
        }
        private void Calendar_FormClosed(object sender, FormClosedEventArgs e)
        {
            formCalendar = null;
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            if (formHome == null)
            {
                formHome = new formHome(armazenaInfo);
                formHome.FormClosed += Home_FormClosed;
                formHome.MdiParent = this;
                formHome.Dock = DockStyle.Fill;
                formHome.Show();
            }
            else
            {
                formHome.Activate();
            }
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            if (formCalendar == null)
            {
                formCalendar = new formCalendar();
                formCalendar.FormClosed += Calendar_FormClosed;
                formCalendar.MdiParent = this;
                formCalendar.Dock = DockStyle.Fill;
                formCalendar.Show();
            }
            else
            {
                formCalendar.Activate();
            }
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            
            if (FrmCadastro == null)
            {
                FrmCadastro = new FrmCadastro(cadastro);
                FrmCadastro.FormClosed += Home_FormClosed;
                FrmCadastro.MdiParent = this;
                FrmCadastro.Dock = DockStyle.Fill;
                FrmCadastro.Show();
            }
            else
            {
                FrmCadastro.Activate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgendamento_Click(object sender, EventArgs e)
        {
            if (FrmAgendamento == null)
            {
                FrmAgendamento = new FrmAgendamento();
                FrmAgendamento.FormClosed += Home_FormClosed;
                FrmAgendamento.MdiParent = this;
                FrmAgendamento.Dock = DockStyle.Fill;
                FrmAgendamento.Show();
            }
            else
            {
                FrmAgendamento.Activate();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLoguin frmLoguin = new frmLoguin();
            frmLoguin.ShowDialog();
            this.Close();
        }
    }
}
