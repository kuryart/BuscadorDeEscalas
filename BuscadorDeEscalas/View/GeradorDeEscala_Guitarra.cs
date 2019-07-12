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
    public partial class frmGeradorDeEscala_Guitarra : Form
    {
        #region Variaveis

        // Intervalos e Notas
        Intervalos intervalosDaEscala = new Intervalos();
        Notas notasDaEscala = new Notas();

        // Geral 
        bool isLoaded = false;

        // Graphics e Bitmaps
        Graphics graphics;
        Bitmap bitmap;
        int bpmWidth;
        int bpmHeight;
        Brush colorNoteSelected = Brushes.IndianRed;

        // Guitarra
        float startPositionX = 0;
        float startPositionY = 0;
        float guitarOffsetX = 20;
        float guitarOffsetY = 50;
        float lenght = 1500;
        float height = 100;
        float ratio = 1.059463f;

        int[,] guitarFretsNotes = new int[6, 25];
        // Dimensão 1: corda
        // guitarFretsNotes[0,]: corda 1
        // guitarFretsNotes[1,]: corda 2
        // guitarFretsNotes[2,]: corda 3
        // guitarFretsNotes[3,]: corda 4
        // guitarFretsNotes[4,]: corda 5
        // guitarFretsNotes[5,]: corda 6
        // Dimensão 2: casa

        int[] guitarTunning = new int[6] { 4, 11, 7, 2, 9, 4 };

        #endregion

        // Construtor
        public frmGeradorDeEscala_Guitarra()
        {
            InitializeComponent();
        }

        private void frmGeradorDeEscala_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            bpmWidth = panCanvas.Width;
            bpmHeight = panCanvas.Height;

            bitmap = new Bitmap(bpmWidth, bpmHeight);
            graphics = Graphics.FromImage(bitmap);
        }

        private void GetNotasGuitarra()
        {
            int lastNoteId = 0;
            for (int i = 0; i < guitarFretsNotes.GetLength(0); i++)
            {
                lastNoteId = guitarTunning[i];
                guitarFretsNotes[i, 0] = lastNoteId;
                for (int j = 1; j < guitarFretsNotes.GetLength(1); j++)
                {
                    guitarFretsNotes[i, j] = Notas.CalculaNota(new Nota(lastNoteId), new Intervalo(1)).id;
                    lastNoteId = guitarFretsNotes[i, j];
                }                
            }
        }

        #region PintaGuitarra
        private void PaintGuitarra(object sender, PaintEventArgs e)
        {     
            bitmap = new Bitmap(bpmWidth, bpmHeight);
            graphics = Graphics.FromImage(bitmap);

            graphics.FillRectangle(Brushes.GhostWhite, panCanvas.Bounds.X, panCanvas.Bounds.Y, panCanvas.Width, panCanvas.Height);

            double lastPosition = lenght;
            double currentPosition = lastPosition / ratio;
            double currentWidht = lastPosition - currentPosition;
            double nextStartPosition = startPositionX;

            graphics.FillRectangle(Brushes.GhostWhite, (float)nextStartPosition + guitarOffsetX, startPositionY + guitarOffsetY, (float)currentWidht, height);
            graphics.DrawRectangle(Pens.LightGray, (float)nextStartPosition + guitarOffsetX, startPositionY + guitarOffsetY, (float)currentWidht, height);

            double bolaRadius = 9;
            double bolaPosX = nextStartPosition + (currentWidht / 2) - (bolaRadius / 2);
            double bolaPosY = (height / 2) - (bolaRadius / 2) + guitarOffsetY;

            graphics.FillEllipse(Brushes.LightGray, (float)bolaPosX + guitarOffsetX, (float)bolaPosY, (float)bolaRadius, (float)bolaRadius);

            for (int i = 0; i < 23; i++)
            {
                nextStartPosition = nextStartPosition + currentWidht;
                lastPosition = currentPosition;
                currentPosition = lastPosition / ratio;
                currentWidht = lastPosition - currentPosition;

                graphics.FillRectangle(Brushes.GhostWhite, (float)nextStartPosition + guitarOffsetX, startPositionY + guitarOffsetY, (float)currentWidht, height);
                graphics.DrawRectangle(Pens.LightGray, (float)nextStartPosition + guitarOffsetX, startPositionY + guitarOffsetY, (float)currentWidht, height);        
               
            }

            lastPosition = lenght;
            currentPosition = lastPosition / ratio;
            currentWidht = lastPosition - currentPosition;
            nextStartPosition = startPositionX;

            for (int i = 0; i < 23; i++)
            {
                nextStartPosition = nextStartPosition + currentWidht;
                lastPosition = currentPosition;
                currentPosition = lastPosition / ratio;
                currentWidht = lastPosition - currentPosition;

                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 13 || i == 15 || i == 17 || i == 19)
                {
                    bolaPosX = nextStartPosition + (currentWidht / 2) - (bolaRadius / 2);
                    bolaPosY = (height / 2) - (bolaRadius / 2);

                    graphics.FillEllipse(Brushes.LightGray, (float)bolaPosX + guitarOffsetX, (float)bolaPosY + guitarOffsetY, (float)bolaRadius, (float)bolaRadius);                    
                }

                if (i == 10 || i == 22)
                {
                    bolaPosX = nextStartPosition + (currentWidht / 2) - (bolaRadius / 2);
                    bolaPosY = (height * (2.0 / 8.0)) - (bolaRadius / 2);

                    graphics.FillEllipse(Brushes.LightGray, (float)bolaPosX + guitarOffsetX, (float)bolaPosY + guitarOffsetY, (float)bolaRadius, (float)bolaRadius);

                    bolaPosY = (height * (6.0 / 8.0)) - (bolaRadius / 2);

                    graphics.FillEllipse(Brushes.LightGray, (float)bolaPosX + guitarOffsetX, (float)bolaPosY + guitarOffsetY, (float)bolaRadius, (float)bolaRadius);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                graphics.DrawLine(Pens.LightGray, 0 + guitarOffsetX, (height * (float)(i / 5.0)) + guitarOffsetY, lenght, (height * (float)(i / 5.0)) + guitarOffsetY);
            }

            
            graphics.Flush(FlushIntention.Sync);
            graphics.Save();

            e.Graphics.DrawImage(bitmap, 0, 0);            
        }

        private void PaintGuitarraNotas(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < guitarFretsNotes.GetLength(0); i++)
            {
                double lastPosition = lenght;
                double currentPosition = lastPosition / ratio;
                double currentWidht = lastPosition - currentPosition;
                double nextStartPosition = startPositionX;

                double bolaRadius = 12;
                double bolaPosX = nextStartPosition - (bolaRadius / 2);
                double bolaPosY = height * (float)(i / 5.0) + guitarOffsetY - (bolaRadius / 2);
                                
                if (notasDaEscala.notasSelecionadas.Exists(x => x.id == guitarFretsNotes[i, 0])) 
                {
                    graphics.FillEllipse(Brushes.GhostWhite, (float)bolaPosX + guitarOffsetX + (float)(bolaRadius / 2) - (12 / 2), (float)bolaPosY + (float)(bolaRadius / 2) - (12 / 2), 12, 12);
                    graphics.DrawString(Notas.todasNotas[guitarTunning[i]].nome, new System.Drawing.Font("Arial", 8, FontStyle.Regular), Brushes.Black, (float)bolaPosX + guitarOffsetX, (float)bolaPosY);

                }

                for (int j = 1; j < guitarFretsNotes.GetLength(1); j++)
                {
                    if (j == 1)
                    {
                        lastPosition = lenght;
                        currentPosition = lastPosition / ratio;
                        currentWidht = lastPosition - currentPosition;
                        nextStartPosition = startPositionX;

                        bolaRadius = 12;
                        bolaPosX = nextStartPosition + (currentWidht / 2) - (bolaRadius / 2);
                        bolaPosY = height * (float)(i / 5.0) + guitarOffsetY - (bolaRadius / 2);
                        
                    } 
                    else
                    {
                        nextStartPosition = nextStartPosition + currentWidht;
                        lastPosition = currentPosition;
                        currentPosition = lastPosition / ratio;
                        currentWidht = lastPosition - currentPosition;

                        bolaPosX = nextStartPosition + (currentWidht / 2) - (bolaRadius / 2);
                        bolaPosY = height * (float)(i / 5.0) + guitarOffsetY - (bolaRadius / 2);                                                
                    }

                    if (notasDaEscala.notasSelecionadas.Exists(x => x.id == guitarFretsNotes[i, j]))
                    {
                        graphics.FillEllipse(Brushes.GhostWhite, (float)bolaPosX + guitarOffsetX + (float)(bolaRadius / 2) - (12 / 2), (float)bolaPosY + (float)(bolaRadius / 2) - (12 / 2), 12, 12);
                        graphics.DrawString(Notas.todasNotas[guitarFretsNotes[i, j]].nome, new System.Drawing.Font("Arial", 8, FontStyle.Regular), Brushes.Black, (float)bolaPosX + guitarOffsetX, (float)bolaPosY);
                    }                    
                }
            }

            graphics.Flush(FlushIntention.Sync);
            graphics.Save();

            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        #endregion

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

            SetIntervalosEscala();
            SetNotasEscala();
            Refresh();
        }

        private void btnProcessar_Click(object sender, EventArgs e)
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

            MessageBox.Show(dtgEscalas.Rows.Count.ToString());
        }

        private void cbNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
            {
                return;
            }

            SetIntervalosEscala();
            SetNotasEscala();
            Refresh();
        }

        private void frmGeradorDeEscala_Paint(object sender, PaintEventArgs e)
        {
            if (!isLoaded)
            {
                PreencheTabela();
                GetNotasGuitarra();
                GetNotas();
                SetIntervalosEscala();
                SetNotasEscala();

                panCanvas.Paint += PaintGuitarra;
                panCanvas.Paint += PaintGuitarraNotas;
                isLoaded = true;
                dtgEscalas.Rows[1].Selected = true;
                dtgEscalas.Rows[0].Selected = true;
            }
        }

        private void SalvaImagem()
        {
            string scaleName = dtgEscalas.SelectedRows[0].Cells[0].Value.ToString().Replace(":", " -").Trim();
            string noteName = cbNotas.SelectedItem.ToString().Trim();
            string path = @"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\Imagens\" + scaleName;
            CheckFolderExists(path);
            Bitmap bm = new Bitmap(bitmap);
            bitmap.Dispose();
            try
            {
                bm.Save(path + @"\" + noteName + ".png", ImageFormat.Png);
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
            string scaleName = dtgEscalas.SelectedRows[0].Cells[0].Value.ToString().Replace(":", " -").Trim();
            string noteName = cbNotas.SelectedItem.ToString().Trim();
            string caminho = @"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\" + scaleName + ".pdf";
            
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
            paragrafo.Add(scaleName);
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
            iTextSharp.text.Image chord1 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\Imagens\" + @"\" + scaleName + @"\" + cbNotas.Items[0].ToString().Trim() + ".png");
            chord1.ScalePercent(scaleMultiplier);
            chord1.SetAbsolutePosition(doc.PageSize.Width * widthMin,
                                           doc.PageSize.Height * height1);
            doc.Add(chord1);
            //chord2
            iTextSharp.text.Image chord2 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\Imagens\" + @"\" + scaleName + @"\" + cbNotas.Items[1].ToString().Trim() + ".png");
            chord2.ScalePercent(scaleMultiplier);
            chord2.SetAbsolutePosition(doc.PageSize.Width * widthMax,
                                           doc.PageSize.Height * height1);
            doc.Add(chord2);
            //chord3
            iTextSharp.text.Image chord3 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\Imagens\" + @"\" + scaleName + @"\" + cbNotas.Items[2].ToString().Trim() + ".png");
            chord3.ScalePercent(scaleMultiplier);
            chord3.SetAbsolutePosition(doc.PageSize.Width * widthMin,
                                           doc.PageSize.Height * height2);
            doc.Add(chord3);
            //chord4
            iTextSharp.text.Image chord4 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\Imagens\" + @"\" + scaleName + @"\" + cbNotas.Items[3].ToString().Trim() + ".png");
            chord4.ScalePercent(scaleMultiplier);
            chord4.SetAbsolutePosition(doc.PageSize.Width * widthMax,
                                           doc.PageSize.Height * height2);
            doc.Add(chord4);
            //chord5
            iTextSharp.text.Image chord5 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\Imagens\" + @"\" + scaleName + @"\" + cbNotas.Items[4].ToString().Trim() + ".png");
            chord5.ScalePercent(scaleMultiplier);
            chord5.SetAbsolutePosition(doc.PageSize.Width * widthMin,
                                           doc.PageSize.Height * height3);
            doc.Add(chord5);
            //chord6
            iTextSharp.text.Image chord6 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\Imagens\" + @"\" + scaleName + @"\" + cbNotas.Items[5].ToString().Trim() + ".png");
            chord6.ScalePercent(scaleMultiplier);
            chord6.SetAbsolutePosition(doc.PageSize.Width * widthMax,
                                           doc.PageSize.Height * height3);
            doc.Add(chord6);
            //chord7
            iTextSharp.text.Image chord7 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\Imagens\" + @"\" + scaleName + @"\" + cbNotas.Items[6].ToString().Trim() + ".png");
            chord7.ScalePercent(scaleMultiplier);
            chord7.SetAbsolutePosition(doc.PageSize.Width * widthMin,
                                           doc.PageSize.Height * height4);
            doc.Add(chord7);
            //chord8
            iTextSharp.text.Image chord8 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\Imagens\" + @"\" + scaleName + @"\" + cbNotas.Items[7].ToString().Trim() + ".png");
            chord8.ScalePercent(scaleMultiplier);
            chord8.SetAbsolutePosition(doc.PageSize.Width * widthMax,
                                           doc.PageSize.Height * height4);
            doc.Add(chord8);
            //chord9
            iTextSharp.text.Image chord9 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\Imagens\" + @"\" + scaleName + @"\" + cbNotas.Items[8].ToString().Trim() + ".png");
            chord9.ScalePercent(scaleMultiplier);
            chord9.SetAbsolutePosition(doc.PageSize.Width * widthMin,
                                           doc.PageSize.Height * height5);
            doc.Add(chord9);
            //chord10
            iTextSharp.text.Image chord10 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\Imagens\" + @"\" + scaleName + @"\" + cbNotas.Items[9].ToString().Trim() + ".png");
            chord10.ScalePercent(scaleMultiplier);
            chord10.SetAbsolutePosition(doc.PageSize.Width * widthMax,
                                           doc.PageSize.Height * height5);
            doc.Add(chord10);
            //chord11
            iTextSharp.text.Image chord11 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\Imagens\" + @"\" + scaleName + @"\" + cbNotas.Items[10].ToString().Trim() + ".png");
            chord11.ScalePercent(scaleMultiplier);
            chord11.SetAbsolutePosition(doc.PageSize.Width * widthMin,
                                           doc.PageSize.Height * height6);
            doc.Add(chord11);
            //chord12
            iTextSharp.text.Image chord12 = iTextSharp.text.Image.GetInstance(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\Teclado\Escalas\Imagens\" + @"\" + scaleName + @"\" + cbNotas.Items[11].ToString().Trim() + ".png");
            chord12.ScalePercent(scaleMultiplier);
            chord12.SetAbsolutePosition(doc.PageSize.Width * widthMax,
                                           doc.PageSize.Height * height6);
            doc.Add(chord12);

            //=== ADICIONANDO TEXTO COM OS NOMES DOS ACORDES ===
            //chord1
            string dadosTextoAcorde1 = cbNotas.Items[0].ToString().Trim();
            PdfContentByte cb1 = writer.DirectContent;
            float chord1_PosX = chord1.AbsoluteX + ((chord1.Width * (scaleMultiplier / 100)) / 2);
            float chord1_PosY = chord1.AbsoluteY + (chord1.Height * (scaleMultiplier / 100)) + 10f;
            cb1.BeginText();
            cb1.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb1.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde1, chord1_PosX, chord1_PosY, 0f);
            cb1.EndText();
            //chord2
            string dadosTextoAcorde2 = cbNotas.Items[1].ToString().Trim();
            PdfContentByte cb2 = writer.DirectContent;
            float chord2_PosX = chord2.AbsoluteX + ((chord2.Width * (scaleMultiplier / 100)) / 2);
            float chord2_PosY = chord2.AbsoluteY + (chord2.Height * (scaleMultiplier / 100)) + 10f;
            cb2.BeginText();
            cb2.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb2.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde2, chord2_PosX, chord2_PosY, 0f);
            cb2.EndText();
            //chord3
            string dadosTextoAcorde3 = cbNotas.Items[2].ToString().Trim();
            PdfContentByte cb3 = writer.DirectContent;
            float chord3_PosX = chord3.AbsoluteX + ((chord3.Width * (scaleMultiplier / 100)) / 2);
            float chord3_PosY = chord3.AbsoluteY + (chord3.Height * (scaleMultiplier / 100)) + 10f;
            cb3.BeginText();
            cb3.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb3.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde3, chord3_PosX, chord3_PosY, 0f);
            cb3.EndText();
            //chord4
            string dadosTextoAcorde4 = cbNotas.Items[3].ToString().Trim();
            PdfContentByte cb4 = writer.DirectContent;
            float chord4_PosX = chord4.AbsoluteX + ((chord4.Width * (scaleMultiplier / 100)) / 2);
            float chord4_PosY = chord4.AbsoluteY + (chord4.Height * (scaleMultiplier / 100)) + 10f;
            cb4.BeginText();
            cb4.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb4.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde4, chord4_PosX, chord4_PosY, 0f);
            cb4.EndText();
            //chord5
            string dadosTextoAcorde5 = cbNotas.Items[4].ToString().Trim();
            PdfContentByte cb5 = writer.DirectContent;
            float chord5_PosX = chord5.AbsoluteX + ((chord5.Width * (scaleMultiplier / 100)) / 2);
            float chord5_PosY = chord5.AbsoluteY + (chord5.Height * (scaleMultiplier / 100)) + 10f;
            cb5.BeginText();
            cb5.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb5.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde5, chord5_PosX, chord5_PosY, 0f);
            cb5.EndText();
            //chord6
            string dadosTextoAcorde6 = cbNotas.Items[5].ToString().Trim();
            PdfContentByte cb6 = writer.DirectContent;
            float chord6_PosX = chord6.AbsoluteX + ((chord6.Width * (scaleMultiplier / 100)) / 2);
            float chord6_PosY = chord6.AbsoluteY + (chord6.Height * (scaleMultiplier / 100)) + 10f;
            cb6.BeginText();
            cb6.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb6.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde6, chord6_PosX, chord6_PosY, 0f);
            cb6.EndText();
            //chord7
            string dadosTextoAcorde7 = cbNotas.Items[6].ToString().Trim();
            PdfContentByte cb7 = writer.DirectContent;
            float chord7_PosX = chord7.AbsoluteX + ((chord7.Width * (scaleMultiplier / 100)) / 2);
            float chord7_PosY = chord7.AbsoluteY + (chord7.Height * (scaleMultiplier / 100)) + 10f;
            cb7.BeginText();
            cb7.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb7.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde7, chord7_PosX, chord7_PosY, 0f);
            cb7.EndText();
            //chord8
            string dadosTextoAcorde8 = cbNotas.Items[7].ToString().Trim();
            PdfContentByte cb8 = writer.DirectContent;
            float chord8_PosX = chord8.AbsoluteX + ((chord8.Width * (scaleMultiplier / 100)) / 2);
            float chord8_PosY = chord8.AbsoluteY + (chord8.Height * (scaleMultiplier / 100)) + 10f;
            cb7.BeginText();
            cb7.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb7.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde8, chord8_PosX, chord8_PosY, 0f);
            cb7.EndText();
            //chord9
            string dadosTextoAcorde9 = cbNotas.Items[8].ToString().Trim();
            PdfContentByte cb9 = writer.DirectContent;
            float chord9_PosX = chord9.AbsoluteX + ((chord9.Width * (scaleMultiplier / 100)) / 2);
            float chord9_PosY = chord9.AbsoluteY + (chord9.Height * (scaleMultiplier / 100)) + 10f;
            cb7.BeginText();
            cb7.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb7.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde9, chord9_PosX, chord9_PosY, 0f);
            cb7.EndText();
            //chord10
            string dadosTextoAcorde10 = cbNotas.Items[9].ToString().Trim();
            PdfContentByte cb10 = writer.DirectContent;
            float chord10_PosX = chord10.AbsoluteX + ((chord10.Width * (scaleMultiplier / 100)) / 2);
            float chord10_PosY = chord10.AbsoluteY + (chord10.Height * (scaleMultiplier / 100)) + 10f;
            cb10.BeginText();
            cb10.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb10.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde10, chord10_PosX, chord10_PosY, 0f);
            cb10.EndText();
            //chord11
            string dadosTextoAcorde11 = cbNotas.Items[10].ToString().Trim();
            PdfContentByte cb11 = writer.DirectContent;
            float chord11_PosX = chord11.AbsoluteX + ((chord11.Width * (scaleMultiplier / 100)) / 2);
            float chord11_PosY = chord11.AbsoluteY + (chord11.Height * (scaleMultiplier / 100)) + 10f;
            cb11.BeginText();
            cb11.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb11.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde11, chord11_PosX, chord11_PosY, 0f);
            cb11.EndText();
            //chord12
            string dadosTextoAcorde12 = cbNotas.Items[11].ToString().Trim();
            PdfContentByte cb12 = writer.DirectContent;
            float chord12_PosX = chord12.AbsoluteX + ((chord12.Width * (scaleMultiplier / 100)) / 2);
            float chord12_PosY = chord12.AbsoluteY + (chord12.Height * (scaleMultiplier / 100)) + 10f;
            cb12.BeginText();
            cb12.SetFontAndSize(BaseFont.CreateFont(), 16.0f);
            cb12.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dadosTextoAcorde12, chord12_PosX, chord12_PosY, 0f);
            cb12.EndText();

            doc.Close();
        }
    }
}
