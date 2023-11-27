namespace WindowsFormsApp1
{
    partial class FrmCadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCadastar = new System.Windows.Forms.Button();
            this.txbIdade = new System.Windows.Forms.TextBox();
            this.txbTelefone = new System.Windows.Forms.TextBox();
            this.txbCPF = new System.Windows.Forms.TextBox();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Location = new System.Drawing.Point(254, 114);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(144, 45);
            this.btnCancelar.TabIndex = 27;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCadastar
            // 
            this.btnCadastar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastar.Location = new System.Drawing.Point(254, 50);
            this.btnCadastar.Name = "btnCadastar";
            this.btnCadastar.Size = new System.Drawing.Size(144, 45);
            this.btnCadastar.TabIndex = 26;
            this.btnCadastar.Text = "Cadastar";
            this.btnCadastar.UseVisualStyleBackColor = true;
            this.btnCadastar.Click += new System.EventHandler(this.btnCadastar_Click);
            // 
            // txbIdade
            // 
            this.txbIdade.Location = new System.Drawing.Point(135, 125);
            this.txbIdade.Name = "txbIdade";
            this.txbIdade.Size = new System.Drawing.Size(100, 22);
            this.txbIdade.TabIndex = 23;
            // 
            // txbTelefone
            // 
            this.txbTelefone.Location = new System.Drawing.Point(135, 87);
            this.txbTelefone.Name = "txbTelefone";
            this.txbTelefone.Size = new System.Drawing.Size(100, 22);
            this.txbTelefone.TabIndex = 22;
            // 
            // txbCPF
            // 
            this.txbCPF.Location = new System.Drawing.Point(135, 47);
            this.txbCPF.Name = "txbCPF";
            this.txbCPF.Size = new System.Drawing.Size(100, 22);
            this.txbCPF.TabIndex = 21;
            // 
            // txbNome
            // 
            this.txbNome.Location = new System.Drawing.Point(135, 12);
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(263, 22);
            this.txbNome.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "CPF:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Telefone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Idade:";
            // 
            // FrmCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 168);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastar);
            this.Controls.Add(this.txbIdade);
            this.Controls.Add(this.txbTelefone);
            this.Controls.Add(this.txbCPF);
            this.Controls.Add(this.txbNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCadastro";
            this.Text = "FrmCadastro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCadastar;
        private System.Windows.Forms.TextBox txbIdade;
        private System.Windows.Forms.TextBox txbTelefone;
        private System.Windows.Forms.TextBox txbCPF;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}