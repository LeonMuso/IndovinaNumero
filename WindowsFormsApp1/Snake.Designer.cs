namespace WindowsFormsApp1
{
    partial class Snake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Snake));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnStart = new System.Windows.Forms.Button();
            this.LblTitolo = new System.Windows.Forms.Label();
            this.BtnClassifica = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(317, 132);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(139, 50);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // LblTitolo
            // 
            this.LblTitolo.AutoSize = true;
            this.LblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitolo.ForeColor = System.Drawing.Color.Transparent;
            this.LblTitolo.Location = new System.Drawing.Point(336, 57);
            this.LblTitolo.Name = "LblTitolo";
            this.LblTitolo.Size = new System.Drawing.Size(107, 37);
            this.LblTitolo.TabIndex = 1;
            this.LblTitolo.Text = "Snake";
            // 
            // BtnClassifica
            // 
            this.BtnClassifica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnClassifica.BackgroundImage")));
            this.BtnClassifica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnClassifica.Location = new System.Drawing.Point(707, 373);
            this.BtnClassifica.Name = "BtnClassifica";
            this.BtnClassifica.Size = new System.Drawing.Size(81, 65);
            this.BtnClassifica.TabIndex = 16;
            this.BtnClassifica.UseVisualStyleBackColor = true;
            this.BtnClassifica.Click += new System.EventHandler(this.BtnClassifica_Click);
            // 
            // Snake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnClassifica);
            this.Controls.Add(this.LblTitolo);
            this.Controls.Add(this.BtnStart);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Snake";
            this.Text = "Snake";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Snake_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Snake_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Snake_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label LblTitolo;
        private System.Windows.Forms.Button BtnClassifica;
    }
}