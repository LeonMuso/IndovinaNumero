namespace WindowsFormsApp1
{
    partial class Regole
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
            this.rtbRegole = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbRegole
            // 
            this.rtbRegole.Location = new System.Drawing.Point(1, -1);
            this.rtbRegole.Name = "rtbRegole";
            this.rtbRegole.ReadOnly = true;
            this.rtbRegole.Size = new System.Drawing.Size(389, 523);
            this.rtbRegole.TabIndex = 0;
            this.rtbRegole.Text = "";
            // 
            // Regole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 521);
            this.Controls.Add(this.rtbRegole);
            this.Name = "Regole";
            this.Text = "Regole";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbRegole;
    }
}