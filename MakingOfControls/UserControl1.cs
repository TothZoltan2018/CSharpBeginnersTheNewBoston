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
    //Part133, 134 - Making Controls
    public partial class MyButton : UserControl
    {
        public MyButton()
        {
            InitializeComponent();
        }

        //A projecten: Add new item: User Control
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush sb = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
            Graphics g = this.CreateGraphics();
            g.FillRectangle(sb, 0, 0, this.Width, this.Height);
            //Most, ha buildelem a projektet, akkor a Toolbox-ban megjelenik a Mybutton is.

            label1.Location = new Point(this.Width / 2 - label1.Width / 2, this.Height / 2 - label1.Height / 2);
        }

        //A MyButton-nak ezzel keszitunk egy, a form1-rol is elerheto property-t. (Build utan.)
        public string MyButtText 
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        
        }
    }
}
