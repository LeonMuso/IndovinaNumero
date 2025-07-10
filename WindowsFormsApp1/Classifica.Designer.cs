namespace WindowsFormsApp1
{
    partial class Classifica
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
            this.rtbClassifica = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbClassifica
            // 
            this.rtbClassifica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbClassifica.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbClassifica.Location = new System.Drawing.Point(0, 0);
            this.rtbClassifica.Name = "rtbClassifica";
            this.rtbClassifica.ReadOnly = true;
            this.rtbClassifica.Size = new System.Drawing.Size(310, 446);
            this.rtbClassifica.TabIndex = 0;
            this.rtbClassifica.Text = "";
            // 
            // Classifica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 446);
            this.Controls.Add(this.rtbClassifica);
            this.Name = "Classifica";
            this.Text = "Classifica";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbClassifica;
    }
}