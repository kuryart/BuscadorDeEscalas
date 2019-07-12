using BuscadorDeEscalas.Teste;

namespace BuscadorDeEscalas
{
    partial class TeclaTesteForm
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
            this.teclaTeste1 = new BuscadorDeEscalas.Teste.TeclaTeste();
            this.SuspendLayout();
            // 
            // teclaTeste1
            // 
            this.teclaTeste1.Location = new System.Drawing.Point(12, 12);
            this.teclaTeste1.Name = "teclaTeste1";
            this.teclaTeste1.Size = new System.Drawing.Size(150, 150);
            this.teclaTeste1.TabIndex = 0;
            this.teclaTeste1.Click += new System.EventHandler(this.teclaTeste1_Click);
            // 
            // TeclaTesteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.teclaTeste1);
            this.Name = "TeclaTesteForm";
            this.Text = "TeclaTesteForm";
            this.ResumeLayout(false);

        }

        #endregion

        private TeclaTeste teclaTeste1;
    }
}