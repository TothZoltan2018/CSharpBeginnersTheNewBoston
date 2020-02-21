using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    //Part 119, 120, 121, 122, 123 - Drawing
    public partial class Form1 : Form
    {
        SolidBrush sb;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            //SolidBrush sb = new SolidBrush(Color.Green);
            ////Engedelyezzuk a panel1-re valo rajzolast.
            //Graphics g = panel1.CreateGraphics();
            ////g.FillRectangle(sb, 20, 20, 50, 50); //Egszerre csak egyet rajzol ki.
            //g.FillEllipse(sb, 80, 80, 160, 40);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sb = new SolidBrush(Color.Green);
            //Engedelyezzuk a panel1-re valo rajzolast.
            g = panel1.CreateGraphics();
            g.FillRectangle(sb, 20, 20, 50, 50); //Egszerre csak egy Fill metodust rajzol ki.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sb = new SolidBrush(Color.Red);
            g = panel1.CreateGraphics();
            g.FillEllipse(sb, 80, 80, 160, 40);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sb = new SolidBrush(Color.Blue);
            g = panel1.CreateGraphics();
            g.FillPie(sb, 50, 50, 40, 70, 10, 300);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sb = new SolidBrush(Color.Purple);
            g = panel1.CreateGraphics();
            Point[] points = { new Point(0, 120), new Point(0, 0), new Point(120, 0), new Point(240, 30), new Point(120, 120) };
            g.FillPolygon(sb, points);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Red, 3);
            Graphics g = panel1.CreateGraphics();
            g.DrawRectangle(pen, 20, 20, 50, 50);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Red, 3);
            Graphics g = panel1.CreateGraphics();
            g.DrawEllipse(pen, 70, 70, 60, 60);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Red, 3);
            Graphics g = panel1.CreateGraphics();           
            g.DrawArc(pen, 66, 66, 200, 100, 45, 120);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Red, 3);
            Graphics g = panel1.CreateGraphics();
            g.DrawBezier(pen, 100, 2, 37, 88, 7, 6, 44, 188);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Red, 3);
            Graphics g = panel1.CreateGraphics();
            g.DrawLine(pen, 0, 0, 150, 160);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            sb = new SolidBrush(Color.Green);
            Graphics g = panel1.CreateGraphics();

            FontFamily ff = new FontFamily("Arial");
            System.Drawing.Font font = new System.Drawing.Font(ff, 72, FontStyle.Regular);
            g.DrawString("Gyerekek", font, sb, 16, 66);
        }
    }
}
