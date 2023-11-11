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
    public partial class Form1 : Form
    {
        formDashboard dashboard;
        formHome formHome;
        formCalendar formCalendar;
        

        public Form1()
        {
            InitializeComponent();
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

        private void home_Click(object sender, EventArgs e)
        {
            if (formHome == null)
            {
                formHome = new formHome();
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

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            formHome = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (formCalendar == null)
            {
                formCalendar = new formCalendar();
                formCalendar.FormClosed += Home_FormClosed;
                formCalendar.MdiParent = this;
                formCalendar.Dock = DockStyle.Fill;
                formCalendar.Show();
            }
            else
            {
                formCalendar.Activate();
            }
        }
    }
}
