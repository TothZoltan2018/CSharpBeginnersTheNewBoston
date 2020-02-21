using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;//
using System.Threading;

namespace Drawing
{
    //Part 125, 126 - PathGradientBrush
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();

            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(30, 30, 360, 360);
            Rectangle r = new Rectangle(400, 30, 360, 360);
            gp.AddRectangle(r);
            Point[] points = { new Point(30, 600), new Point(70, 440), new Point(120, 700), new Point(400, 550), new Point(300, 450) };
            gp.AddPolygon(points);
            PathGradientBrush pgb = new PathGradientBrush(gp);
            pgb.CenterColor = Color.White;
            pgb.SurroundColors = new Color[] { Color.Black };

            g.FillEllipse(pgb, 30, 30, 360, 360);
            g.FillRectangle(pgb, r);
            g.FillPolygon(pgb, points);
        }
    }
}
