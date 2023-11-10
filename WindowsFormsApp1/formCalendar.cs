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

namespace WindowsFormsApp1
{
    public partial class formCalendar : Form
    {
        int year, month;
        public formCalendar()
        {
            InitializeComponent();
        }

        private void formCalendar_Load(object sender, EventArgs e)
        {
            try
            {
                displayDays();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private void displayDays()
        {
            DateTime now = DateTime.Now;

            month = now.Month;
            year = now.Year;

            string nomeMes = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbData.Text = nomeMes + " " + year;

            //pegando o primeiro dia do mes
            DateTime startofMonth = new DateTime(year,month, 1);


            //contagem dos dias do mes
            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofMonth.DayOfWeek.ToString("d"));

            //Criando controle de usuário
            for (int i = 0; i < dayoftheweek; i++) 
            {
                UserControl1 ucblank = new UserControl1();
                dayContainer.Controls.Add(ucblank);
            }

            for(int i = 1;i < days; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);
                dayContainer.Controls.Add(ucDays);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();

            month--;

            string nomeMes = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbData.Text = nomeMes + " " + year;

            DateTime startofMonth = new DateTime(year, month, 1);


            //contagem dos dias do mes
            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofMonth.DayOfWeek.ToString("d"));

            //Criando controle de usuário
            for (int i = 0; i < dayoftheweek; i++)
            {
                UserControl1 ucblank = new UserControl1();
                dayContainer.Controls.Add(ucblank);
            }

            for (int i = 1; i < days; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);
                dayContainer.Controls.Add(ucDays);
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            //limpar container
            dayContainer.Controls.Clear();

            month++;

            string nomeMes = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbData.Text = nomeMes + " " + year;

            DateTime startofMonth = new DateTime(year, month, 1);


            //contagem dos dias do mes
            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofMonth.DayOfWeek.ToString("d"));

            //Criando controle de usuário
            for (int i = 0; i < dayoftheweek; i++)
            {
                UserControl1 ucblank = new UserControl1();
                dayContainer.Controls.Add(ucblank);
            }

            for (int i = 1; i < days; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);
                dayContainer.Controls.Add(ucDays);
            }
        }
    }
}
