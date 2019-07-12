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
    public partial class IntervalsTable : Form
    {
        private String[] arrNotesText = new String[12];        
        private String[] arrIntervalsText = new String[12];        
        private DataTable dt;

        public IntervalsTable()
        {
            InitializeComponent();
        }

        private void IntervalsTable_Load(object sender, EventArgs e)
        {
            SetThings();
            PopulateIntervalsTable();
            LinqTest();
        }

        private void SetThings()
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

            arrIntervalsText[0] = "T";
            arrIntervalsText[1] = "2b";
            arrIntervalsText[2] = "2";
            arrIntervalsText[3] = "3m";
            arrIntervalsText[4] = "3M";
            arrIntervalsText[5] = "4";
            arrIntervalsText[6] = "5b";
            arrIntervalsText[7] = "5";
            arrIntervalsText[8] = "5#";
            arrIntervalsText[9] = "6";
            arrIntervalsText[10] = "7";
            arrIntervalsText[11] = "7M";
           
        }
    
        private void PopulateIntervalsTable()
        {
            dt = new DataTable();
            string[] arrStrRowsAux = new string[12];
            int indexNote;             

            for (int i = 0; i < arrIntervalsText.Count(); i++)
            {
                dt.Columns.Add(arrIntervalsText[i].Trim());
            }

            for (int i = 0; i < arrNotesText.Count(); i++)
            {
                for (int j = 0; j < arrNotesText.Count(); j++)
                {
                    indexNote = j + i;
                    if (indexNote > 11)
                    {
                        indexNote -= 12;
                    }                    
                    arrStrRowsAux[j] = arrNotesText[indexNote];                    
                }
                
                dt.Rows.Add(arrStrRowsAux);              
            }                       

            foreach (DataColumn dtColumn in dt.Columns)
            {
                dtgIntervalsTable.Columns.Add(dtColumn.ColumnName, dtColumn.ColumnName);
            }

            foreach (DataRow dtRow in dt.Rows)
            {
                dtgIntervalsTable.Rows.Add(dtRow.ItemArray);
            }

            foreach (DataGridViewColumn column in dtgIntervalsTable.Columns)
            {
                dtgIntervalsTable.Columns[column.Index].Width = 60;
            }
        }

        private void LinqTest()
        {
            DataTable dt1 = new DataTable();
            DataGridView dgv1 = new DataGridView();
            List<string> dt1List = new List<string>();
            List<string> dgv1List = new List<string>();
            List<string> finalList = new List<string>();
            List<DataRow> dataRowsToAdd = new List<DataRow>();

            dt1.Columns.Add("Col1");
            dt1.Columns.Add("Col2");
            dt1.Rows.Add("Col1 - Value1", "Col2 - Value1");
            dt1.Rows.Add("Col1 - Value2", "Col2 - Value2");

            dgv1.Columns.Add("Col1", "Col1");
            dgv1.Columns.Add("Col2", "Col2");
            dgv1.Rows.Add("Col1 - Value1", "Col2 - Value1");

            Console.WriteLine(dt1.Rows.Count);
            Console.WriteLine(dgv1.Rows.Count);

            for (int rowIndex = 0; rowIndex < dt1.Rows.Count; rowIndex++)
            {
                dt1List.Add(dt1.Rows[rowIndex][0].ToString());
            }

            for (int rowIndex = 0; rowIndex < dgv1.Rows.Count - 1; rowIndex++)
            {
                dgv1List.Add(dgv1[0,rowIndex].Value.ToString());
            }
                        
            finalList = dt1List.Except(dgv1List).ToList<string>();

            for (int rowIndex1 = 0; rowIndex1 < dt1.Rows.Count; rowIndex1++)
            {
                for (int rowIndex2 = 0; rowIndex2 < finalList.Count; rowIndex2++)
                {
                    if (dt1.Rows[rowIndex1][0].ToString() == finalList[rowIndex2])
                    {
                        dataRowsToAdd.Add(dt1.Rows[rowIndex1]);
                    }
                }                               
            }

            foreach (DataRow row in dataRowsToAdd)
            {
                dgv1.Rows.Add(row.ItemArray);
            }                                  
        }
    }
}
