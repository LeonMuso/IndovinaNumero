namespace SudokuWinForms
{
    partial class Sudoku
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sudoku));
            this.LblUtente = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnNuovaPartita = new System.Windows.Forms.Button();
            this.CbDiff = new System.Windows.Forms.ComboBox();
            this.BtnClassifica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblUtente
            // 
            this.LblUtente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUtente.Location = new System.Drawing.Point(306, 515);
            this.LblUtente.Name = "LblUtente";
            this.LblUtente.Size = new System.Drawing.Size(129, 44);
            this.LblUtente.TabIndex = 0;
            this.LblUtente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(441, 515);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 44);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // BtnNuovaPartita
            // 
            this.BtnNuovaPartita.Location = new System.Drawing.Point(130, 538);
            this.BtnNuovaPartita.Name = "BtnNuovaPartita";
            this.BtnNuovaPartita.Size = new System.Drawing.Size(109, 23);
            this.BtnNuovaPartita.TabIndex = 16;
            this.BtnNuovaPartita.Text = "New Game";
            this.BtnNuovaPartita.UseVisualStyleBackColor = true;
            this.BtnNuovaPartita.Click += new System.EventHandler(this.BtnNuovaPartita_Click);
            // 
            // CbDiff
            // 
            this.CbDiff.FormattingEnabled = true;
            this.CbDiff.Location = new System.Drawing.Point(3, 538);
            this.CbDiff.Name = "CbDiff";
            this.CbDiff.Size = new System.Drawing.Size(121, 21);
            this.CbDiff.TabIndex = 17;
            // 
            // BtnClassifica
            // 
            this.BtnClassifica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnClassifica.BackgroundImage")));
            this.BtnClassifica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnClassifica.Location = new System.Drawing.Point(409, 452);
            this.BtnClassifica.Name = "BtnClassifica";
            this.BtnClassifica.Size = new System.Drawing.Size(73, 57);
            this.BtnClassifica.TabIndex = 18;
            this.BtnClassifica.UseVisualStyleBackColor = true;
            this.BtnClassifica.Click += new System.EventHandler(this.BtnClassifica_Click);
            // 
            // Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.BtnClassifica);
            this.Controls.Add(this.CbDiff);
            this.Controls.Add(this.BtnNuovaPartita);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LblUtente);
            this.Name = "Sudoku";
            this.Text = "Sudoku";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sudoku_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblUtente;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnNuovaPartita;
        private System.Windows.Forms.ComboBox CbDiff;
        private System.Windows.Forms.Button BtnClassifica;
    }
}