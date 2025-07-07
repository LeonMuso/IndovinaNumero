namespace WindowsFormsApp1
{
    partial class Form3
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
            this.tabellaCampo.Location = new System.Drawing.Point(214, 58);
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
            this.LblTempoT.Location = new System.Drawing.Point(645, 135);
            this.LblTempoT.Name = "LblTempoT";
            this.LblTempoT.Size = new System.Drawing.Size(100, 49);
            this.LblTempoT.TabIndex = 1;
            // 
            // LblBandierine
            // 
            this.LblBandierine.Location = new System.Drawing.Point(648, 202);
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
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblTitolo);
            this.Controls.Add(this.LblBandierine);
            this.Controls.Add(this.LblTempoT);
            this.Controls.Add(this.tabellaCampo);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tabellaCampo;
        private System.Windows.Forms.Label LblTempoT;
        private System.Windows.Forms.Label LblBandierine;
        private System.Windows.Forms.Timer tempoT;
        private System.Windows.Forms.Label LblTitolo;
    }
}