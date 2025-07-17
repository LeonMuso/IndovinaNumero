namespace WindowsFormsApp1
{
    partial class Poker5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Poker5));
            this.LblTitolo = new System.Windows.Forms.Label();
            this.BtnDistribuisci = new System.Windows.Forms.Button();
            this.LblP1 = new System.Windows.Forms.Label();
            this.LblP2 = new System.Windows.Forms.Label();
            this.BtnCambioP1 = new System.Windows.Forms.Button();
            this.BtnCambioP2 = new System.Windows.Forms.Button();
            this.BtnVincitore = new System.Windows.Forms.Button();
            this.LblPP1 = new System.Windows.Forms.Label();
            this.LblPP2 = new System.Windows.Forms.Label();
            this.LblP22 = new System.Windows.Forms.Label();
            this.LblP12 = new System.Windows.Forms.Label();
            this.LblUtente = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnClassifica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitolo
            // 
            this.LblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitolo.Location = new System.Drawing.Point(531, 113);
            this.LblTitolo.Name = "LblTitolo";
            this.LblTitolo.Size = new System.Drawing.Size(231, 39);
            this.LblTitolo.TabIndex = 0;
            this.LblTitolo.Text = "Poker";
            this.LblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnDistribuisci
            // 
            this.BtnDistribuisci.Location = new System.Drawing.Point(115, 265);
            this.BtnDistribuisci.Name = "BtnDistribuisci";
            this.BtnDistribuisci.Size = new System.Drawing.Size(86, 31);
            this.BtnDistribuisci.TabIndex = 2;
            this.BtnDistribuisci.Text = "Distribuisci";
            this.BtnDistribuisci.UseVisualStyleBackColor = true;
            this.BtnDistribuisci.Click += new System.EventHandler(this.BtnDistribuisci_Click);
            // 
            // LblP1
            // 
            this.LblP1.AutoSize = true;
            this.LblP1.Location = new System.Drawing.Point(428, 49);
            this.LblP1.Name = "LblP1";
            this.LblP1.Size = new System.Drawing.Size(0, 13);
            this.LblP1.TabIndex = 5;
            // 
            // LblP2
            // 
            this.LblP2.AutoSize = true;
            this.LblP2.Location = new System.Drawing.Point(428, 164);
            this.LblP2.Name = "LblP2";
            this.LblP2.Size = new System.Drawing.Size(0, 13);
            this.LblP2.TabIndex = 6;
            // 
            // BtnCambioP1
            // 
            this.BtnCambioP1.Enabled = false;
            this.BtnCambioP1.Location = new System.Drawing.Point(403, 74);
            this.BtnCambioP1.Name = "BtnCambioP1";
            this.BtnCambioP1.Size = new System.Drawing.Size(75, 23);
            this.BtnCambioP1.TabIndex = 9;
            this.BtnCambioP1.Text = "Cambio";
            this.BtnCambioP1.UseVisualStyleBackColor = true;
            this.BtnCambioP1.Click += new System.EventHandler(this.BtnCambioP1_Click);
            // 
            // BtnCambioP2
            // 
            this.BtnCambioP2.Enabled = false;
            this.BtnCambioP2.Location = new System.Drawing.Point(403, 191);
            this.BtnCambioP2.Name = "BtnCambioP2";
            this.BtnCambioP2.Size = new System.Drawing.Size(75, 23);
            this.BtnCambioP2.TabIndex = 10;
            this.BtnCambioP2.Text = "Cambio";
            this.BtnCambioP2.UseVisualStyleBackColor = true;
            this.BtnCambioP2.Click += new System.EventHandler(this.BtnCambioP2_Click);
            // 
            // BtnVincitore
            // 
            this.BtnVincitore.Enabled = false;
            this.BtnVincitore.Location = new System.Drawing.Point(497, 120);
            this.BtnVincitore.Name = "BtnVincitore";
            this.BtnVincitore.Size = new System.Drawing.Size(82, 37);
            this.BtnVincitore.TabIndex = 11;
            this.BtnVincitore.Text = "Valuta";
            this.BtnVincitore.UseVisualStyleBackColor = true;
            this.BtnVincitore.Click += new System.EventHandler(this.BtnVincitore_Click);
            // 
            // LblPP1
            // 
            this.LblPP1.Location = new System.Drawing.Point(490, 342);
            this.LblPP1.Name = "LblPP1";
            this.LblPP1.Size = new System.Drawing.Size(100, 23);
            this.LblPP1.TabIndex = 12;
            this.LblPP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPP2
            // 
            this.LblPP2.Location = new System.Drawing.Point(600, 342);
            this.LblPP2.Name = "LblPP2";
            this.LblPP2.Size = new System.Drawing.Size(100, 23);
            this.LblPP2.TabIndex = 13;
            this.LblPP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblP22
            // 
            this.LblP22.AutoSize = true;
            this.LblP22.Location = new System.Drawing.Point(641, 315);
            this.LblP22.Name = "LblP22";
            this.LblP22.Size = new System.Drawing.Size(0, 13);
            this.LblP22.TabIndex = 14;
            // 
            // LblP12
            // 
            this.LblP12.AutoSize = true;
            this.LblP12.Location = new System.Drawing.Point(535, 315);
            this.LblP12.Name = "LblP12";
            this.LblP12.Size = new System.Drawing.Size(0, 13);
            this.LblP12.TabIndex = 15;
            // 
            // LblUtente
            // 
            this.LblUtente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUtente.Location = new System.Drawing.Point(572, 6);
            this.LblUtente.Name = "LblUtente";
            this.LblUtente.Size = new System.Drawing.Size(190, 44);
            this.LblUtente.TabIndex = 16;
            this.LblUtente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(756, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 44);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // BtnClassifica
            // 
            this.BtnClassifica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnClassifica.BackgroundImage")));
            this.BtnClassifica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnClassifica.Location = new System.Drawing.Point(707, 373);
            this.BtnClassifica.Name = "BtnClassifica";
            this.BtnClassifica.Size = new System.Drawing.Size(81, 65);
            this.BtnClassifica.TabIndex = 18;
            this.BtnClassifica.UseVisualStyleBackColor = true;
            this.BtnClassifica.Click += new System.EventHandler(this.BtnClassifica_Click);
            // 
            // Poker5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnClassifica);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LblUtente);
            this.Controls.Add(this.LblP12);
            this.Controls.Add(this.LblP22);
            this.Controls.Add(this.LblPP2);
            this.Controls.Add(this.LblPP1);
            this.Controls.Add(this.BtnVincitore);
            this.Controls.Add(this.BtnCambioP2);
            this.Controls.Add(this.BtnCambioP1);
            this.Controls.Add(this.LblP2);
            this.Controls.Add(this.LblP1);
            this.Controls.Add(this.BtnDistribuisci);
            this.Controls.Add(this.LblTitolo);
            this.Name = "Poker5";
            this.Text = "Poker a 5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Poker5_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitolo;
        private System.Windows.Forms.Button BtnDistribuisci;
        private System.Windows.Forms.Label LblP1;
        private System.Windows.Forms.Label LblP2;
        private System.Windows.Forms.Button BtnCambioP1;
        private System.Windows.Forms.Button BtnCambioP2;
        private System.Windows.Forms.Button BtnVincitore;
        private System.Windows.Forms.Label LblPP1;
        private System.Windows.Forms.Label LblPP2;
        private System.Windows.Forms.Label LblP22;
        private System.Windows.Forms.Label LblP12;
        private System.Windows.Forms.Label LblUtente;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnClassifica;
    }
}