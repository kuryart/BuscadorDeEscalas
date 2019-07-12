using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BuscadorDeEscalas
{
    public partial class BuscadorDeEscala : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
     
        }

        public BuscadorDeEscala()
        {
            InitializeComponent();
        }

        private Notas ExaminaAsNotasMarcadas()
        {
            var sortedList = grpNotas.Controls.OfType<CheckBox>().OrderBy(x => Convert.ToInt32(x.Tag)).ToList();
            grpNotas.Controls.AddRange(sortedList.ToArray());
            Notas notasFinal = new Notas();

            foreach (CheckBox chk in grpNotas.Controls.OfType<CheckBox>())
            {
               if (chk.Checked)
                {
                    notasFinal.Add(Convert.ToInt32(chk.Tag));                    
                }
            }

            return notasFinal;            
        }

        private List<Intervalos> ObtemOsIntervalos(Notas notasPassadas)
        {
            List<Intervalos> intervalosFinal = new List<Intervalos>();

            for (int i = 0; i <= notasPassadas.Length - 1; i++)
            {
                Intervalos intervalosProvisorios = new Intervalos();
                int controle = 0;
                while (controle < notasPassadas.Length)
                {
                    int indexParaCalcular = i + controle;

                    if (indexParaCalcular >= notasPassadas.Length)
                    {
                        indexParaCalcular -= notasPassadas.Length;
                    }                       

                    int resultado;

                    resultado = Intervalos.CalculaIntervalo(notasPassadas[i], notasPassadas[indexParaCalcular]).id;
                    intervalosProvisorios.Add(resultado);
                    controle += 1;
                }
                intervalosFinal.Add(intervalosProvisorios);
            }

            return intervalosFinal;
        }

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

        private void OutroTeste (List<Intervalos> intervalosFinal)
        {
            DataSet dataSetTodasEscalas = LeXMLEscalas();
            DataSet tabelaFinal = new DataSet();            
            tabelaFinal.Tables.Add("ResultadoFinal");
            tabelaFinal.Tables[0].Columns.Add("Nome");
            tabelaFinal.Tables[0].Columns.Add("ID");

            IEnumerable<DataRow> enumRowsEscalas = from x
                                                   in dataSetTodasEscalas.Tables[0].AsEnumerable()
                                                   select x;

            IEnumerable<Intervalos> enumRowsIntervalosPassados = from x
                                                                 in intervalosFinal
                                                                 select x;

            List<string[]> arrNotasPassadasSplit = new List<string[]>();

            foreach (Intervalos intervalosPassados in enumRowsIntervalosPassados)
            {
                string[] arrayIntervalos = new string[intervalosPassados.Length];

                for (int i = 0; i < intervalosPassados.Length; i++)
                {
                    arrayIntervalos[i] = (intervalosPassados[i].id + 1).ToString();
                }

                arrNotasPassadasSplit.Add(arrayIntervalos);
            }

            IEnumerable<string[]> enumNotasPassadasSplit = from x
                                                           in arrNotasPassadasSplit
                                                           select x;

            foreach (DataRow row in enumRowsEscalas)
            {
                string stringIntervalos;
                string[] arrayIntervalos;

                stringIntervalos = row[1].ToString();
                arrayIntervalos = stringIntervalos.Split(',');

                IEnumerable<string> enumTodasEscalasSplit = from x
                                                            in arrayIntervalos
                                                            select x;

                for (int i = 0; i < enumNotasPassadasSplit.Count(); i++)
                {
                    IEnumerable<string> enumNotasPassadasSplit2 = from x
                                                                  in enumNotasPassadasSplit.ElementAt(i)
                                                                  select x;
                    if (enumTodasEscalasSplit.Intersect(enumNotasPassadasSplit2).Count() == enumNotasPassadasSplit2.Count())
                    {
                        tabelaFinal.Tables[0].Rows.Add(row.ItemArray);                        
                    }                    
                }                
            }

            var rowsFinal = (from x in tabelaFinal.Tables[0].AsEnumerable()
                            group x by x["Nome"] into g
                            select g).Select(y => y.First());

            //rowsFinal = rowsFinal.Distinct();

            if (dtgTeste.Columns.Count == 0)
            {
                dtgTeste.Columns.Add("colNome", "Nome");
                dtgTeste.Columns.Add("colID", "ID");
            }

            dtgTeste.Rows.Clear();

            foreach (DataRow row in rowsFinal)
            {
                dtgTeste.Rows.Add(row.ItemArray);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //ProcessoTeste();   
            LeXMLEscalas();
            OutroTeste(ObtemOsIntervalos(ExaminaAsNotasMarcadas()));
        }
    }
}
