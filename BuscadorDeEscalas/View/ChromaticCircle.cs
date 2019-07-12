/*
 * D# = 0º
 * D = 30º
 * C# = 60º
 * C = 90º
 * B = 120º
 * A# = 150º
 * A = 180º
 * G# = 210º
 * G = 240º
 * F# = 270º
 * F = 300º
 * E = 330º
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BuscadorDeEscalas
{
    public partial class ChromaticCircle : Form
    {
        private PointF startPoint = new PointF(240.0f, 240.0f);
        private String[] arrNotesText = new String[12];
        private float[,] arrNotesPosition = new float[12, 2];
        private String[] arrIntervalsText = new String[11];
        private CheckBox[] arrChkIntervals = new CheckBox[11];
        private int[] arrIntIntervals = new int[11];

        public ChromaticCircle()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(PaintNotes);
            SetThings();
            SetNotesPositions();
        }

        private void PaintNotes(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Pen redPen = new Pen(Color.Red, 2);

            for (int i = 0; i < 12; i++)
            {
                e.Graphics.DrawString(arrNotesText[i], this.Font, Brushes.Black, arrNotesPosition[i,0],  arrNotesPosition[i,1]); 
            }
                        
        }

        private void PaintIntervals(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Pen redPen = new Pen(Color.Red, 2);
            int indexNote;
            int indexInterval;
            
            indexNote = Array.FindIndex(arrNotesText, row => row.Contains(cmbNote.Text.Trim()));

            for (int i = 0; i < 11; i++)
            {
                if (arrChkIntervals[i].Checked)
                {
                    indexInterval = indexNote + arrIntIntervals[i];
                    if (indexInterval > 11)
                    {
                        indexInterval -= 12;
                    }                    
                    e.Graphics.DrawLine(redPen, new PointF(arrNotesPosition[indexNote, 0], arrNotesPosition[indexNote, 1]), new PointF(arrNotesPosition[indexInterval, 0], arrNotesPosition[indexInterval, 1]));
                }
            }            
            
        }

        private void tmrAppTimer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void SetNotesPositions ()
        {            
            float pX = 0.0f;
            float pY = 0.0f;
            float angle = 0.0f;                               

            for (int i = 0; i < 12; i++)
            {
                float angleRad = (float)(angle * (Math.PI / 180.0f));
                pY = (float)Math.Sin(angleRad) * 100.0f;               
                pX = (float)Math.Sqrt(Math.Pow(100, 2) - Math.Pow(pY, 2));
                            
                if (angle >= 90.0f && angle <= 180.0f)
                {
                    pX = pX * -1;
                }
                else if (angle >= 180.0f && angle <= 270.0f)
                {
                    pX = pX * -1;
                }           
                
                pY += startPoint.Y;
                pX += startPoint.X;
                arrNotesPosition[i, 0] = pX;
                arrNotesPosition[i, 1] = pY;                
                angle += 30.0f;
            }           
        }

        private void SetThings ()
        {
            arrNotesText[0] = "C";
            arrNotesText[1] = "C#";
            arrNotesText[2] = "D";
            arrNotesText[3] = "D#";
            arrNotesText[4] = "E";
            arrNotesText[5] = "F";
            arrNotesText[6] = "F#";
            arrNotesText[7] = "G";
            arrNotesText[8] = "G#";
            arrNotesText[9] = "A";
            arrNotesText[10] = "A#";
            arrNotesText[11] = "B";

            arrIntervalsText[0] = "2b";
            arrIntervalsText[1] = "2";
            arrIntervalsText[2] = "3m";
            arrIntervalsText[3] = "3M";
            arrIntervalsText[4] = "4";
            arrIntervalsText[5] = "5b";
            arrIntervalsText[6] = "5";
            arrIntervalsText[7] = "5#";
            arrIntervalsText[8] = "6";
            arrIntervalsText[9] = "7";
            arrIntervalsText[10] = "7M";

            arrChkIntervals[0] = chk2b;
            arrChkIntervals[1] = chk2;
            arrChkIntervals[2] = chk3menor;
            arrChkIntervals[3] = chk3Maior;
            arrChkIntervals[4] = chk4;
            arrChkIntervals[5] = chk5b;
            arrChkIntervals[6] = chk5;
            arrChkIntervals[7] = chk5Aumentada;
            arrChkIntervals[8] = chk6;
            arrChkIntervals[9] = chk7;
            arrChkIntervals[10] = chk7M;

            arrIntIntervals[0] = 1;
            arrIntIntervals[1] = 2;
            arrIntIntervals[2] = 3;
            arrIntIntervals[3] = 4;
            arrIntIntervals[4] = 5;
            arrIntIntervals[5] = 6;
            arrIntIntervals[6] = 7;
            arrIntIntervals[7] = 8;
            arrIntIntervals[8] = 9;
            arrIntIntervals[9] = 10;
            arrIntIntervals[10] = 11;
        }
               

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(PaintIntervals);

        }
    }
}
