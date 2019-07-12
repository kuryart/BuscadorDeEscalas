using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TeclaProjeto
{
    [Designer(typeof(Design.TeclaDesigner), typeof(IRootDesigner))]
    public partial class Tecla : UserControl
    {
        float brancaWidth = 30;
        float brancaHeight = 100;
        ComboBox cb;

        [Description("Largura da Tecla"),
        Category("Values"),
        DefaultValue(0),
        Browsable(true)]
        public ComboBox Cor
        {     
            get
            {
                ComboBox comboBox = new ComboBox();
                comboBox.Items.Add("Branca");
                comboBox.Items.Add("Preta");

                return comboBox;
            }
            set { cb = value; Invalidate(); }
        }

        public Tecla()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.  
            base.OnPaint(e);
            // Call methods of the System.Drawing.Graphics object.  
            //e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle);
            //e.Graphics.DrawEllipse(Pens.Black, 0.0f, 0.0f, Width, Height);

            e.Graphics.FillRectangle(Brushes.White, 0.0f, 0.0f, Width, Height);
            e.Graphics.DrawRectangle(Pens.Black, 0.0f, 0.0f, Width - 1.0f, Height - 1.0f);
        }

        private void Tecla_Load(object sender, EventArgs e)
        {
            Width = 30;
            Height = 100;
        }
    }
}
