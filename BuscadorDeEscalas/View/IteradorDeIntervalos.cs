using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BuscadorDeEscalas
{
    public partial class IteradorDeIntervalos : Form
    {
        public IteradorDeIntervalos()
        {
            InitializeComponent();
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString(4096, 2));   
            BooleanCombinator(11);
            //GenerateTextFile();
        }

        private void BooleanCombinator(int qtdBooleans)
        {
            List<string> lstFinal = new List<string>();
            List<string> lstIntervalos = new List<string>();
            int lenght = (int)Math.Pow(2, qtdBooleans);

            for (int i = 0; i < lenght; i++)
            {
                string teste = Convert.ToString(i, 2);

                int charsToFill = qtdBooleans - teste.Length;

                for (int j = 0; j < charsToFill; j++)
                {
                    teste = teste + "0";
                }

                string teste2 = teste.Replace("0", "a");
                teste2 = teste2.Replace("1", "0");
                teste2 = teste2.Replace("a", "1");

                if (!lstFinal.Exists(x => x == teste))
                {
                    lstFinal.Add(teste);
                }

                if (!lstFinal.Exists(x => x == teste2))
                {
                    lstFinal.Add(teste2);
                }
            }

            lstFinal.Sort();

            foreach (string teste in lstFinal)
            {
                Console.WriteLine(teste);
            }

            XDocument xml = new XDocument();
            xml.Add(new XElement("scales"));
            string escala = "";

            for (int j = 0; j < lstFinal.Count; j++)
            {
                XElement elementScale = new XElement("scale");
                XAttribute attributeName = new XAttribute("name", "Combinação " + (j + 1).ToString());
                elementScale.Add(attributeName);

                escala = "1";
                for (int k = 0; k < lstFinal[j].Length; k++)
                {
                    if (lstFinal[j].Substring(k, 1) == "1")
                    {
                        escala += "," + (k + 2).ToString();
                    }
                }

                XAttribute attributeKey = new XAttribute("keys", escala);
                elementScale.Add(attributeKey);
                xml.Element("scales").Add(elementScale);
            }

            xml.Save(@"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\scales.xml");
        }

        private void GenerateTextFile()
        {
            string path = @"C:\Users\PauloCezar\Documents\KuryArt\Arte\Música\Estudos\Criados\MyTest.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    //string strFinal = BooleanCombinator(12);
                    //sw.WriteLine(strFinal);
                }
            }          

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
