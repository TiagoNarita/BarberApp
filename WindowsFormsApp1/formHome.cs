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
        public formHome()
        {
            InitializeComponent();
        }

        private void formHome_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            FrmCadastro frmCadastro = new FrmCadastro();
            frmCadastro.ShowDialog();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            FrmAtualizar frmAtualizar = new FrmAtualizar();
            frmAtualizar.ShowDialog();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            FrmExcluir frmExcluir = new FrmExcluir();
            frmExcluir.ShowDialog();
        }
    }
}
