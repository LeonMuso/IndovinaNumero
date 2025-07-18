namespace WindowsFormsApp1
{
    partial class Nim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nim));
            this.lblTurno = new System.Windows.Forms.Label();
            this.pnlGioco = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.btnConferma = new System.Windows.Forms.Button();
            this.BtnClassifica = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTurno.Location = new System.Drawing.Point(30, 20);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(131, 21);
            this.lblTurno.TabIndex = 1;
            this.lblTurno.Text = "Turno giocatore";
            this.lblTurno.Visible = false;
            // 
            // pnlGioco
            // 
            this.pnlGioco.AutoScroll = true;
            this.pnlGioco.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlGioco.Location = new System.Drawing.Point(30, 60);
            this.pnlGioco.Name = "pnlGioco";
            this.pnlGioco.Size = new System.Drawing.Size(418, 447);
            this.pnlGioco.TabIndex = 0;
            this.pnlGioco.Visible = false;
            this.pnlGioco.WrapContents = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(357, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 29);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTitolo
            // 
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.Location = new System.Drawing.Point(276, 9);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(75, 37);
            this.lblTitolo.TabIndex = 3;
            this.lblTitolo.Text = "Nim";
            // 
            // btnConferma
            // 
            this.btnConferma.Location = new System.Drawing.Point(192, 526);
            this.btnConferma.Name = "btnConferma";
            this.btnConferma.Size = new System.Drawing.Size(100, 40);
            this.btnConferma.TabIndex = 4;
            this.btnConferma.Text = "Conferma";
            this.btnConferma.UseVisualStyleBackColor = true;
            this.btnConferma.Visible = false;
            this.btnConferma.Click += new System.EventHandler(this.btnConferma_Click);
            // 
            // BtnClassifica
            // 
            this.BtnClassifica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnClassifica.BackgroundImage")));
            this.BtnClassifica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnClassifica.Location = new System.Drawing.Point(382, 514);
            this.BtnClassifica.Name = "BtnClassifica";
            this.BtnClassifica.Size = new System.Drawing.Size(81, 65);
            this.BtnClassifica.TabIndex = 16;
            this.BtnClassifica.UseVisualStyleBackColor = true;
            this.BtnClassifica.Click += new System.EventHandler(this.BtnClassifica_Click);
            // 
            // Nim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 587);
            this.Controls.Add(this.BtnClassifica);
            this.Controls.Add(this.btnConferma);
            this.Controls.Add(this.lblTitolo);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pnlGioco);
            this.Controls.Add(this.lblTurno);
            this.Name = "Nim";
            this.Text = "Gioco del Nim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Nim_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.FlowLayoutPanel pnlGioco;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Button btnConferma;
        private System.Windows.Forms.Button BtnClassifica;
    }
}