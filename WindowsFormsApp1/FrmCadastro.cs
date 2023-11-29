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
    public partial class FrmCadastro : Form
    {
        private Cadastro cadastro;
        public FrmCadastro()
        {
            InitializeComponent();
        }
        private void FrmCadastro_Load(object sender, EventArgs e)
        {
            cadastro = new Cadastro();
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FrmCadastrar frmCadastrar = new FrmCadastrar(cadastro);
            frmCadastrar.ShowDialog();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FrmPesquisar frmPesquisar = new FrmPesquisar(cadastro);
            frmPesquisar.ShowDialog();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            FrmAlterar frmAlterar = new FrmAlterar(cadastro);  
            frmAlterar.ShowDialog();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            FrmExcluir frmExcluir = new FrmExcluir(cadastro);
            frmExcluir.ShowDialog();
        }

       
    }
}
