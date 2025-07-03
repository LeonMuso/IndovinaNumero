namespace WindowsFormsApp1
{
    partial class Form2
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
            this.Num1 = new System.Windows.Forms.NumericUpDown();
            this.LblTitolo = new System.Windows.Forms.Label();
            this.LblCorrette = new System.Windows.Forms.Label();
            this.BtnVerifica = new System.Windows.Forms.Button();
            this.Num2 = new System.Windows.Forms.NumericUpDown();
            this.Num3 = new System.Windows.Forms.NumericUpDown();
            this.Num4 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Num1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num4)).BeginInit();
            this.SuspendLayout();
            // 
            // Num1
            // 
            this.Num1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Num1.Location = new System.Drawing.Point(268, 181);
            this.Num1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.Num1.Name = "Num1";
            this.Num1.Size = new System.Drawing.Size(38, 20);
            this.Num1.TabIndex = 0;
            // 
            // LblTitolo
            // 
            this.LblTitolo.AutoSize = true;
            this.LblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitolo.Location = new System.Drawing.Point(208, 85);
            this.LblTitolo.Name = "LblTitolo";
            this.LblTitolo.Size = new System.Drawing.Size(315, 39);
            this.LblTitolo.TabIndex = 2;
            this.LblTitolo.Text = "Sblocca il lucchetto";
            // 
            // LblCorrette
            // 
            this.LblCorrette.AutoSize = true;
            this.LblCorrette.Location = new System.Drawing.Point(460, 183);
            this.LblCorrette.Name = "LblCorrette";
            this.LblCorrette.Size = new System.Drawing.Size(0, 13);
            this.LblCorrette.TabIndex = 3;
            // 
            // BtnVerifica
            // 
            this.BtnVerifica.Location = new System.Drawing.Point(312, 207);
            this.BtnVerifica.Name = "BtnVerifica";
            this.BtnVerifica.Size = new System.Drawing.Size(75, 23);
            this.BtnVerifica.TabIndex = 4;
            this.BtnVerifica.Text = "Verifica";
            this.BtnVerifica.UseVisualStyleBackColor = true;
            this.BtnVerifica.Click += new System.EventHandler(this.BtnVerifica_Click);
            // 
            // Num2
            // 
            this.Num2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Num2.Location = new System.Drawing.Point(312, 181);
            this.Num2.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.Num2.Name = "Num2";
            this.Num2.Size = new System.Drawing.Size(38, 20);
            this.Num2.TabIndex = 5;
            // 
            // Num3
            // 
            this.Num3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Num3.Location = new System.Drawing.Point(356, 181);
            this.Num3.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.Num3.Name = "Num3";
            this.Num3.Size = new System.Drawing.Size(38, 20);
            this.Num3.TabIndex = 6;
            // 
            // Num4
            // 
            this.Num4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Num4.Location = new System.Drawing.Point(400, 181);
            this.Num4.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.Num4.Name = "Num4";
            this.Num4.Size = new System.Drawing.Size(38, 20);
            this.Num4.TabIndex = 7;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Num4);
            this.Controls.Add(this.Num3);
            this.Controls.Add(this.Num2);
            this.Controls.Add(this.BtnVerifica);
            this.Controls.Add(this.LblCorrette);
            this.Controls.Add(this.LblTitolo);
            this.Controls.Add(this.Num1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Num1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Num1;
        private System.Windows.Forms.Label LblTitolo;
        private System.Windows.Forms.Label LblCorrette;
        private System.Windows.Forms.Button BtnVerifica;
        private System.Windows.Forms.NumericUpDown Num2;
        private System.Windows.Forms.NumericUpDown Num3;
        private System.Windows.Forms.NumericUpDown Num4;
    }
}