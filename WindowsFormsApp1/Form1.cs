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
        testeForm testeForm;

        //apenas o teste baby
        public Form1()
        {
            InitializeComponent();
        }
        bool menuExpande = true;

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

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
    }
}
