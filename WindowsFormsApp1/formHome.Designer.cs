namespace WindowsFormsApp1
{
    partial class formHome
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblRelogio = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LblBemVindos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.Post_Instagram_Barbearia_Corte_de_Cabelo__1_;
            this.pictureBox1.Location = new System.Drawing.Point(-69, -134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(812, 658);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblRelogio
            // 
            this.lblRelogio.AutoSize = true;
            this.lblRelogio.BackColor = System.Drawing.Color.Black;
            this.lblRelogio.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelogio.ForeColor = System.Drawing.Color.White;
            this.lblRelogio.Location = new System.Drawing.Point(543, 447);
            this.lblRelogio.Name = "lblRelogio";
            this.lblRelogio.Size = new System.Drawing.Size(71, 20);
            this.lblRelogio.TabIndex = 1;
            this.lblRelogio.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LblBemVindos
            // 
            this.LblBemVindos.AutoSize = true;
            this.LblBemVindos.BackColor = System.Drawing.Color.Black;
            this.LblBemVindos.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBemVindos.ForeColor = System.Drawing.Color.White;
            this.LblBemVindos.Location = new System.Drawing.Point(24, 20);
            this.LblBemVindos.Name = "LblBemVindos";
            this.LblBemVindos.Size = new System.Drawing.Size(94, 21);
            this.LblBemVindos.TabIndex = 2;
            this.LblBemVindos.Text = "Bem Vindo";
            // 
            // formHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 492);
            this.Controls.Add(this.LblBemVindos);
            this.Controls.Add(this.lblRelogio);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formHome";
            this.Text = "formHome";
            this.Load += new System.EventHandler(this.formHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblRelogio;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LblBemVindos;
    }
}