using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscadorDeEscalas
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void tstItemBuscadorDeEscalas_Click(object sender, EventArgs e)
        {
            BuscadorDeEscala nextForm = new BuscadorDeEscala();
            nextForm.ShowDialog();
        }

        private void tstItemGE_Teclado_Click(object sender, EventArgs e)
        {
            frmGeradorDeEscala nextForm = new frmGeradorDeEscala();
            nextForm.ShowDialog();
        }

        private void tstItemGE_Guitarra_Click(object sender, EventArgs e)
        {
            frmGeradorDeEscala_Guitarra nextForm = new frmGeradorDeEscala_Guitarra();
            nextForm.ShowDialog();
        }

        private void tstItemGeradorDeCampoHarmonico_Click(object sender, EventArgs e)
        {
            GeradorDeCampoHarmonico nextForm = new GeradorDeCampoHarmonico();
            nextForm.ShowDialog();
        }

        private void ciclosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChromaticCircle nextForm = new ChromaticCircle();
            nextForm.ShowDialog();
        }

        private void intervalosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntervalsTable nextForm = new IntervalsTable();
            nextForm.ShowDialog();
        }

        private void iteradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IteradorDeIntervalos nextForm = new IteradorDeIntervalos();
            nextForm.ShowDialog();
        }

        private void geradorDeAcordesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeradorDeAcorde nextForm = new GeradorDeAcorde();
            nextForm.ShowDialog();
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeclaTesteForm nextForm = new TeclaTesteForm();
            nextForm.ShowDialog();
        }

        private void geradorDeIntervalosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGeradorDeIntervalos nextForm = new frmGeradorDeIntervalos();
            nextForm.ShowDialog();
        }
    }
}
