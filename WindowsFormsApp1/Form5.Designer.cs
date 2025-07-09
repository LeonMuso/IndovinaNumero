namespace WindowsFormsApp1
{
    partial class MenuLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuLog));
            this.LblSbloccaLucchetto = new System.Windows.Forms.Label();
            this.LblCampoMinato = new System.Windows.Forms.Label();
            this.LblIndovinaIlNumero = new System.Windows.Forms.Label();
            this.LblBOMB = new System.Windows.Forms.Label();
            this.LblPoker = new System.Windows.Forms.Label();
            this.BtnEsci = new System.Windows.Forms.Button();
            this.PcBPoker = new System.Windows.Forms.PictureBox();
            this.PcBNumero = new System.Windows.Forms.PictureBox();
            this.PcBLucchetto = new System.Windows.Forms.PictureBox();
            this.PcBCampoMinato = new System.Windows.Forms.PictureBox();
            this.PcBBOMB = new System.Windows.Forms.PictureBox();
            this.LblSingle = new System.Windows.Forms.Label();
            this.LblMultiPlayer = new System.Windows.Forms.Label();
            this.LblUtente = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PcBPoker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBNumero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBLucchetto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBCampoMinato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBBOMB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblSbloccaLucchetto
            // 
            this.LblSbloccaLucchetto.AutoSize = true;
            this.LblSbloccaLucchetto.Location = new System.Drawing.Point(132, 159);
            this.LblSbloccaLucchetto.Name = "LblSbloccaLucchetto";
            this.LblSbloccaLucchetto.Size = new System.Drawing.Size(100, 13);
            this.LblSbloccaLucchetto.TabIndex = 0;
            this.LblSbloccaLucchetto.Text = "Sblocca il lucchetto";
            // 
            // LblCampoMinato
            // 
            this.LblCampoMinato.AutoSize = true;
            this.LblCampoMinato.Location = new System.Drawing.Point(272, 159);
            this.LblCampoMinato.Name = "LblCampoMinato";
            this.LblCampoMinato.Size = new System.Drawing.Size(74, 13);
            this.LblCampoMinato.TabIndex = 1;
            this.LblCampoMinato.Text = "Campo minato";
            // 
            // LblIndovinaIlNumero
            // 
            this.LblIndovinaIlNumero.AutoSize = true;
            this.LblIndovinaIlNumero.Location = new System.Drawing.Point(9, 159);
            this.LblIndovinaIlNumero.Name = "LblIndovinaIlNumero";
            this.LblIndovinaIlNumero.Size = new System.Drawing.Size(93, 13);
            this.LblIndovinaIlNumero.TabIndex = 2;
            this.LblIndovinaIlNumero.Text = "Indovina il numero";
            // 
            // LblBOMB
            // 
            this.LblBOMB.AutoSize = true;
            this.LblBOMB.Location = new System.Drawing.Point(567, 284);
            this.LblBOMB.Name = "LblBOMB";
            this.LblBOMB.Size = new System.Drawing.Size(50, 13);
            this.LblBOMB.TabIndex = 3;
            this.LblBOMB.Text = "B.O.M.B.";
            // 
            // LblPoker
            // 
            this.LblPoker.AutoSize = true;
            this.LblPoker.Location = new System.Drawing.Point(36, 325);
            this.LblPoker.Name = "LblPoker";
            this.LblPoker.Size = new System.Drawing.Size(35, 13);
            this.LblPoker.TabIndex = 4;
            this.LblPoker.Text = "Poker";
            // 
            // BtnEsci
            // 
            this.BtnEsci.Location = new System.Drawing.Point(12, 415);
            this.BtnEsci.Name = "BtnEsci";
            this.BtnEsci.Size = new System.Drawing.Size(75, 23);
            this.BtnEsci.TabIndex = 5;
            this.BtnEsci.Text = "Esci";
            this.BtnEsci.UseVisualStyleBackColor = true;
            this.BtnEsci.Click += new System.EventHandler(this.BtnEsci_Click);
            // 
            // PcBPoker
            // 
            this.PcBPoker.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PcBPoker.BackgroundImage")));
            this.PcBPoker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PcBPoker.Location = new System.Drawing.Point(5, 225);
            this.PcBPoker.Name = "PcBPoker";
            this.PcBPoker.Size = new System.Drawing.Size(100, 97);
            this.PcBPoker.TabIndex = 6;
            this.PcBPoker.TabStop = false;
            this.PcBPoker.Click += new System.EventHandler(this.PcBPoker_Click);
            // 
            // PcBNumero
            // 
            this.PcBNumero.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PcBNumero.BackgroundImage")));
            this.PcBNumero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PcBNumero.Location = new System.Drawing.Point(5, 59);
            this.PcBNumero.Name = "PcBNumero";
            this.PcBNumero.Size = new System.Drawing.Size(100, 97);
            this.PcBNumero.TabIndex = 7;
            this.PcBNumero.TabStop = false;
            this.PcBNumero.Click += new System.EventHandler(this.PcBNumero_Click);
            // 
            // PcBLucchetto
            // 
            this.PcBLucchetto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PcBLucchetto.BackgroundImage")));
            this.PcBLucchetto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PcBLucchetto.Location = new System.Drawing.Point(132, 59);
            this.PcBLucchetto.Name = "PcBLucchetto";
            this.PcBLucchetto.Size = new System.Drawing.Size(100, 97);
            this.PcBLucchetto.TabIndex = 8;
            this.PcBLucchetto.TabStop = false;
            this.PcBLucchetto.Click += new System.EventHandler(this.PcBLucchetto_Click);
            // 
            // PcBCampoMinato
            // 
            this.PcBCampoMinato.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PcBCampoMinato.BackgroundImage")));
            this.PcBCampoMinato.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PcBCampoMinato.Location = new System.Drawing.Point(258, 59);
            this.PcBCampoMinato.Name = "PcBCampoMinato";
            this.PcBCampoMinato.Size = new System.Drawing.Size(100, 97);
            this.PcBCampoMinato.TabIndex = 9;
            this.PcBCampoMinato.TabStop = false;
            this.PcBCampoMinato.Click += new System.EventHandler(this.PcBCampoMinato_Click);
            // 
            // PcBBOMB
            // 
            this.PcBBOMB.Location = new System.Drawing.Point(501, 111);
            this.PcBBOMB.Name = "PcBBOMB";
            this.PcBBOMB.Size = new System.Drawing.Size(182, 170);
            this.PcBBOMB.TabIndex = 10;
            this.PcBBOMB.TabStop = false;
            this.PcBBOMB.Click += new System.EventHandler(this.PcBBOMB_Click);
            // 
            // LblSingle
            // 
            this.LblSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSingle.Location = new System.Drawing.Point(1, 15);
            this.LblSingle.Name = "LblSingle";
            this.LblSingle.Size = new System.Drawing.Size(368, 41);
            this.LblSingle.TabIndex = 11;
            this.LblSingle.Text = "SinglePlayer";
            this.LblSingle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblMultiPlayer
            // 
            this.LblMultiPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMultiPlayer.Location = new System.Drawing.Point(5, 181);
            this.LblMultiPlayer.Name = "LblMultiPlayer";
            this.LblMultiPlayer.Size = new System.Drawing.Size(368, 41);
            this.LblMultiPlayer.TabIndex = 12;
            this.LblMultiPlayer.Text = "MultiPlayer";
            this.LblMultiPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblUtente
            // 
            this.LblUtente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUtente.Location = new System.Drawing.Point(570, 12);
            this.LblUtente.Name = "LblUtente";
            this.LblUtente.Size = new System.Drawing.Size(190, 44);
            this.LblUtente.TabIndex = 13;
            this.LblUtente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(757, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 44);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // MenuLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LblUtente);
            this.Controls.Add(this.LblMultiPlayer);
            this.Controls.Add(this.LblSingle);
            this.Controls.Add(this.PcBBOMB);
            this.Controls.Add(this.PcBCampoMinato);
            this.Controls.Add(this.PcBLucchetto);
            this.Controls.Add(this.PcBNumero);
            this.Controls.Add(this.PcBPoker);
            this.Controls.Add(this.BtnEsci);
            this.Controls.Add(this.LblPoker);
            this.Controls.Add(this.LblBOMB);
            this.Controls.Add(this.LblIndovinaIlNumero);
            this.Controls.Add(this.LblCampoMinato);
            this.Controls.Add(this.LblSbloccaLucchetto);
            this.Name = "MenuLog";
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuLog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PcBPoker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBNumero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBLucchetto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBCampoMinato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBBOMB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSbloccaLucchetto;
        private System.Windows.Forms.Label LblCampoMinato;
        private System.Windows.Forms.Label LblIndovinaIlNumero;
        private System.Windows.Forms.Label LblBOMB;
        private System.Windows.Forms.Label LblPoker;
        private System.Windows.Forms.Button BtnEsci;
        private System.Windows.Forms.PictureBox PcBPoker;
        private System.Windows.Forms.PictureBox PcBNumero;
        private System.Windows.Forms.PictureBox PcBLucchetto;
        private System.Windows.Forms.PictureBox PcBCampoMinato;
        private System.Windows.Forms.PictureBox PcBBOMB;
        private System.Windows.Forms.Label LblSingle;
        private System.Windows.Forms.Label LblMultiPlayer;
        private System.Windows.Forms.Label LblUtente;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}