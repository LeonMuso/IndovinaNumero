namespace WindowsFormsApp1
{
    partial class IndovinaNumero
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnPlay = new System.Windows.Forms.Button();
            this.BtnEasy = new System.Windows.Forms.Button();
            this.BtnMedium = new System.Windows.Forms.Button();
            this.BtnHard = new System.Windows.Forms.Button();
            this.LblTitolo = new System.Windows.Forms.Label();
            this.TxBNumero = new System.Windows.Forms.TextBox();
            this.BtnVerificaNumero = new System.Windows.Forms.Button();
            this.LblMaxMin = new System.Windows.Forms.Label();
            this.LblTentativi = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.LblTimer = new System.Windows.Forms.Label();
            this.LblNome = new System.Windows.Forms.Label();
            this.BtnNome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnPlay
            // 
            this.BtnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlay.Location = new System.Drawing.Point(304, 107);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(134, 48);
            this.BtnPlay.TabIndex = 0;
            this.BtnPlay.Text = "Play";
            this.BtnPlay.UseVisualStyleBackColor = true;
            this.BtnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // BtnEasy
            // 
            this.BtnEasy.Location = new System.Drawing.Point(134, 169);
            this.BtnEasy.Name = "BtnEasy";
            this.BtnEasy.Size = new System.Drawing.Size(85, 41);
            this.BtnEasy.TabIndex = 1;
            this.BtnEasy.Text = "Facile";
            this.BtnEasy.UseVisualStyleBackColor = true;
            this.BtnEasy.Visible = false;
            this.BtnEasy.Click += new System.EventHandler(this.BtnEasy_Click);
            // 
            // BtnMedium
            // 
            this.BtnMedium.Location = new System.Drawing.Point(134, 216);
            this.BtnMedium.Name = "BtnMedium";
            this.BtnMedium.Size = new System.Drawing.Size(85, 41);
            this.BtnMedium.TabIndex = 2;
            this.BtnMedium.Text = "Medio";
            this.BtnMedium.UseVisualStyleBackColor = true;
            this.BtnMedium.Visible = false;
            this.BtnMedium.Click += new System.EventHandler(this.BtnMedium_Click);
            // 
            // BtnHard
            // 
            this.BtnHard.Location = new System.Drawing.Point(134, 263);
            this.BtnHard.Name = "BtnHard";
            this.BtnHard.Size = new System.Drawing.Size(85, 41);
            this.BtnHard.TabIndex = 3;
            this.BtnHard.Text = "Difficile";
            this.BtnHard.UseVisualStyleBackColor = true;
            this.BtnHard.Visible = false;
            this.BtnHard.Click += new System.EventHandler(this.BtnHard_Click);
            // 
            // LblTitolo
            // 
            this.LblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitolo.Location = new System.Drawing.Point(228, 50);
            this.LblTitolo.Name = "LblTitolo";
            this.LblTitolo.Size = new System.Drawing.Size(300, 41);
            this.LblTitolo.TabIndex = 4;
            this.LblTitolo.Text = "Indovina il numero";
            this.LblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxBNumero
            // 
            this.TxBNumero.Location = new System.Drawing.Point(323, 161);
            this.TxBNumero.Name = "TxBNumero";
            this.TxBNumero.Size = new System.Drawing.Size(100, 20);
            this.TxBNumero.TabIndex = 5;
            this.TxBNumero.Visible = false;
            // 
            // BtnVerificaNumero
            // 
            this.BtnVerificaNumero.Location = new System.Drawing.Point(334, 187);
            this.BtnVerificaNumero.Name = "BtnVerificaNumero";
            this.BtnVerificaNumero.Size = new System.Drawing.Size(75, 23);
            this.BtnVerificaNumero.TabIndex = 6;
            this.BtnVerificaNumero.Text = "Verifica";
            this.BtnVerificaNumero.UseVisualStyleBackColor = true;
            this.BtnVerificaNumero.Visible = false;
            this.BtnVerificaNumero.Click += new System.EventHandler(this.BtnVerificaNumero_Click);
            // 
            // LblMaxMin
            // 
            this.LblMaxMin.Location = new System.Drawing.Point(377, 242);
            this.LblMaxMin.Name = "LblMaxMin";
            this.LblMaxMin.Size = new System.Drawing.Size(123, 42);
            this.LblMaxMin.TabIndex = 7;
            this.LblMaxMin.Visible = false;
            // 
            // LblTentativi
            // 
            this.LblTentativi.Location = new System.Drawing.Point(248, 242);
            this.LblTentativi.Name = "LblTentativi";
            this.LblTentativi.Size = new System.Drawing.Size(123, 44);
            this.LblTentativi.TabIndex = 8;
            this.LblTentativi.Visible = false;
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // LblTimer
            // 
            this.LblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTimer.Location = new System.Drawing.Point(506, 137);
            this.LblTimer.Name = "LblTimer";
            this.LblTimer.Size = new System.Drawing.Size(221, 117);
            this.LblTimer.TabIndex = 9;
            this.LblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTimer.Visible = false;
            // 
            // LblNome
            // 
            this.LblNome.AutoSize = true;
            this.LblNome.Location = new System.Drawing.Point(320, 107);
            this.LblNome.Name = "LblNome";
            this.LblNome.Size = new System.Drawing.Size(99, 13);
            this.LblNome.TabIndex = 11;
            this.LblNome.Text = "Inserisci il tuo nome";
            this.LblNome.Visible = false;
            // 
            // BtnNome
            // 
            this.BtnNome.Location = new System.Drawing.Point(334, 132);
            this.BtnNome.Name = "BtnNome";
            this.BtnNome.Size = new System.Drawing.Size(75, 23);
            this.BtnNome.TabIndex = 12;
            this.BtnNome.Text = "Inserisci";
            this.BtnNome.UseVisualStyleBackColor = true;
            this.BtnNome.Visible = false;
            this.BtnNome.Click += new System.EventHandler(this.BtnNome_Click);
            // 
            // IndovinaNumero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnNome);
            this.Controls.Add(this.LblNome);
            this.Controls.Add(this.LblTimer);
            this.Controls.Add(this.LblTentativi);
            this.Controls.Add(this.LblMaxMin);
            this.Controls.Add(this.BtnVerificaNumero);
            this.Controls.Add(this.TxBNumero);
            this.Controls.Add(this.LblTitolo);
            this.Controls.Add(this.BtnHard);
            this.Controls.Add(this.BtnMedium);
            this.Controls.Add(this.BtnEasy);
            this.Controls.Add(this.BtnPlay);
            this.Name = "IndovinaNumero";
            this.Text = "Indovina il Numero";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IndovinaNumero_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.Button BtnEasy;
        private System.Windows.Forms.Button BtnMedium;
        private System.Windows.Forms.Button BtnHard;
        private System.Windows.Forms.Label LblTitolo;
        private System.Windows.Forms.TextBox TxBNumero;
        private System.Windows.Forms.Button BtnVerificaNumero;
        private System.Windows.Forms.Label LblMaxMin;
        private System.Windows.Forms.Label LblTentativi;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label LblTimer;
        private System.Windows.Forms.Label LblNome;
        private System.Windows.Forms.Button BtnNome;
    }
}

