namespace WindowsFormsApp1
{
    partial class PokerTexas
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
            this.lblNomiSoldi2 = new System.Windows.Forms.Label();
            this.btnFold3 = new System.Windows.Forms.Button();
            this.btnFold1 = new System.Windows.Forms.Button();
            this.btnFold2 = new System.Windows.Forms.Button();
            this.pnlGiocatore1 = new System.Windows.Forms.Panel();
            this.lblCarte1 = new System.Windows.Forms.Label();
            this.lblNomiSoldi1 = new System.Windows.Forms.Label();
            this.btnPunta1 = new System.Windows.Forms.Button();
            this.btnPunta2 = new System.Windows.Forms.Button();
            this.pnlCarteComuni = new System.Windows.Forms.Panel();
            this.lblNomiSoldi3 = new System.Windows.Forms.Label();
            this.btnPunta3 = new System.Windows.Forms.Button();
            this.pnlGiocatore2 = new System.Windows.Forms.Panel();
            this.lblCarte2 = new System.Windows.Forms.Label();
            this.pnlGiocatore3 = new System.Windows.Forms.Panel();
            this.lblCarte3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnFaseSuccessiva = new System.Windows.Forms.Button();
            this.btnMostraVincitore = new System.Windows.Forms.Button();
            this.lblPiatto = new System.Windows.Forms.Label();
            this.pnlGiocatore1.SuspendLayout();
            this.pnlGiocatore2.SuspendLayout();
            this.pnlGiocatore3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNomiSoldi2
            // 
            this.lblNomiSoldi2.AutoSize = true;
            this.lblNomiSoldi2.Location = new System.Drawing.Point(12, 62);
            this.lblNomiSoldi2.Name = "lblNomiSoldi2";
            this.lblNomiSoldi2.Size = new System.Drawing.Size(0, 13);
            this.lblNomiSoldi2.TabIndex = 0;
            // 
            // btnFold3
            // 
            this.btnFold3.Enabled = false;
            this.btnFold3.Location = new System.Drawing.Point(96, 86);
            this.btnFold3.Name = "btnFold3";
            this.btnFold3.Size = new System.Drawing.Size(75, 23);
            this.btnFold3.TabIndex = 1;
            this.btnFold3.Tag = "2";
            this.btnFold3.Text = "Fold";
            this.btnFold3.UseVisualStyleBackColor = true;
            this.btnFold3.Click += new System.EventHandler(this.btnFold3_Click);
            // 
            // btnFold1
            // 
            this.btnFold1.Enabled = false;
            this.btnFold1.Location = new System.Drawing.Point(96, 86);
            this.btnFold1.Name = "btnFold1";
            this.btnFold1.Size = new System.Drawing.Size(75, 23);
            this.btnFold1.TabIndex = 2;
            this.btnFold1.Tag = "0";
            this.btnFold1.Text = "Fold";
            this.btnFold1.UseVisualStyleBackColor = true;
            this.btnFold1.Click += new System.EventHandler(this.btnFold1_Click);
            // 
            // btnFold2
            // 
            this.btnFold2.Enabled = false;
            this.btnFold2.Location = new System.Drawing.Point(96, 86);
            this.btnFold2.Name = "btnFold2";
            this.btnFold2.Size = new System.Drawing.Size(75, 23);
            this.btnFold2.TabIndex = 3;
            this.btnFold2.Tag = "1";
            this.btnFold2.Text = "Fold";
            this.btnFold2.UseVisualStyleBackColor = true;
            this.btnFold2.Click += new System.EventHandler(this.btnFold2_Click);
            // 
            // pnlGiocatore1
            // 
            this.pnlGiocatore1.Controls.Add(this.lblCarte1);
            this.pnlGiocatore1.Controls.Add(this.lblNomiSoldi1);
            this.pnlGiocatore1.Controls.Add(this.btnFold1);
            this.pnlGiocatore1.Controls.Add(this.btnPunta1);
            this.pnlGiocatore1.Location = new System.Drawing.Point(12, 40);
            this.pnlGiocatore1.Name = "pnlGiocatore1";
            this.pnlGiocatore1.Size = new System.Drawing.Size(294, 139);
            this.pnlGiocatore1.TabIndex = 4;
            // 
            // lblCarte1
            // 
            this.lblCarte1.AutoSize = true;
            this.lblCarte1.Location = new System.Drawing.Point(26, 27);
            this.lblCarte1.Name = "lblCarte1";
            this.lblCarte1.Size = new System.Drawing.Size(0, 13);
            this.lblCarte1.TabIndex = 12;
            // 
            // lblNomiSoldi1
            // 
            this.lblNomiSoldi1.AutoSize = true;
            this.lblNomiSoldi1.Location = new System.Drawing.Point(12, 62);
            this.lblNomiSoldi1.Name = "lblNomiSoldi1";
            this.lblNomiSoldi1.Size = new System.Drawing.Size(0, 13);
            this.lblNomiSoldi1.TabIndex = 11;
            // 
            // btnPunta1
            // 
            this.btnPunta1.Enabled = false;
            this.btnPunta1.Location = new System.Drawing.Point(15, 86);
            this.btnPunta1.Name = "btnPunta1";
            this.btnPunta1.Size = new System.Drawing.Size(75, 23);
            this.btnPunta1.TabIndex = 10;
            this.btnPunta1.Tag = "0";
            this.btnPunta1.Text = "Punta 100";
            this.btnPunta1.UseVisualStyleBackColor = true;
            this.btnPunta1.Click += new System.EventHandler(this.btnPunta1_Click);
            // 
            // btnPunta2
            // 
            this.btnPunta2.Enabled = false;
            this.btnPunta2.Location = new System.Drawing.Point(15, 86);
            this.btnPunta2.Name = "btnPunta2";
            this.btnPunta2.Size = new System.Drawing.Size(75, 23);
            this.btnPunta2.TabIndex = 6;
            this.btnPunta2.Tag = "1";
            this.btnPunta2.Text = "Punta 100";
            this.btnPunta2.UseVisualStyleBackColor = true;
            this.btnPunta2.Click += new System.EventHandler(this.btnPunta2_Click);
            // 
            // pnlCarteComuni
            // 
            this.pnlCarteComuni.Location = new System.Drawing.Point(342, 40);
            this.pnlCarteComuni.Name = "pnlCarteComuni";
            this.pnlCarteComuni.Size = new System.Drawing.Size(539, 139);
            this.pnlCarteComuni.TabIndex = 7;
            // 
            // lblNomiSoldi3
            // 
            this.lblNomiSoldi3.AutoSize = true;
            this.lblNomiSoldi3.Location = new System.Drawing.Point(12, 62);
            this.lblNomiSoldi3.Name = "lblNomiSoldi3";
            this.lblNomiSoldi3.Size = new System.Drawing.Size(0, 13);
            this.lblNomiSoldi3.TabIndex = 8;
            // 
            // btnPunta3
            // 
            this.btnPunta3.Enabled = false;
            this.btnPunta3.Location = new System.Drawing.Point(15, 86);
            this.btnPunta3.Name = "btnPunta3";
            this.btnPunta3.Size = new System.Drawing.Size(75, 23);
            this.btnPunta3.TabIndex = 9;
            this.btnPunta3.Tag = "2";
            this.btnPunta3.Text = "Punta 100";
            this.btnPunta3.UseVisualStyleBackColor = true;
            this.btnPunta3.Click += new System.EventHandler(this.btnPunta3_Click);
            // 
            // pnlGiocatore2
            // 
            this.pnlGiocatore2.Controls.Add(this.lblCarte2);
            this.pnlGiocatore2.Controls.Add(this.lblNomiSoldi2);
            this.pnlGiocatore2.Controls.Add(this.btnFold2);
            this.pnlGiocatore2.Controls.Add(this.btnPunta2);
            this.pnlGiocatore2.Location = new System.Drawing.Point(12, 185);
            this.pnlGiocatore2.Name = "pnlGiocatore2";
            this.pnlGiocatore2.Size = new System.Drawing.Size(294, 139);
            this.pnlGiocatore2.TabIndex = 5;
            // 
            // lblCarte2
            // 
            this.lblCarte2.AutoSize = true;
            this.lblCarte2.Location = new System.Drawing.Point(26, 27);
            this.lblCarte2.Name = "lblCarte2";
            this.lblCarte2.Size = new System.Drawing.Size(0, 13);
            this.lblCarte2.TabIndex = 7;
            // 
            // pnlGiocatore3
            // 
            this.pnlGiocatore3.Controls.Add(this.lblCarte3);
            this.pnlGiocatore3.Controls.Add(this.lblNomiSoldi3);
            this.pnlGiocatore3.Controls.Add(this.btnPunta3);
            this.pnlGiocatore3.Controls.Add(this.btnFold3);
            this.pnlGiocatore3.Location = new System.Drawing.Point(12, 330);
            this.pnlGiocatore3.Name = "pnlGiocatore3";
            this.pnlGiocatore3.Size = new System.Drawing.Size(294, 139);
            this.pnlGiocatore3.TabIndex = 5;
            // 
            // lblCarte3
            // 
            this.lblCarte3.AutoSize = true;
            this.lblCarte3.Location = new System.Drawing.Point(26, 27);
            this.lblCarte3.Name = "lblCarte3";
            this.lblCarte3.Size = new System.Drawing.Size(0, 13);
            this.lblCarte3.TabIndex = 10;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(342, 185);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(98, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Distribuisci";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnFaseSuccessiva
            // 
            this.btnFaseSuccessiva.Enabled = false;
            this.btnFaseSuccessiva.Location = new System.Drawing.Point(342, 214);
            this.btnFaseSuccessiva.Name = "btnFaseSuccessiva";
            this.btnFaseSuccessiva.Size = new System.Drawing.Size(98, 23);
            this.btnFaseSuccessiva.TabIndex = 11;
            this.btnFaseSuccessiva.Text = "Fase successiva";
            this.btnFaseSuccessiva.UseVisualStyleBackColor = true;
            this.btnFaseSuccessiva.Click += new System.EventHandler(this.btnFaseSuccessiva_Click);
            // 
            // btnMostraVincitore
            // 
            this.btnMostraVincitore.Location = new System.Drawing.Point(446, 195);
            this.btnMostraVincitore.Name = "btnMostraVincitore";
            this.btnMostraVincitore.Size = new System.Drawing.Size(97, 31);
            this.btnMostraVincitore.TabIndex = 12;
            this.btnMostraVincitore.Text = "Mostra vincitore";
            this.btnMostraVincitore.UseVisualStyleBackColor = true;
            this.btnMostraVincitore.Visible = false;
            this.btnMostraVincitore.Click += new System.EventHandler(this.btnMostraVincitore_Click);
            // 
            // lblPiatto
            // 
            this.lblPiatto.AutoSize = true;
            this.lblPiatto.Location = new System.Drawing.Point(440, 270);
            this.lblPiatto.Name = "lblPiatto";
            this.lblPiatto.Size = new System.Drawing.Size(0, 13);
            this.lblPiatto.TabIndex = 13;
            // 
            // PokerTexas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 519);
            this.Controls.Add(this.lblPiatto);
            this.Controls.Add(this.btnMostraVincitore);
            this.Controls.Add(this.btnFaseSuccessiva);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pnlGiocatore3);
            this.Controls.Add(this.pnlGiocatore2);
            this.Controls.Add(this.pnlCarteComuni);
            this.Controls.Add(this.pnlGiocatore1);
            this.Name = "PokerTexas";
            this.Text = "PokerTexas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PokerTexas_FormClosing);
            this.Load += new System.EventHandler(this.PokerTexas_Load);
            this.pnlGiocatore1.ResumeLayout(false);
            this.pnlGiocatore1.PerformLayout();
            this.pnlGiocatore2.ResumeLayout(false);
            this.pnlGiocatore2.PerformLayout();
            this.pnlGiocatore3.ResumeLayout(false);
            this.pnlGiocatore3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomiSoldi2;
        private System.Windows.Forms.Button btnFold3;
        private System.Windows.Forms.Button btnFold1;
        private System.Windows.Forms.Button btnFold2;
        private System.Windows.Forms.Panel pnlGiocatore1;
        private System.Windows.Forms.Button btnPunta2;
        private System.Windows.Forms.Panel pnlCarteComuni;
        private System.Windows.Forms.Label lblNomiSoldi3;
        private System.Windows.Forms.Button btnPunta3;
        private System.Windows.Forms.Button btnPunta1;
        private System.Windows.Forms.Label lblNomiSoldi1;
        private System.Windows.Forms.Panel pnlGiocatore2;
        private System.Windows.Forms.Panel pnlGiocatore3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnFaseSuccessiva;
        private System.Windows.Forms.Button btnMostraVincitore;
        private System.Windows.Forms.Label lblPiatto;
        private System.Windows.Forms.Label lblCarte1;
        private System.Windows.Forms.Label lblCarte2;
        private System.Windows.Forms.Label lblCarte3;
    }
}