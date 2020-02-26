using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPaint
{
    //Part133, 134, 135, 136 - Making Controls
    public partial class MyButton : UserControl
    {
        public MyButton()
        {
            InitializeComponent();
        }

        //A projecten: Add new item: User Control
        string text = string.Empty; //Eltavolitottuk a korabbi label1-et, mert alatta nem latszodott szepen a gomb.
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush sb = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
            Graphics g = this.CreateGraphics();
            g.FillRectangle(sb, 0, 0, this.Width, this.Height);
            //Most, ha buildelem a projektet, akkor a Toolbox-ban megjelenik a Mybutton is.

            //Az eredeti Windows-os gombokhoz hasonloan a gomb also felere tegyunk egy sotet teglalapot
            sb.Color = Color.FromKnownColor(KnownColor.ControlLight);
            g.FillRectangle(sb, 0, this.Height / 2, this.Width, this.Height / 2);

            //label helyett DrawString
            PointF fPoint = new Point(this.Width / 2 - text.Length / 2, this.Height / 2 - text.Length / 2);
            FontFamily ff = new FontFamily("Arial");
            Font f = new System.Drawing.Font(ff, 8);
            sb.Color = Color.Black;
            g.DrawString(text, f, sb, fPoint);
            
        }

        //A MyButton-nak ezzel keszitunk egy, a form1-rol is elerheto property-t. (Build utan.)
        public string MyButtText 
        {
            get { return text; }
            set { text = value; }
        
        }
    }
}
