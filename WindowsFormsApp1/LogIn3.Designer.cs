namespace WindowsFormsApp1
{
    partial class LogIn3
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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lstNomiRecenti = new System.Windows.Forms.ListBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(30, 66);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(150, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // lstNomiRecenti
            // 
            this.lstNomiRecenti.FormattingEnabled = true;
            this.lstNomiRecenti.Location = new System.Drawing.Point(210, 30);
            this.lstNomiRecenti.Name = "lstNomiRecenti";
            this.lstNomiRecenti.Size = new System.Drawing.Size(142, 43);
            this.lstNomiRecenti.TabIndex = 5;
            this.lstNomiRecenti.SelectedIndexChanged += new System.EventHandler(this.lstNomiRecenti_SelectedIndexChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(30, 30);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(150, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // LogIn3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 199);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lstNomiRecenti);
            this.Controls.Add(this.txtUsername);
            this.Name = "LogIn3";
            this.Text = "LogIn3";
            this.Load += new System.EventHandler(this.LogIn3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ListBox lstNomiRecenti;
        private System.Windows.Forms.TextBox txtUsername;
    }
}