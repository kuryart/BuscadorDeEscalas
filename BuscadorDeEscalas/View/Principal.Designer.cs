namespace BuscadorDeEscalas
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.tstMenuSuperior = new System.Windows.Forms.ToolStrip();
            this.tstArquivo = new System.Windows.Forms.ToolStripDropDownButton();
            this.testeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstFerramentas = new System.Windows.Forms.ToolStripDropDownButton();
            this.tstItemBuscadorDeEscalas = new System.Windows.Forms.ToolStripMenuItem();
            this.tstItemGeradorDeEscalas = new System.Windows.Forms.ToolStripMenuItem();
            this.tstItemGE_Teclado = new System.Windows.Forms.ToolStripMenuItem();
            this.tstItemGE_Guitarra = new System.Windows.Forms.ToolStripMenuItem();
            this.tstItemGeradorDeCampoHarmonico = new System.Windows.Forms.ToolStripMenuItem();
            this.geradorDeAcordesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstItemConsulta = new System.Windows.Forms.ToolStripDropDownButton();
            this.ciclosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iteradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pctIntro = new System.Windows.Forms.PictureBox();
            this.geradorDeIntervalosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstMenuSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctIntro)).BeginInit();
            this.SuspendLayout();
            // 
            // tstMenuSuperior
            // 
            this.tstMenuSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstArquivo,
            this.tstFerramentas,
            this.tstItemConsulta});
            this.tstMenuSuperior.Location = new System.Drawing.Point(0, 0);
            this.tstMenuSuperior.Name = "tstMenuSuperior";
            this.tstMenuSuperior.Size = new System.Drawing.Size(788, 25);
            this.tstMenuSuperior.TabIndex = 1;
            this.tstMenuSuperior.Text = "toolStrip1";
            // 
            // tstArquivo
            // 
            this.tstArquivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tstArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testeToolStripMenuItem});
            this.tstArquivo.Image = ((System.Drawing.Image)(resources.GetObject("tstArquivo.Image")));
            this.tstArquivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstArquivo.Name = "tstArquivo";
            this.tstArquivo.Size = new System.Drawing.Size(62, 22);
            this.tstArquivo.Text = "Arquivo";
            // 
            // testeToolStripMenuItem
            // 
            this.testeToolStripMenuItem.Name = "testeToolStripMenuItem";
            this.testeToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.testeToolStripMenuItem.Text = "Teste";
            this.testeToolStripMenuItem.Click += new System.EventHandler(this.testeToolStripMenuItem_Click);
            // 
            // tstFerramentas
            // 
            this.tstFerramentas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tstFerramentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstItemBuscadorDeEscalas,
            this.tstItemGeradorDeEscalas,
            this.tstItemGeradorDeCampoHarmonico,
            this.geradorDeAcordesToolStripMenuItem,
            this.geradorDeIntervalosToolStripMenuItem});
            this.tstFerramentas.Image = ((System.Drawing.Image)(resources.GetObject("tstFerramentas.Image")));
            this.tstFerramentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstFerramentas.Name = "tstFerramentas";
            this.tstFerramentas.Size = new System.Drawing.Size(85, 22);
            this.tstFerramentas.Text = "Ferramentas";
            // 
            // tstItemBuscadorDeEscalas
            // 
            this.tstItemBuscadorDeEscalas.Name = "tstItemBuscadorDeEscalas";
            this.tstItemBuscadorDeEscalas.Size = new System.Drawing.Size(237, 22);
            this.tstItemBuscadorDeEscalas.Text = "Buscador de Escalas";
            this.tstItemBuscadorDeEscalas.Click += new System.EventHandler(this.tstItemBuscadorDeEscalas_Click);
            // 
            // tstItemGeradorDeEscalas
            // 
            this.tstItemGeradorDeEscalas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstItemGE_Teclado,
            this.tstItemGE_Guitarra});
            this.tstItemGeradorDeEscalas.Name = "tstItemGeradorDeEscalas";
            this.tstItemGeradorDeEscalas.Size = new System.Drawing.Size(237, 22);
            this.tstItemGeradorDeEscalas.Text = "Gerador de Escalas";
            // 
            // tstItemGE_Teclado
            // 
            this.tstItemGE_Teclado.Name = "tstItemGE_Teclado";
            this.tstItemGE_Teclado.Size = new System.Drawing.Size(116, 22);
            this.tstItemGE_Teclado.Text = "Teclado";
            this.tstItemGE_Teclado.Click += new System.EventHandler(this.tstItemGE_Teclado_Click);
            // 
            // tstItemGE_Guitarra
            // 
            this.tstItemGE_Guitarra.Name = "tstItemGE_Guitarra";
            this.tstItemGE_Guitarra.Size = new System.Drawing.Size(116, 22);
            this.tstItemGE_Guitarra.Text = "Guitarra";
            this.tstItemGE_Guitarra.Click += new System.EventHandler(this.tstItemGE_Guitarra_Click);
            // 
            // tstItemGeradorDeCampoHarmonico
            // 
            this.tstItemGeradorDeCampoHarmonico.Name = "tstItemGeradorDeCampoHarmonico";
            this.tstItemGeradorDeCampoHarmonico.Size = new System.Drawing.Size(237, 22);
            this.tstItemGeradorDeCampoHarmonico.Text = "Gerador de Campo Harmônico";
            this.tstItemGeradorDeCampoHarmonico.Click += new System.EventHandler(this.tstItemGeradorDeCampoHarmonico_Click);
            // 
            // geradorDeAcordesToolStripMenuItem
            // 
            this.geradorDeAcordesToolStripMenuItem.Name = "geradorDeAcordesToolStripMenuItem";
            this.geradorDeAcordesToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.geradorDeAcordesToolStripMenuItem.Text = "Gerador de Acordes";
            this.geradorDeAcordesToolStripMenuItem.Click += new System.EventHandler(this.geradorDeAcordesToolStripMenuItem_Click);
            // 
            // tstItemConsulta
            // 
            this.tstItemConsulta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tstItemConsulta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ciclosToolStripMenuItem,
            this.intervalosToolStripMenuItem,
            this.iteradorToolStripMenuItem});
            this.tstItemConsulta.Image = ((System.Drawing.Image)(resources.GetObject("tstItemConsulta.Image")));
            this.tstItemConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstItemConsulta.Name = "tstItemConsulta";
            this.tstItemConsulta.Size = new System.Drawing.Size(72, 22);
            this.tstItemConsulta.Text = "Consultas";
            // 
            // ciclosToolStripMenuItem
            // 
            this.ciclosToolStripMenuItem.Name = "ciclosToolStripMenuItem";
            this.ciclosToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.ciclosToolStripMenuItem.Text = "Ciclos";
            this.ciclosToolStripMenuItem.Click += new System.EventHandler(this.ciclosToolStripMenuItem_Click);
            // 
            // intervalosToolStripMenuItem
            // 
            this.intervalosToolStripMenuItem.Name = "intervalosToolStripMenuItem";
            this.intervalosToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.intervalosToolStripMenuItem.Text = "Intervalos";
            this.intervalosToolStripMenuItem.Click += new System.EventHandler(this.intervalosToolStripMenuItem_Click);
            // 
            // iteradorToolStripMenuItem
            // 
            this.iteradorToolStripMenuItem.Name = "iteradorToolStripMenuItem";
            this.iteradorToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.iteradorToolStripMenuItem.Text = "Iterador";
            this.iteradorToolStripMenuItem.Click += new System.EventHandler(this.iteradorToolStripMenuItem_Click);
            // 
            // pctIntro
            // 
            this.pctIntro.Image = global::BuscadorDeEscalas.Properties.Resources.intro;
            this.pctIntro.Location = new System.Drawing.Point(29, 61);
            this.pctIntro.Name = "pctIntro";
            this.pctIntro.Size = new System.Drawing.Size(714, 349);
            this.pctIntro.TabIndex = 0;
            this.pctIntro.TabStop = false;
            // 
            // geradorDeIntervalosToolStripMenuItem
            // 
            this.geradorDeIntervalosToolStripMenuItem.Name = "geradorDeIntervalosToolStripMenuItem";
            this.geradorDeIntervalosToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.geradorDeIntervalosToolStripMenuItem.Text = "Gerador de Intervalos";
            this.geradorDeIntervalosToolStripMenuItem.Click += new System.EventHandler(this.geradorDeIntervalosToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 450);
            this.Controls.Add(this.tstMenuSuperior);
            this.Controls.Add(this.pctIntro);
            this.Name = "Principal";
            this.Text = "Principal";
            this.tstMenuSuperior.ResumeLayout(false);
            this.tstMenuSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctIntro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctIntro;
        private System.Windows.Forms.ToolStrip tstMenuSuperior;
        private System.Windows.Forms.ToolStripDropDownButton tstArquivo;
        private System.Windows.Forms.ToolStripDropDownButton tstFerramentas;
        private System.Windows.Forms.ToolStripMenuItem tstItemBuscadorDeEscalas;
        private System.Windows.Forms.ToolStripMenuItem tstItemGeradorDeEscalas;
        private System.Windows.Forms.ToolStripMenuItem tstItemGE_Teclado;
        private System.Windows.Forms.ToolStripMenuItem tstItemGE_Guitarra;
        private System.Windows.Forms.ToolStripMenuItem tstItemGeradorDeCampoHarmonico;
        private System.Windows.Forms.ToolStripDropDownButton tstItemConsulta;
        private System.Windows.Forms.ToolStripMenuItem ciclosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intervalosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iteradorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geradorDeAcordesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geradorDeIntervalosToolStripMenuItem;
    }
}