namespace WindowsFormsApp1
{
    partial class CampoMinato
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
            this.tabellaCampo = new System.Windows.Forms.TableLayoutPanel();
            this.LblTempoT = new System.Windows.Forms.Label();
            this.LblBandierine = new System.Windows.Forms.Label();
            this.tempoT = new System.Windows.Forms.Timer(this.components);
            this.LblTitolo = new System.Windows.Forms.Label();
            this.BtnPlay = new System.Windows.Forms.Button();
            this.BtnEasy = new System.Windows.Forms.Button();
            this.BtnMedium = new System.Windows.Forms.Button();
            this.BtnHard = new System.Windows.Forms.Button();
            this.BtnImp = new System.Windows.Forms.Button();
            this.BtnHowToPlay = new System.Windows.Forms.Button();
            this.BtnScrivi = new System.Windows.Forms.Button();
            this.TxBScrittura = new System.Windows.Forms.TextBox();
            this.BtnAggiungi = new System.Windows.Forms.Button();
            this.BtnVisualizza = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabellaCampo
            // 
            this.tabellaCampo.ColumnCount = 5;
            this.tabellaCampo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabellaCampo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabellaCampo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tabellaCampo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tabellaCampo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tabellaCampo.Location = new System.Drawing.Point(281, 67);
            this.tabellaCampo.Name = "tabellaCampo";
            this.tabellaCampo.RowCount = 5;
            this.tabellaCampo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabellaCampo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabellaCampo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tabellaCampo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tabellaCampo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tabellaCampo.Size = new System.Drawing.Size(343, 333);
            this.tabellaCampo.TabIndex = 0;
            // 
            // LblTempoT
            // 
            this.LblTempoT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTempoT.Location = new System.Drawing.Point(652, 149);
            this.LblTempoT.Name = "LblTempoT";
            this.LblTempoT.Size = new System.Drawing.Size(100, 49);
            this.LblTempoT.TabIndex = 1;
            // 
            // LblBandierine
            // 
            this.LblBandierine.Location = new System.Drawing.Point(655, 216);
            this.LblBandierine.Name = "LblBandierine";
            this.LblBandierine.Size = new System.Drawing.Size(97, 45);
            this.LblBandierine.TabIndex = 2;
            // 
            // tempoT
            // 
            this.tempoT.Interval = 1000;
            this.tempoT.Tick += new System.EventHandler(this.tempoT_Tick);
            // 
            // LblTitolo
            // 
            this.LblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitolo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblTitolo.Location = new System.Drawing.Point(274, 9);
            this.LblTitolo.Name = "LblTitolo";
            this.LblTitolo.Size = new System.Drawing.Size(231, 39);
            this.LblTitolo.TabIndex = 5;
            this.LblTitolo.Text = "Campo minato";
            // 
            // BtnPlay
            // 
            this.BtnPlay.Location = new System.Drawing.Point(39, 102);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(98, 40);
            this.BtnPlay.TabIndex = 6;
            this.BtnPlay.Text = "Play";
            this.BtnPlay.UseVisualStyleBackColor = true;
            this.BtnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // BtnEasy
            // 
            this.BtnEasy.Location = new System.Drawing.Point(39, 175);
            this.BtnEasy.Name = "BtnEasy";
            this.BtnEasy.Size = new System.Drawing.Size(75, 23);
            this.BtnEasy.TabIndex = 7;
            this.BtnEasy.Text = "Facile";
            this.BtnEasy.UseVisualStyleBackColor = true;
            this.BtnEasy.Visible = false;
            this.BtnEasy.Click += new System.EventHandler(this.BtnEasy_Click);
            // 
            // BtnMedium
            // 
            this.BtnMedium.Location = new System.Drawing.Point(39, 204);
            this.BtnMedium.Name = "BtnMedium";
            this.BtnMedium.Size = new System.Drawing.Size(75, 23);
            this.BtnMedium.TabIndex = 8;
            this.BtnMedium.Text = "Medio";
            this.BtnMedium.UseVisualStyleBackColor = true;
            this.BtnMedium.Visible = false;
            this.BtnMedium.Click += new System.EventHandler(this.BtnMedium_Click);
            // 
            // BtnHard
            // 
            this.BtnHard.Location = new System.Drawing.Point(39, 233);
            this.BtnHard.Name = "BtnHard";
            this.BtnHard.Size = new System.Drawing.Size(75, 23);
            this.BtnHard.TabIndex = 9;
            this.BtnHard.Text = "Difficile";
            this.BtnHard.UseVisualStyleBackColor = true;
            this.BtnHard.Visible = false;
            this.BtnHard.Click += new System.EventHandler(this.BtnHard_Click);
            // 
            // BtnImp
            // 
            this.BtnImp.Location = new System.Drawing.Point(39, 262);
            this.BtnImp.Name = "BtnImp";
            this.BtnImp.Size = new System.Drawing.Size(75, 23);
            this.BtnImp.TabIndex = 10;
            this.BtnImp.Text = "Impossibile";
            this.BtnImp.UseVisualStyleBackColor = true;
            this.BtnImp.Visible = false;
            this.BtnImp.Click += new System.EventHandler(this.BtnImp_Click);
            // 
            // BtnHowToPlay
            // 
            this.BtnHowToPlay.Location = new System.Drawing.Point(686, 398);
            this.BtnHowToPlay.Name = "BtnHowToPlay";
            this.BtnHowToPlay.Size = new System.Drawing.Size(102, 40);
            this.BtnHowToPlay.TabIndex = 11;
            this.BtnHowToPlay.Text = "How to play";
            this.BtnHowToPlay.UseVisualStyleBackColor = true;
            this.BtnHowToPlay.Click += new System.EventHandler(this.BtnHowToPlay_Click);
            // 
            // BtnScrivi
            // 
            this.BtnScrivi.Location = new System.Drawing.Point(12, 415);
            this.BtnScrivi.Name = "BtnScrivi";
            this.BtnScrivi.Size = new System.Drawing.Size(75, 23);
            this.BtnScrivi.TabIndex = 12;
            this.BtnScrivi.Text = "Scrivi";
            this.BtnScrivi.UseVisualStyleBackColor = true;
            this.BtnScrivi.Click += new System.EventHandler(this.BtnScrivi_Click);
            // 
            // TxBScrittura
            // 
            this.TxBScrittura.Location = new System.Drawing.Point(105, 417);
            this.TxBScrittura.Name = "TxBScrittura";
            this.TxBScrittura.Size = new System.Drawing.Size(100, 20);
            this.TxBScrittura.TabIndex = 13;
            this.TxBScrittura.Visible = false;
            // 
            // BtnAggiungi
            // 
            this.BtnAggiungi.Location = new System.Drawing.Point(221, 417);
            this.BtnAggiungi.Name = "BtnAggiungi";
            this.BtnAggiungi.Size = new System.Drawing.Size(75, 23);
            this.BtnAggiungi.TabIndex = 14;
            this.BtnAggiungi.Text = "Aggiungi";
            this.BtnAggiungi.UseVisualStyleBackColor = true;
            this.BtnAggiungi.Visible = false;
            this.BtnAggiungi.Click += new System.EventHandler(this.BtnAggiungi_Click);
            // 
            // BtnVisualizza
            // 
            this.BtnVisualizza.Location = new System.Drawing.Point(302, 417);
            this.BtnVisualizza.Name = "BtnVisualizza";
            this.BtnVisualizza.Size = new System.Drawing.Size(75, 23);
            this.BtnVisualizza.TabIndex = 15;
            this.BtnVisualizza.Text = "Visualizza";
            this.BtnVisualizza.UseVisualStyleBackColor = true;
            this.BtnVisualizza.Visible = false;
            this.BtnVisualizza.Click += new System.EventHandler(this.BtnVisualizza_Click);
            // 
            // CampoMinato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnVisualizza);
            this.Controls.Add(this.BtnAggiungi);
            this.Controls.Add(this.TxBScrittura);
            this.Controls.Add(this.BtnScrivi);
            this.Controls.Add(this.BtnHowToPlay);
            this.Controls.Add(this.BtnImp);
            this.Controls.Add(this.BtnHard);
            this.Controls.Add(this.BtnMedium);
            this.Controls.Add(this.BtnEasy);
            this.Controls.Add(this.BtnPlay);
            this.Controls.Add(this.LblTitolo);
            this.Controls.Add(this.LblBandierine);
            this.Controls.Add(this.LblTempoT);
            this.Controls.Add(this.tabellaCampo);
            this.Name = "CampoMinato";
            this.Text = "Campo minato";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tabellaCampo;
        private System.Windows.Forms.Label LblTempoT;
        private System.Windows.Forms.Label LblBandierine;
        private System.Windows.Forms.Timer tempoT;
        private System.Windows.Forms.Label LblTitolo;
        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.Button BtnEasy;
        private System.Windows.Forms.Button BtnMedium;
        private System.Windows.Forms.Button BtnHard;
        private System.Windows.Forms.Button BtnImp;
        private System.Windows.Forms.Button BtnHowToPlay;
        private System.Windows.Forms.Button BtnScrivi;
        private System.Windows.Forms.TextBox TxBScrittura;
        private System.Windows.Forms.Button BtnAggiungi;
        private System.Windows.Forms.Button BtnVisualizza;
    }
}