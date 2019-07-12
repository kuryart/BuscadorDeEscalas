namespace BuscadorDeEscalas
{
    partial class GeradorDeAcorde
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
            this.chkAdd = new System.Windows.Forms.CheckBox();
            this.cmbBaixo = new System.Windows.Forms.ComboBox();
            this.lblBaixo = new System.Windows.Forms.Label();
            this.lstbNotas = new System.Windows.Forms.ListBox();
            this.lstbBase = new System.Windows.Forms.ListBox();
            this.lstbNotasExtensao = new System.Windows.Forms.ListBox();
            this.lstbQuintas = new System.Windows.Forms.ListBox();
            this.lstbNonas = new System.Windows.Forms.ListBox();
            this.lstbDecimaPrimeira = new System.Windows.Forms.ListBox();
            this.lstbDecimaTerceira = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEscalas)).BeginInit();
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
            // chkAdd
            // 
            this.chkAdd.AutoSize = true;
            this.chkAdd.Location = new System.Drawing.Point(825, 360);
            this.chkAdd.Name = "chkAdd";
            this.chkAdd.Size = new System.Drawing.Size(44, 17);
            this.chkAdd.TabIndex = 12;
            this.chkAdd.Text = "add";
            this.chkAdd.UseVisualStyleBackColor = true;
            this.chkAdd.CheckedChanged += new System.EventHandler(this.chkAdd_CheckedChanged);
            // 
            // cmbBaixo
            // 
            this.cmbBaixo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaixo.FormattingEnabled = true;
            this.cmbBaixo.Items.AddRange(new object[] {
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
            "B"});
            this.cmbBaixo.Location = new System.Drawing.Point(704, 404);
            this.cmbBaixo.Name = "cmbBaixo";
            this.cmbBaixo.Size = new System.Drawing.Size(44, 21);
            this.cmbBaixo.TabIndex = 13;
            // 
            // lblBaixo
            // 
            this.lblBaixo.AutoSize = true;
            this.lblBaixo.Location = new System.Drawing.Point(704, 387);
            this.lblBaixo.Name = "lblBaixo";
            this.lblBaixo.Size = new System.Drawing.Size(36, 13);
            this.lblBaixo.TabIndex = 14;
            this.lblBaixo.Text = "Baixo:";
            // 
            // lstbNotas
            // 
            this.lstbNotas.FormattingEnabled = true;
            this.lstbNotas.Items.AddRange(new object[] {
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
            this.lstbNotas.Location = new System.Drawing.Point(704, 213);
            this.lstbNotas.Name = "lstbNotas";
            this.lstbNotas.Size = new System.Drawing.Size(32, 160);
            this.lstbNotas.TabIndex = 15;
            // 
            // lstbBase
            // 
            this.lstbBase.FormattingEnabled = true;
            this.lstbBase.Items.AddRange(new object[] {
            "M",
            "7",
            "maj7",
            "6",
            "m",
            "m7",
            "m/maj7",
            "m6",
            "7sus2",
            "7sus4",
            "dim",
            "aug",
            "5"});
            this.lstbBase.Location = new System.Drawing.Point(742, 213);
            this.lstbBase.Name = "lstbBase";
            this.lstbBase.Size = new System.Drawing.Size(53, 173);
            this.lstbBase.TabIndex = 16;
            this.lstbBase.SelectedIndexChanged += new System.EventHandler(this.lstbBase_SelectedIndexChanged);
            // 
            // lstbNotasExtensao
            // 
            this.lstbNotasExtensao.FormattingEnabled = true;
            this.lstbNotasExtensao.Items.AddRange(new object[] {
            "",
            "9",
            "11",
            "13"});
            this.lstbNotasExtensao.Location = new System.Drawing.Point(801, 213);
            this.lstbNotasExtensao.Name = "lstbNotasExtensao";
            this.lstbNotasExtensao.Size = new System.Drawing.Size(31, 56);
            this.lstbNotasExtensao.TabIndex = 17;
            this.lstbNotasExtensao.SelectedIndexChanged += new System.EventHandler(this.lstbNotasExtensao_SelectedIndexChanged);
            // 
            // lstbQuintas
            // 
            this.lstbQuintas.FormattingEnabled = true;
            this.lstbQuintas.Items.AddRange(new object[] {
            "",
            "/5+",
            "/5-"});
            this.lstbQuintas.Location = new System.Drawing.Point(801, 275);
            this.lstbQuintas.Name = "lstbQuintas";
            this.lstbQuintas.Size = new System.Drawing.Size(31, 43);
            this.lstbQuintas.TabIndex = 18;
            // 
            // lstbNonas
            // 
            this.lstbNonas.FormattingEnabled = true;
            this.lstbNonas.Items.AddRange(new object[] {
            "",
            "/9+",
            "/9-"});
            this.lstbNonas.Location = new System.Drawing.Point(838, 213);
            this.lstbNonas.Name = "lstbNonas";
            this.lstbNonas.Size = new System.Drawing.Size(31, 43);
            this.lstbNonas.TabIndex = 18;
            // 
            // lstbDecimaPrimeira
            // 
            this.lstbDecimaPrimeira.FormattingEnabled = true;
            this.lstbDecimaPrimeira.Items.AddRange(new object[] {
            "",
            "/11+",
            "/11-"});
            this.lstbDecimaPrimeira.Location = new System.Drawing.Point(838, 262);
            this.lstbDecimaPrimeira.Name = "lstbDecimaPrimeira";
            this.lstbDecimaPrimeira.Size = new System.Drawing.Size(31, 43);
            this.lstbDecimaPrimeira.TabIndex = 18;
            // 
            // lstbDecimaTerceira
            // 
            this.lstbDecimaTerceira.FormattingEnabled = true;
            this.lstbDecimaTerceira.Items.AddRange(new object[] {
            "",
            "/13+",
            "/13-"});
            this.lstbDecimaTerceira.Location = new System.Drawing.Point(838, 311);
            this.lstbDecimaTerceira.Name = "lstbDecimaTerceira";
            this.lstbDecimaTerceira.Size = new System.Drawing.Size(31, 43);
            this.lstbDecimaTerceira.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(794, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GeradorDeAcorde
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 501);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstbDecimaTerceira);
            this.Controls.Add(this.lstbDecimaPrimeira);
            this.Controls.Add(this.lstbNonas);
            this.Controls.Add(this.lstbQuintas);
            this.Controls.Add(this.lstbNotasExtensao);
            this.Controls.Add(this.lstbBase);
            this.Controls.Add(this.lstbNotas);
            this.Controls.Add(this.lblBaixo);
            this.Controls.Add(this.cmbBaixo);
            this.Controls.Add(this.chkAdd);
            this.Controls.Add(this.panCanvas);
            this.Controls.Add(this.dtgEscalas);
            this.Controls.Add(this.btnProcessar);
            this.Controls.Add(this.cbNotas);
            this.Name = "GeradorDeAcorde";
            this.Text = "Gerador de Escala";
            this.Load += new System.EventHandler(this.frmGeradorDeEscala_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmGeradorDeEscala_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEscalas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timTimer;
        private System.Windows.Forms.ComboBox cbNotas;
        private System.Windows.Forms.Button btnProcessar;
        private System.Windows.Forms.DataGridView dtgEscalas;
        private System.Windows.Forms.Panel panCanvas;
        private System.Windows.Forms.CheckBox chkAdd;
        private System.Windows.Forms.ComboBox cmbBaixo;
        private System.Windows.Forms.Label lblBaixo;
        private System.Windows.Forms.ListBox lstbNotas;
        private System.Windows.Forms.ListBox lstbBase;
        private System.Windows.Forms.ListBox lstbNotasExtensao;
        private System.Windows.Forms.ListBox lstbQuintas;
        private System.Windows.Forms.ListBox lstbNonas;
        private System.Windows.Forms.ListBox lstbDecimaPrimeira;
        private System.Windows.Forms.ListBox lstbDecimaTerceira;
        private System.Windows.Forms.Button button1;
    }
}