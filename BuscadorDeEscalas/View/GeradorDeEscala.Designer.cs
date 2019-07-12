namespace BuscadorDeEscalas
{
    partial class frmGeradorDeEscala
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timTimer = new System.Windows.Forms.Timer(this.components);
            this.cbNotas = new System.Windows.Forms.ComboBox();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.dtgEscalas = new System.Windows.Forms.DataGridView();
            this.panCanvas = new System.Windows.Forms.Panel();
            this.cbFerramentas = new System.Windows.Forms.ComboBox();
            this.grpFerramentas = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEscalas)).BeginInit();
            this.grpFerramentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // timTimer
            // 
            this.timTimer.Interval = 10;
            this.timTimer.Tick += new System.EventHandler(this.timTimer_Tick);
            // 
            // cbNotas
            // 
            this.cbNotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNotas.FormattingEnabled = true;
            this.cbNotas.Location = new System.Drawing.Point(450, 417);
            this.cbNotas.Name = "cbNotas";
            this.cbNotas.Size = new System.Drawing.Size(121, 21);
            this.cbNotas.TabIndex = 0;
            this.cbNotas.SelectedIndexChanged += new System.EventHandler(this.cbNotas_SelectedIndexChanged);
            // 
            // btnProcessar
            // 
            this.btnProcessar.Location = new System.Drawing.Point(577, 415);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(121, 23);
            this.btnProcessar.TabIndex = 2;
            this.btnProcessar.Text = "Processar";
            this.btnProcessar.UseVisualStyleBackColor = true;
            this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
            // 
            // dtgEscalas
            // 
            this.dtgEscalas.AllowUserToAddRows = false;
            this.dtgEscalas.AllowUserToDeleteRows = false;
            this.dtgEscalas.AllowUserToResizeColumns = false;
            this.dtgEscalas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtgEscalas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgEscalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEscalas.Location = new System.Drawing.Point(12, 213);
            this.dtgEscalas.MultiSelect = false;
            this.dtgEscalas.Name = "dtgEscalas";
            this.dtgEscalas.ReadOnly = true;
            this.dtgEscalas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEscalas.Size = new System.Drawing.Size(686, 196);
            this.dtgEscalas.TabIndex = 3;
            this.dtgEscalas.SelectionChanged += new System.EventHandler(this.dtgEscalas_SelectionChanged);
            // 
            // panCanvas
            // 
            this.panCanvas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panCanvas.Location = new System.Drawing.Point(12, 12);
            this.panCanvas.Name = "panCanvas";
            this.panCanvas.Size = new System.Drawing.Size(1230, 195);
            this.panCanvas.TabIndex = 4;
            // 
            // cbFerramentas
            // 
            this.cbFerramentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFerramentas.FormattingEnabled = true;
            this.cbFerramentas.Items.AddRange(new object[] {
            "Padrão",
            "Todos Intervalos",
            "Todas Tríades"});
            this.cbFerramentas.Location = new System.Drawing.Point(6, 19);
            this.cbFerramentas.Name = "cbFerramentas";
            this.cbFerramentas.Size = new System.Drawing.Size(121, 21);
            this.cbFerramentas.TabIndex = 5;
            // 
            // grpFerramentas
            // 
            this.grpFerramentas.Controls.Add(this.cbFerramentas);
            this.grpFerramentas.Location = new System.Drawing.Point(704, 213);
            this.grpFerramentas.Name = "grpFerramentas";
            this.grpFerramentas.Size = new System.Drawing.Size(529, 196);
            this.grpFerramentas.TabIndex = 6;
            this.grpFerramentas.TabStop = false;
            this.grpFerramentas.Text = "Ferramentas";
            // 
            // frmGeradorDeEscala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 450);
            this.Controls.Add(this.grpFerramentas);
            this.Controls.Add(this.panCanvas);
            this.Controls.Add(this.dtgEscalas);
            this.Controls.Add(this.btnProcessar);
            this.Controls.Add(this.cbNotas);
            this.Name = "frmGeradorDeEscala";
            this.Text = "Gerador de Escala";
            this.Load += new System.EventHandler(this.frmGeradorDeEscala_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmGeradorDeEscala_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEscalas)).EndInit();
            this.grpFerramentas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timTimer;
        private System.Windows.Forms.ComboBox cbNotas;
        private System.Windows.Forms.Button btnProcessar;
        private System.Windows.Forms.DataGridView dtgEscalas;
        private System.Windows.Forms.Panel panCanvas;
        private System.Windows.Forms.ComboBox cbFerramentas;
        private System.Windows.Forms.GroupBox grpFerramentas;
    }
}