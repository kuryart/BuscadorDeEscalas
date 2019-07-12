using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BuscadorDeEscalas
{
    public partial class frmGeradorDeIntervalos : Form
    {
        #region Variaveis
        // Branca
        float brancaIniPosX = 0;
        float brancaIniPosY = 0;
        float brancaWidth = 30;
        float brancaHeight = 100;
        float brancaProxPosX;

        // Preta
        float pretaIniPosX;
        float pretaIniPosY;
        float pretaWidth1;
        float pretaWidth2;
        float pretaWidth3;
        float pretaHeight;
        float pretaProxPosX;

        // Offset
        float offsetX = 0;
        float offsetY = 0;

        // Número de Teclas
        int numTeclas = 7;

        // Número de oitavas
        int numOitavas = 2;
        int oitavaAtual = 0;

        // Intervalos e Notas
        Intervalos intervalosDaEscala = new Intervalos();
        Notas notasDaEscala = new Notas();

        // Geral 
        bool isFirstTimeBranca = true;
        bool isFirstTimePreta = true;
        bool isLoaded = false;

        // Graphics e Bitmaps
        Graphics graphics;
        Bitmap bitmap;
        int bpmWidth;
        int bpmHeight;
        SolidBrush colorNoteSelected = new SolidBrush(Color.CadetBlue);
        SolidBrush colorNoteTonica = new SolidBrush(Color.FromArgb(255,180,20,20));

        #endregion

        // Construtor
        public frmGeradorDeIntervalos()
        {
            InitializeComponent();
        }

        private void frmGeradorDeEscala_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            bpmWidth = (int)Math.Ceiling(brancaWidth * 7 * numOitavas) + 1;
            bpmHeight = (int)Math.Ceiling(brancaHeight) + 1;

            bitmap = new Bitmap(bpmWidth, bpmHeight);
            graphics = Graphics.FromImage(bitmap);
            //Graphics g = Graphics.FromImage(bitmap);
            //graphics = Graphics.FromImage(bitmap);
        }

/*
        #region PintaTeclas
        private void PaintTeclaBranca(object sender, PaintEventArgs e)
        {
            if (oitavaAtual >= numOitavas)
            {
                return;
            }

            if (!isFirstTimeBranca)
            {
                brancaIniPosX = brancaProxPosX + brancaWidth;
                brancaProxPosX = brancaIniPosX;
            }
                        
            if (notasDaEscala.notasSelecionadas.Any(x => x.id == 0))
            {
                graphics.FillRectangle(colorNoteSelected, brancaIniPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            else
            {
                graphics.FillRectangle(Brushes.White, brancaIniPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            graphics.DrawRectangle(Pens.Black, brancaIniPosX, brancaIniPosY, brancaWidth, brancaHeight);

            brancaProxPosX += brancaWidth;

            if (notasDaEscala.notasSelecionadas.Any(x => x.id == 2))
            {
                graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            else
            {
                graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

            brancaProxPosX += brancaWidth;

            if (notasDaEscala.notasSelecionadas.Any(x => x.id == 4))
            {
                graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            else
            {
                graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

            brancaProxPosX += brancaWidth;

            if (notasDaEscala.notasSelecionadas.Any(x => x.id == 5))
            {
                graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            else
            {
                graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

            brancaProxPosX += brancaWidth;

            if (notasDaEscala.notasSelecionadas.Any(x => x.id == 7))
            {
                graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            else
            {
                graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

            brancaProxPosX += brancaWidth;

            if (notasDaEscala.notasSelecionadas.Any(x => x.id == 9))
            {
                graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            else
            {
                graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

            brancaProxPosX += brancaWidth;

            if (notasDaEscala.notasSelecionadas.Any(x => x.id == 11))
            {
                graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            else
            {
                graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

            isFirstTimeBranca = false;
        }

        private void PaintTeclaPreta(object sender, PaintEventArgs e)
        {
            if (oitavaAtual >= numOitavas)
            {                
                return;
            }

            pretaWidth2 = (brancaWidth * 7) / 12;
            pretaWidth1 = ((brancaWidth * 3) - (pretaWidth2 * 3)) / 2;
            pretaWidth3 = ((brancaWidth * 4) - (pretaWidth2 * 5)) / 2;

            // Parte1
            pretaIniPosX = brancaIniPosX + pretaWidth1;

            if (notasDaEscala.notasSelecionadas.Any(x => x.id == 1))
            {
                graphics.FillRectangle(colorNoteSelected, pretaIniPosX, pretaIniPosY, pretaWidth2, pretaHeight);
            }
            else
            {
                graphics.FillRectangle(Brushes.Black, pretaIniPosX, pretaIniPosY, pretaWidth2, pretaHeight);
            }
            
            graphics.DrawRectangle(Pens.Black, pretaIniPosX, pretaIniPosY, pretaWidth2, pretaHeight);

            pretaProxPosX = pretaIniPosX + (pretaWidth2 * 2);

            if (notasDaEscala.notasSelecionadas.Any(x => x.id == 3))
            {
                graphics.FillRectangle(colorNoteSelected, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
            }
            else
            {
                graphics.FillRectangle(Brushes.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
            }            
            graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);

            // Parte2
            pretaProxPosX = pretaProxPosX + pretaWidth2 + pretaWidth1 + pretaWidth3;

            if (notasDaEscala.notasSelecionadas.Any(x => x.id == 6))
            {
                graphics.FillRectangle(colorNoteSelected, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
            }
            else
            {
                graphics.FillRectangle(Brushes.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
            }            
            graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);

            pretaProxPosX = pretaProxPosX + (pretaWidth2 * 2);

            if (notasDaEscala.notasSelecionadas.Any(x => x.id == 8))
            {
                graphics.FillRectangle(colorNoteSelected, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
            }
            else
            {
                graphics.FillRectangle(Brushes.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
            }
            graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
            graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);

            pretaProxPosX = pretaProxPosX + (pretaWidth2 * 2);

            if (notasDaEscala.notasSelecionadas.Any(x => x.id == 10))
            {
                graphics.FillRectangle(colorNoteSelected, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
            }
            else
            {
                graphics.FillRectangle(Brushes.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
            }
            graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
            graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);

            oitavaAtual += 1;
        }
        #endregion
*/


        #region PintaTeclas
        private void PaintTeclaBranca(object sender, PaintEventArgs e)
        {
            if (oitavaAtual >= numOitavas)
            {
                return;
            }

            bitmap = new Bitmap(bpmWidth, bpmHeight);
            graphics = Graphics.FromImage(bitmap);
            int idTonica = notasDaEscala.notasSelecionadas[0].id;

            //            using (Graphics graphics = Graphics.FromImage(bitmap))
            //            {
            for (int i = 0; i < numOitavas; i++)
            {
                if (!isFirstTimeBranca)
                {
                    brancaIniPosX = 0;
                    brancaProxPosX = brancaIniPosX;
                }

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 0))
                {
                    if (idTonica == 0)
                    {
                        graphics.FillRectangle(colorNoteTonica, brancaIniPosX + (brancaWidth * 7 * i), brancaIniPosY, brancaWidth, brancaHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(colorNoteSelected, brancaIniPosX + (brancaWidth * 7 * i), brancaIniPosY, brancaWidth, brancaHeight);
                    }                    
                }
                else
                {
                    graphics.FillRectangle(Brushes.White, brancaIniPosX + (brancaWidth * 7 * i), brancaIniPosY, brancaWidth, brancaHeight);
                }
                graphics.DrawRectangle(Pens.Black, brancaIniPosX + (brancaWidth * 7 * i), brancaIniPosY, brancaWidth, brancaHeight);

                if (i == 0)
                {
                    brancaProxPosX += brancaWidth;
                }
                else
                {
                    brancaProxPosX += brancaWidth * 2;
                }

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 2))
                {
                    if (idTonica == 2)
                    {
                        graphics.FillRectangle(colorNoteTonica, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                    }                    
                }
                else
                {
                    graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

                brancaProxPosX += brancaWidth;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 4))
                {
                    if (idTonica == 4)
                    {
                        graphics.FillRectangle(colorNoteTonica, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                    }
                }
                else
                {
                    graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

                brancaProxPosX += brancaWidth;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 5))
                {
                    if (idTonica == 5)
                    {
                        graphics.FillRectangle(colorNoteTonica, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                    }
                }
                else
                {
                    graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

                brancaProxPosX += brancaWidth;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 7))
                {
                    if (idTonica == 7)
                    {
                        graphics.FillRectangle(colorNoteTonica, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                    }
                }
                else
                {
                    graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

                brancaProxPosX += brancaWidth;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 9))
                {
                    if (idTonica == 9)
                    {
                        graphics.FillRectangle(colorNoteTonica, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                    }
                }
                else
                {
                    graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

                brancaProxPosX += brancaWidth;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 11))
                {
                    if (idTonica == 11)
                    {
                        graphics.FillRectangle(colorNoteTonica, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                    }
                }
                else
                {
                    graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            isFirstTimeBranca = false;
            //graphics2 = graphics;
            //panCanvas.DrawToBitmap(bitmap, new Rectangle(panCanvas.Location.X, panCanvas.Location.Y, panCanvas.Width, panCanvas.Height));
            //Invalidate();
            //            }
        }

        private void PaintTeclaPreta(object sender, PaintEventArgs e)
        {
            if (oitavaAtual >= numOitavas)
            {
                return;
            }

            int idTonica = notasDaEscala.notasSelecionadas[0].id;

            for (int i = 0; i < numOitavas; i++)
            {
                if (!isFirstTimePreta)
                {
                    brancaIniPosX = brancaProxPosX + brancaWidth;
                    brancaProxPosX = brancaIniPosX;
                }

                pretaWidth2 = (brancaWidth * 7) / 12;
                pretaWidth1 = ((brancaWidth * 3) - (pretaWidth2 * 3)) / 2;
                pretaWidth3 = ((brancaWidth * 4) - (pretaWidth2 * 5)) / 2;

                // Parte1
                pretaIniPosX = brancaIniPosX + (brancaWidth * 7 * i) + pretaWidth1;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 1))
                {
                    if (idTonica == 1)
                    {
                        graphics.FillRectangle(colorNoteTonica, pretaIniPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(colorNoteSelected, pretaIniPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                    }
                }
                else
                {
                    graphics.FillRectangle(Brushes.Black, pretaIniPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                graphics.DrawRectangle(Pens.Black, pretaIniPosX, pretaIniPosY, pretaWidth2, pretaHeight);

                pretaProxPosX = pretaIniPosX + (pretaWidth2 * 2);

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 3))
                {
                    if (idTonica == 3)
                    {
                        graphics.FillRectangle(colorNoteTonica, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(colorNoteSelected, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                    }
                }
                else
                {
                    graphics.FillRectangle(Brushes.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);

                // Parte2
                pretaProxPosX = pretaProxPosX + pretaWidth2 + pretaWidth1 + pretaWidth3;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 6))
                {
                    if (idTonica == 6)
                    {
                        graphics.FillRectangle(colorNoteTonica, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(colorNoteSelected, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                    }
                }
                else
                {
                    graphics.FillRectangle(Brushes.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);

                pretaProxPosX = pretaProxPosX + (pretaWidth2 * 2);

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 8))
                {
                    if (idTonica == 8)
                    {
                        graphics.FillRectangle(colorNoteTonica, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(colorNoteSelected, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                    }
                }
                else
                {
                    graphics.FillRectangle(Brushes.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);

                pretaProxPosX = pretaProxPosX + (pretaWidth2 * 2);

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 10))
                {
                    if (idTonica == 10)
                    {
                        graphics.FillRectangle(colorNoteTonica, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(colorNoteSelected, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                    }
                }
                else
                {
                    graphics.FillRectangle(Brushes.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                oitavaAtual += 1;
            }
            isFirstTimePreta = false;
            graphics.Flush(FlushIntention.Sync);
            graphics.Save();
                
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        #endregion

/*
        #region PintaTeclas
        private void PaintTeclaBranca(object sender, PaintEventArgs e)
        {
            if (oitavaAtual >= numOitavas)
            {
                return;
            }

            //            using (e.Graphics e.Graphics = e.Graphics.FromImage(bitmap))
            //            {
            for (int i = 0; i < numOitavas; i++)
            {
                if (!isFirstTimeBranca)
                {
                    brancaIniPosX = 0;
                    brancaProxPosX = brancaIniPosX;
                }

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 0))
                {
                    e.Graphics.FillRectangle(colorNoteSelected, brancaIniPosX + (brancaWidth * 7 * i), brancaIniPosY, brancaWidth, brancaHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, brancaIniPosX + (brancaWidth * 7 * i), brancaIniPosY, brancaWidth, brancaHeight);
                }
                e.Graphics.DrawRectangle(Pens.Black, brancaIniPosX + (brancaWidth * 7 * i), brancaIniPosY, brancaWidth, brancaHeight);

                if (i == 0)
                {
                    brancaProxPosX += brancaWidth;
                }
                else
                {
                    brancaProxPosX += brancaWidth * 2;
                }

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 2))
                {
                    e.Graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                e.Graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

                brancaProxPosX += brancaWidth;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 4))
                {
                    e.Graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                e.Graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

                brancaProxPosX += brancaWidth;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 5))
                {
                    e.Graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                e.Graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

                brancaProxPosX += brancaWidth;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 7))
                {
                    e.Graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                e.Graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

                brancaProxPosX += brancaWidth;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 9))
                {
                    e.Graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                e.Graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);

                brancaProxPosX += brancaWidth;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 11))
                {
                    e.Graphics.FillRectangle(colorNoteSelected, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
                }
                e.Graphics.DrawRectangle(Pens.Black, brancaProxPosX, brancaIniPosY, brancaWidth, brancaHeight);
            }
            isFirstTimeBranca = false;
            //e.Graphics2 = e.Graphics;
            //panCanvas.DrawToBitmap(bitmap, new Rectangle(panCanvas.Location.X, panCanvas.Location.Y, panCanvas.Width, panCanvas.Height));
            //Invalidate();
            //            }
        }

        private void PaintTeclaPreta(object sender, PaintEventArgs e)
        {
            if (oitavaAtual >= numOitavas)
            {
                return;
            }

            //            using (e.Graphics e.Graphics = e.Graphics.FromImage(bitmap))
            //            {
            for (int i = 0; i < numOitavas; i++)
            {
                if (!isFirstTimePreta)
                {
                    brancaIniPosX = brancaProxPosX + brancaWidth;
                    brancaProxPosX = brancaIniPosX;
                }

                pretaWidth2 = (brancaWidth * 7) / 12;
                pretaWidth1 = ((brancaWidth * 3) - (pretaWidth2 * 3)) / 2;
                pretaWidth3 = ((brancaWidth * 4) - (pretaWidth2 * 5)) / 2;

                // Parte1
                pretaIniPosX = brancaIniPosX + (brancaWidth * 7 * i) + pretaWidth1;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 1))
                {
                    e.Graphics.FillRectangle(colorNoteSelected, pretaIniPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Black, pretaIniPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }

                e.Graphics.DrawRectangle(Pens.Black, pretaIniPosX, pretaIniPosY, pretaWidth2, pretaHeight);

                pretaProxPosX = pretaIniPosX + (pretaWidth2 * 2);

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 3))
                {
                    e.Graphics.FillRectangle(colorNoteSelected, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                e.Graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);

                // Parte2
                pretaProxPosX = pretaProxPosX + pretaWidth2 + pretaWidth1 + pretaWidth3;

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 6))
                {
                    e.Graphics.FillRectangle(colorNoteSelected, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                e.Graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);

                pretaProxPosX = pretaProxPosX + (pretaWidth2 * 2);

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 8))
                {
                    e.Graphics.FillRectangle(colorNoteSelected, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                e.Graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                e.Graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);

                pretaProxPosX = pretaProxPosX + (pretaWidth2 * 2);

                if (notasDaEscala.notasSelecionadas.Any(x => x.id == 10))
                {
                    e.Graphics.FillRectangle(colorNoteSelected, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                }
                e.Graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                e.Graphics.DrawRectangle(Pens.Black, pretaProxPosX, pretaIniPosY, pretaWidth2, pretaHeight);
                oitavaAtual += 1;
            }
            isFirstTimePreta = false;
            //e.Graphics2 = e.Graphics;
            //panCanvas.DrawToBitmap(bitmap, new Rectangle(panCanvas.Location.X, panCanvas.Location.Y, panCanvas.Width, panCanvas.Height));
            //Invalidate();
            //            }
        }
        #endregion
*/

        private DataSet LeXMLEscalas()
        {
            XmlDocument xml = new XmlDocument();
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\XML\scales.xml";
            path = path.Replace(@"\bin\Debug\", "");
            xml.Load(path);
            DataSet dataSetXml = new DataSet();
            dataSetXml.ReadXml(path);
            return dataSetXml;
        }

        private void PreencheTabela()
        {
            DataSet dataSetTodasEscalas = LeXMLEscalas();
            dtgEscalas.DataSource = dataSetTodasEscalas.Tables[0];
            foreach (DataGridViewTextBoxColumn c in dtgEscalas.Columns)
            {
                dtgEscalas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }            
        }

        private void GetNotas()
        {
            foreach (Nota nota in Notas.todasNotas)
            {
                cbNotas.Items.Add(nota.nome);
            }
            cbNotas.SelectedIndex = 0;
        }

        private void SetIntervalosEscala()
        {
            if (!isLoaded)
            {
                return;
            }

            if (dtgEscalas.SelectedRows.Count == 0)
            {
                return;
            }

            intervalosDaEscala.Clear();

            DataGridViewRow row = dtgEscalas.SelectedRows[0];
            string intervalsID = row.Cells[1].Value.ToString().Trim();
            string[] intervalsIDSplit = intervalsID.Split(",".ToCharArray());

            foreach (string interval in intervalsIDSplit)
            {
                intervalosDaEscala.Add(Convert.ToInt32(interval) - 1);
            }

            foreach (Intervalo interval in intervalosDaEscala)
            {
                Console.WriteLine(interval.nome + " - " + interval.id);
            }
        }

        private void SetNotasEscala()
        {
            if (!isLoaded)
            {
                return;
            }

            notasDaEscala.Clear();

            Nota tonica = Notas.todasNotas.notasSelecionadas.Find(x => x.nome.Trim() == cbNotas.Text.Trim());

            if (tonica == null)
            {
                MessageBox.Show("Teste");
                return;
            }

            foreach (Intervalo intervalo in intervalosDaEscala)
            {
                notasDaEscala.Add(Notas.CalculaNota(tonica, intervalo));
            }

            foreach (Nota nota in notasDaEscala)
            {
                Console.WriteLine(nota.nome + " - " + nota.id);
            }
        }

        private void timTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
            
        }

        private void dtgEscalas_SelectionChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
            {
                return;
            }

            oitavaAtual = 0;
            isFirstTimeBranca = true;
            isFirstTimePreta = true;
            brancaIniPosX = 0;
            brancaIniPosX = brancaIniPosX + offsetX;
            brancaIniPosY = brancaIniPosY + offsetY;
            brancaProxPosX = brancaIniPosX;
            pretaProxPosX = pretaIniPosX;
            pretaIniPosY = brancaIniPosY;
            SetIntervalosEscala();
            SetNotasEscala();
            Refresh();
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            if (cbFerramentas.Text == "Todos Intervalos")
            {
                string[] intervalsIDSplit;        

                for (int i = 0; i < cbNotas.Items.Count; i++)
                {
                    cbNotas.SelectedIndex = i;

                    for (int j = 0; j < dtgEscalas.Rows.Count; j++)
                    {
                        dtgEscalas.Rows[j].Selected = true;
                        // intervalsIDSplit = dtgEscalas.SelectedRows[0].Cells[1].Value.ToString().Split(",".ToCharArray());
                        // if (intervalsIDSplit.Length == 2)
                        // {
                        //     SalvaImagem();
                        // }
                        SalvaImagem();
                    }
                    GeraPdf();
                }
            } 
            else
            {
                for (int i = 0; i < dtgEscalas.Rows.Count; i++)
                {
                    dtgEscalas.Rows[i].Selected = true;
                    for (int j = 0; j < cbNotas.Items.Count; j++)
                    {
                        cbNotas.SelectedIndex = j;
                        SalvaImagem();
                    }
                    GeraPdf();
                }
            }

            //MessageBox.Show(dtgEscalas.Rows.Count.ToString());
        }

        private void cbNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
            {
                return;
            }

            oitavaAtual = 0;
            isFirstTimeBranca = true;
            isFirstTimePreta = true;
            brancaIniPosX = 0;
            brancaIniPosX = brancaIniPosX + offsetX;
            brancaIniPosY = brancaIniPosY + offsetY;
            brancaProxPosX = brancaIniPosX;
            pretaProxPosX = pretaIniPosX;
            pretaIniPosY = brancaIniPosY;
            SetIntervalosEscala();
            SetNotasEscala();
            Refresh();
        }

        private void frmGeradorDeEscala_Paint(object sender, PaintEventArgs e)
        {
            if (!isLoaded)
            {
                PreencheTabela();
                GetNotas();
                SetIntervalosEscala();
                SetNotasEscala();

                brancaIniPosX = brancaIniPosX + offsetX;
                brancaIniPosY = brancaIniPosY + offsetY;
                brancaProxPosX = brancaIniPosX;
                pretaProxPosX = pretaIniPosX;
                pretaIniPosY = brancaIniPosY;
                pretaHeight = 0.6f * brancaHeight;
                panCanvas.Paint += PaintTeclaBranca;
                panCanvas.Paint += PaintTeclaPreta;
                isLoaded = true;
                dtgEscalas.Rows[1].Selected = true;
                dtgEscalas.Rows[0].Selected = true;
            }
        }

        private void SalvaImagem()
        {
            string[] intervalsIDSplit = dtgEscalas.SelectedRows[0].Cells[1].Value.ToString().Split(",".ToCharArray());
            string intervalName = "";
            if (Intervalos.todosIntervalos1[Convert.ToInt32(intervalsIDSplit[1]) - 1].nome == "3m")
            {
                intervalName = "menor";
            }
            else
            {
                intervalName = Intervalos.todosIntervalos1[Convert.ToInt32(intervalsIDSplit[1]) - 1].nome;
            }            
            string noteName = cbNotas.SelectedItem.ToString().Trim();
            string path = @"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\Imagens\";
            CheckFolderExists(path);
            Bitmap bm = new Bitmap(bitmap);
            bitmap.Dispose();
            try
            {
                bm.Save(path + @"\" + noteName + intervalName + ".png", ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um problema ao salvar a imagem. Verifique se o caminho de destino necessita de permissões de administrador.");
                //throw;
            }
            finally
            {
                bm.Dispose();
                bitmap.Dispose();
            }
        }

        private void CheckFolderExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void GeraPdf()
        {
            Document doc = new Document(PageSize.A4);//criando e estipulando o tipo da folha usada
            doc.SetMargins(40, 40, 40, 80);//estibulando o espaçamento das margens que queremos
            doc.AddCreationDate();//adicionando as configuracoes

            //caminho onde sera criado o pdf + nome desejado
            //OBS: o nome sempre deve ser terminado com .pdf
            string noteName = cbNotas.SelectedItem.ToString().Trim();
            string caminho = @"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\" + noteName + ".pdf";
            
            //criando o arquivo pdf embranco, passando como parametro a variavel                
            //doc criada acima e a variavel caminho 
            //tambem criada acima.
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            //criando uma string vazia
            string dados = "";

            //criando a variavel para paragrafo
            Paragraph paragrafo = new Paragraph(0.0f, dados, new iTextSharp.text.Font());
            //etipulando o alinhamneto
            paragrafo.Alignment = Element.ALIGN_CENTER;
            //Alinhamento Justificado
            //adicioando texto
            paragrafo.Add(noteName);
            paragrafo.Font.Size = 24.0f;
            paragrafo.Font.SetStyle("bold");

            //acidionado paragrafo ao documento
            doc.Add(paragrafo);

            //=== ADICIONANDO IMAGENS ===
            float scaleMultiplier = 60f;
            float widthMin = 0.05f;
            float widthMax = 0.52f;
            float height1 = 0.765f;
            float height2 = 0.632f;
            float height3 = 0.499f;
            float height4 = 0.366f;
            float height5 = 0.233f;
            float height6 = 0.10f;

            //chord1
            iTextSharp.text.Image chord1 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\Imagens\" + noteName + Intervalos.todosIntervalos1[1].nome.Trim() + ".png");
            chord1.ScalePercent(scaleMultiplier);
            chord1.SetAbsolutePosition(doc.PageSize.Width * widthMin,
                                           doc.PageSize.Height * height1);
            doc.Add(chord1);
            //chord2
            iTextSharp.text.Image chord2 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\Imagens\" + noteName + Intervalos.todosIntervalos1[2].nome.Trim() + ".png");
            chord2.ScalePercent(scaleMultiplier);
            chord2.SetAbsolutePosition(doc.PageSize.Width * widthMax,
                                           doc.PageSize.Height * height1);
            doc.Add(chord2);
            //chord3
            iTextSharp.text.Image chord3 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\Imagens\" + noteName + "menor" + ".png");
            chord3.ScalePercent(scaleMultiplier);
            chord3.SetAbsolutePosition(doc.PageSize.Width * widthMin,
                                           doc.PageSize.Height * height2);
            doc.Add(chord3);
            //chord4
            iTextSharp.text.Image chord4 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\Imagens\" + noteName + Intervalos.todosIntervalos1[4].nome.Trim() + ".png");
            chord4.ScalePercent(scaleMultiplier);
            chord4.SetAbsolutePosition(doc.PageSize.Width * widthMax,
                                           doc.PageSize.Height * height2);
            doc.Add(chord4);
            //chord5
            iTextSharp.text.Image chord5 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\Imagens\" + noteName + Intervalos.todosIntervalos1[5].nome.Trim() + ".png");
            chord5.ScalePercent(scaleMultiplier);
            chord5.SetAbsolutePosition(doc.PageSize.Width * widthMin,
                                           doc.PageSize.Height * height3);
            doc.Add(chord5);
            //chord6
            iTextSharp.text.Image chord6 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\Imagens\" + noteName + Intervalos.todosIntervalos1[6].nome.Trim() + ".png");
            chord6.ScalePercent(scaleMultiplier);
            chord6.SetAbsolutePosition(doc.PageSize.Width * widthMax,
                                           doc.PageSize.Height * height3);
            doc.Add(chord6);
            //chord7
            iTextSharp.text.Image chord7 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\Imagens\" + noteName + Intervalos.todosIntervalos1[7].nome.Trim() + ".png");
            chord7.ScalePercent(scaleMultiplier);
            chord7.SetAbsolutePosition(doc.PageSize.Width * widthMin,
                                           doc.PageSize.Height * height4);
            doc.Add(chord7);
            //chord8
            iTextSharp.text.Image chord8 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\Imagens\" + noteName + Intervalos.todosIntervalos1[8].nome.Trim() + ".png");
            chord8.ScalePercent(scaleMultiplier);
            chord8.SetAbsolutePosition(doc.PageSize.Width * widthMax,
                                           doc.PageSize.Height * height4);
            doc.Add(chord8);
            //chord9
            iTextSharp.text.Image chord9 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\Imagens\" + noteName + Intervalos.todosIntervalos1[9].nome.Trim() + ".png");
            chord9.ScalePercent(scaleMultiplier);
            chord9.SetAbsolutePosition(doc.PageSize.Width * widthMin,
                                           doc.PageSize.Height * height5);
            doc.Add(chord9);
            //chord10
            iTextSharp.text.Image chord10 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\Imagens\" + noteName + Intervalos.todosIntervalos1[10].nome.Trim() + ".png");
            chord10.ScalePercent(scaleMultiplier);
            chord10.SetAbsolutePosition(doc.PageSize.Width * widthMax,
                                           doc.PageSize.Height * height5);
            doc.Add(chord10);
            //chord11
            iTextSharp.text.Image chord11 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\Imagens\" + noteName + Intervalos.todosIntervalos1[11].nome.Trim() + ".png");
            chord11.ScalePercent(scaleMultiplier);
            chord11.SetAbsolutePosition(doc.PageSize.Width * widthMin,
                                           doc.PageSize.Height * height6);
            doc.Add(chord11);
            // //chord12
            // iTextSharp.text.Image chord12 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Intervalos\Imagens\" + noteName + Intervalos.todosIntervalos1[12].nome.Trim() + ".png");
            // chord12.ScalePercent(scaleMultiplier);
            // chord12.SetAbsolutePosition(doc.PageSize.Width * widthMax,
            //                                doc.PageSize.Height * height6);
            // doc.Add(chord12);

            //=== ADICIONANDO TEXTO COM OS NOMES DOS ACORDES ===
            //chord1
            string dadosTextoAcorde1 = Intervalos.todosIntervalos1[1].nome.ToString().Trim();
            PdfContentByte cb1 = writer.DirectContent;
            float chord1_PosX = chord1.AbsoluteX + ((chord1.Width * (scaleMultiplier / 100)) / 2);
            float chord1_PosY = chord1.AbsoluteY + (chord1.Height * (scaleMultiplier / 100)) + 10f;
            cb1.BeginText();
            cb1.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb1.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde1, chord1_PosX, chord1_PosY, 0f);
            cb1.EndText();
            //chord2
            string dadosTextoAcorde2 = Intervalos.todosIntervalos1[2].nome.ToString().Trim();
            PdfContentByte cb2 = writer.DirectContent;
            float chord2_PosX = chord2.AbsoluteX + ((chord2.Width * (scaleMultiplier / 100)) / 2);
            float chord2_PosY = chord2.AbsoluteY + (chord2.Height * (scaleMultiplier / 100)) + 10f;
            cb2.BeginText();
            cb2.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb2.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde2, chord2_PosX, chord2_PosY, 0f);
            cb2.EndText();
            //chord3
            string dadosTextoAcorde3 = Intervalos.todosIntervalos1[3].nome.ToString().Trim();
            PdfContentByte cb3 = writer.DirectContent;
            float chord3_PosX = chord3.AbsoluteX + ((chord3.Width * (scaleMultiplier / 100)) / 2);
            float chord3_PosY = chord3.AbsoluteY + (chord3.Height * (scaleMultiplier / 100)) + 10f;
            cb3.BeginText();
            cb3.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb3.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde3, chord3_PosX, chord3_PosY, 0f);
            cb3.EndText();
            //chord4
            string dadosTextoAcorde4 = Intervalos.todosIntervalos1[4].nome.ToString().Trim();
            PdfContentByte cb4 = writer.DirectContent;
            float chord4_PosX = chord4.AbsoluteX + ((chord4.Width * (scaleMultiplier / 100)) / 2);
            float chord4_PosY = chord4.AbsoluteY + (chord4.Height * (scaleMultiplier / 100)) + 10f;
            cb4.BeginText();
            cb4.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb4.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde4, chord4_PosX, chord4_PosY, 0f);
            cb4.EndText();
            //chord5
            string dadosTextoAcorde5 = Intervalos.todosIntervalos1[5].nome.ToString().Trim();
            PdfContentByte cb5 = writer.DirectContent;
            float chord5_PosX = chord5.AbsoluteX + ((chord5.Width * (scaleMultiplier / 100)) / 2);
            float chord5_PosY = chord5.AbsoluteY + (chord5.Height * (scaleMultiplier / 100)) + 10f;
            cb5.BeginText();
            cb5.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb5.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde5, chord5_PosX, chord5_PosY, 0f);
            cb5.EndText();
            //chord6
            string dadosTextoAcorde6 = Intervalos.todosIntervalos1[6].nome.ToString().Trim();
            PdfContentByte cb6 = writer.DirectContent;
            float chord6_PosX = chord6.AbsoluteX + ((chord6.Width * (scaleMultiplier / 100)) / 2);
            float chord6_PosY = chord6.AbsoluteY + (chord6.Height * (scaleMultiplier / 100)) + 10f;
            cb6.BeginText();
            cb6.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb6.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde6, chord6_PosX, chord6_PosY, 0f);
            cb6.EndText();
            //chord7
            string dadosTextoAcorde7 = Intervalos.todosIntervalos1[7].nome.ToString().Trim();
            PdfContentByte cb7 = writer.DirectContent;
            float chord7_PosX = chord7.AbsoluteX + ((chord7.Width * (scaleMultiplier / 100)) / 2);
            float chord7_PosY = chord7.AbsoluteY + (chord7.Height * (scaleMultiplier / 100)) + 10f;
            cb7.BeginText();
            cb7.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb7.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde7, chord7_PosX, chord7_PosY, 0f);
            cb7.EndText();
            //chord8
            string dadosTextoAcorde8 = Intervalos.todosIntervalos1[8].nome.ToString().Trim();
            PdfContentByte cb8 = writer.DirectContent;
            float chord8_PosX = chord8.AbsoluteX + ((chord8.Width * (scaleMultiplier / 100)) / 2);
            float chord8_PosY = chord8.AbsoluteY + (chord8.Height * (scaleMultiplier / 100)) + 10f;
            cb7.BeginText();
            cb7.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb7.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde8, chord8_PosX, chord8_PosY, 0f);
            cb7.EndText();
            //chord9
            string dadosTextoAcorde9 = Intervalos.todosIntervalos1[9].nome.ToString().Trim();
            PdfContentByte cb9 = writer.DirectContent;
            float chord9_PosX = chord9.AbsoluteX + ((chord9.Width * (scaleMultiplier / 100)) / 2);
            float chord9_PosY = chord9.AbsoluteY + (chord9.Height * (scaleMultiplier / 100)) + 10f;
            cb7.BeginText();
            cb7.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb7.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde9, chord9_PosX, chord9_PosY, 0f);
            cb7.EndText();
            //chord10
            string dadosTextoAcorde10 = Intervalos.todosIntervalos1[10].nome.ToString().Trim();
            PdfContentByte cb10 = writer.DirectContent;
            float chord10_PosX = chord10.AbsoluteX + ((chord10.Width * (scaleMultiplier / 100)) / 2);
            float chord10_PosY = chord10.AbsoluteY + (chord10.Height * (scaleMultiplier / 100)) + 10f;
            cb10.BeginText();
            cb10.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb10.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde10, chord10_PosX, chord10_PosY, 0f);
            cb10.EndText();
            //chord11
            string dadosTextoAcorde11 = Intervalos.todosIntervalos1[11].nome.ToString().Trim();
            PdfContentByte cb11 = writer.DirectContent;
            float chord11_PosX = chord11.AbsoluteX + ((chord11.Width * (scaleMultiplier / 100)) / 2);
            float chord11_PosY = chord11.AbsoluteY + (chord11.Height * (scaleMultiplier / 100)) + 10f;
            cb11.BeginText();
            cb11.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb11.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde11, chord11_PosX, chord11_PosY, 0f);
            cb11.EndText();
            // //chord12
            // string dadosTextoAcorde12 = Intervalos.todosIntervalos1[11].ToString().Trim();
            // PdfContentByte cb12 = writer.DirectContent;
            // float chord12_PosX = chord12.AbsoluteX + ((chord12.Width * (scaleMultiplier / 100)) / 2);
            // float chord12_PosY = chord12.AbsoluteY + (chord12.Height * (scaleMultiplier / 100)) + 10f;
            // cb12.BeginText();
            // cb12.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            // cb12.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde12, chord12_PosX, chord12_PosY, 0f);
            // cb12.EndText();

            doc.Close();
        }

        private void cbFerramentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFerramentas.Text == "Todos Intervalos")
            {
                DataTable dtFiltroIntervalos = new DataTable();
                dtFiltroIntervalos.Columns.Add("Nome");
                dtFiltroIntervalos.Columns.Add("Intervalo");

                for (int i = 0; i < dtgEscalas.RowCount; i++)
                {
                    if (dtgEscalas.Rows[i].Cells[1].Value.ToString().Trim().Split(",".ToArray()).Length == 2)
                    {
                        dtFiltroIntervalos.Rows.Add(Intervalos.todosIntervalos1[Convert.ToInt32(dtgEscalas.Rows[i].Cells[1].Value.ToString().Trim().Split(",".ToArray())[1]) - 1].nome, dtgEscalas.Rows[i].Cells[1].Value.ToString().Trim());

                    }
                }

                dtgEscalas.DataSource = dtFiltroIntervalos;
            
            }
        }
    }
}
