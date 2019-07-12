namespace BuscadorDeEscalas
{
    partial class ChromaticCircle
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrAppTimer = new System.Windows.Forms.Timer(this.components);
            this.cmbNote = new System.Windows.Forms.ComboBox();
            this.chk2b = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk3Maior = new System.Windows.Forms.CheckBox();
            this.chk3menor = new System.Windows.Forms.CheckBox();
            this.chk5Aumentada = new System.Windows.Forms.CheckBox();
            this.chk5 = new System.Windows.Forms.CheckBox();
            this.chk5b = new System.Windows.Forms.CheckBox();
            this.chk4 = new System.Windows.Forms.CheckBox();
            this.chk7 = new System.Windows.Forms.CheckBox();
            this.chk6 = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.chk7M = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tmrAppTimer
            // 
            this.tmrAppTimer.Enabled = true;
            this.tmrAppTimer.Interval = 10;
            this.tmrAppTimer.Tick += new System.EventHandler(this.tmrAppTimer_Tick);
            // 
            // cmbNote
            // 
            this.cmbNote.FormattingEnabled = true;
            this.cmbNote.Items.AddRange(new object[] {
            "C",
            "C#",
            "D",
            "D#",
            "E",
            "F",
            "F#",
            "G",
            "G#",
            "A",
            "A#",
            "B"});
            this.cmbNote.Location = new System.Drawing.Point(12, 429);
            this.cmbNote.Name = "cmbNote";
            this.cmbNote.Size = new System.Drawing.Size(59, 21);
            this.cmbNote.TabIndex = 0;
            // 
            // chk2b
            // 
            this.chk2b.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chk2b.Location = new System.Drawing.Point(88, 418);
            this.chk2b.Name = "chk2b";
            this.chk2b.Size = new System.Drawing.Size(26, 32);
            this.chk2b.TabIndex = 1;
            this.chk2b.Text = "2b";
            this.chk2b.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chk2b.UseVisualStyleBackColor = true;
            // 
            // chk2
            // 
            this.chk2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chk2.Location = new System.Drawing.Point(118, 418);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(26, 32);
            this.chk2.TabIndex = 2;
            this.chk2.Text = "2";
            this.chk2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chk2.UseVisualStyleBackColor = true;
            // 
            // chk3Maior
            // 
            this.chk3Maior.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chk3Maior.Location = new System.Drawing.Point(178, 418);
            this.chk3Maior.Name = "chk3Maior";
            this.chk3Maior.Size = new System.Drawing.Size(26, 32);
            this.chk3Maior.TabIndex = 4;
            this.chk3Maior.Text = "3M";
            this.chk3Maior.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chk3Maior.UseVisualStyleBackColor = true;
            // 
            // chk3menor
            // 
            this.chk3menor.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chk3menor.Location = new System.Drawing.Point(148, 418);
            this.chk3menor.Name = "chk3menor";
            this.chk3menor.Size = new System.Drawing.Size(26, 32);
            this.chk3menor.TabIndex = 3;
            this.chk3menor.Text = "3m";
            this.chk3menor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chk3menor.UseVisualStyleBackColor = true;
            // 
            // chk5Aumentada
            // 
            this.chk5Aumentada.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chk5Aumentada.Location = new System.Drawing.Point(298, 418);
            this.chk5Aumentada.Name = "chk5Aumentada";
            this.chk5Aumentada.Size = new System.Drawing.Size(26, 32);
            this.chk5Aumentada.TabIndex = 8;
            this.chk5Aumentada.Text = "5#";
            this.chk5Aumentada.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chk5Aumentada.UseVisualStyleBackColor = true;
            // 
            // chk5
            // 
            this.chk5.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chk5.Location = new System.Drawing.Point(268, 418);
            this.chk5.Name = "chk5";
            this.chk5.Size = new System.Drawing.Size(26, 32);
            this.chk5.TabIndex = 7;
            this.chk5.Text = "¨5";
            this.chk5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chk5.UseVisualStyleBackColor = true;
            // 
            // chk5b
            // 
            this.chk5b.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chk5b.Location = new System.Drawing.Point(238, 418);
            this.chk5b.Name = "chk5b";
            this.chk5b.Size = new System.Drawing.Size(26, 32);
            this.chk5b.TabIndex = 6;
            this.chk5b.Text = "5b";
            this.chk5b.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chk5b.UseVisualStyleBackColor = true;
            // 
            // chk4
            // 
            this.chk4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chk4.Location = new System.Drawing.Point(208, 418);
            this.chk4.Name = "chk4";
            this.chk4.Size = new System.Drawing.Size(26, 32);
            this.chk4.TabIndex = 5;
            this.chk4.Text = "4";
            this.chk4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chk4.UseVisualStyleBackColor = true;
            // 
            // chk7
            // 
            this.chk7.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chk7.Location = new System.Drawing.Point(358, 418);
            this.chk7.Name = "chk7";
            this.chk7.Size = new System.Drawing.Size(26, 32);
            this.chk7.TabIndex = 10;
            this.chk7.Text = "7";
            this.chk7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chk7.UseVisualStyleBackColor = true;
            // 
            // chk6
            // 
            this.chk6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chk6.Location = new System.Drawing.Point(328, 418);
            this.chk6.Name = "chk6";
            this.chk6.Size = new System.Drawing.Size(26, 32);
            this.chk6.TabIndex = 9;
            this.chk6.Text = "6";
            this.chk6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chk6.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(420, 427);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(53, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chk7M
            // 
            this.chk7M.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chk7M.Location = new System.Drawing.Point(388, 418);
            this.chk7M.Name = "chk7M";
            this.chk7M.Size = new System.Drawing.Size(26, 32);
            this.chk7M.TabIndex = 12;
            this.chk7M.Text = "7M";
            this.chk7M.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chk7M.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(485, 462);
            this.Controls.Add(this.chk7M);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chk7);
            this.Controls.Add(this.chk6);
            this.Controls.Add(this.chk5Aumentada);
            this.Controls.Add(this.chk5);
            this.Controls.Add(this.chk5b);
            this.Controls.Add(this.chk4);
            this.Controls.Add(this.chk3Maior);
            this.Controls.Add(this.chk3menor);
            this.Controls.Add(this.chk2);
            this.Controls.Add(this.chk2b);
            this.Controls.Add(this.cmbNote);
            this.DoubleBuffered = true;
            this.Name = "frmMain";
            this.Text = "Chromatic Circle Tools";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrAppTimer;
        private System.Windows.Forms.ComboBox cmbNote;
        private System.Windows.Forms.CheckBox chk2b;
        private System.Windows.Forms.CheckBox chk2;
        private System.Windows.Forms.CheckBox chk3Maior;
        private System.Windows.Forms.CheckBox chk3menor;
        private System.Windows.Forms.CheckBox chk5Aumentada;
        private System.Windows.Forms.CheckBox chk5;
        private System.Windows.Forms.CheckBox chk5b;
        private System.Windows.Forms.CheckBox chk4;
        private System.Windows.Forms.CheckBox chk7;
        private System.Windows.Forms.CheckBox chk6;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chk7M;
    }
}

